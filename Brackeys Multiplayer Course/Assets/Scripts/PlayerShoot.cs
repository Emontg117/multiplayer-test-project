using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerShoot : NetworkBehaviour
{
    const string PLAYER_TAG = "Player";

    public PlayerWeapon weapon;

    [SerializeField] Camera playerCamera;

    [SerializeField] LayerMask mask;

    private void Start()
    {
        if(playerCamera == null)
        {
            Debug.LogError("PlayerShoot: No camera referenced");
            this.enabled = false;
        }
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            ShootWeapon();
        }
    }

    [Client]
    void ShootWeapon()
    {
        RaycastHit _hit;
        if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out _hit, weapon.range, mask))
        {
            if(_hit.collider.tag == PLAYER_TAG)
            {
                CmdPlayerShot(_hit.collider.name);
            }
        }
    }
    
    [Command]
    void CmdPlayerShot(string _ID)
    {
        Debug.Log(_ID + " Has been shot");
    }

}
