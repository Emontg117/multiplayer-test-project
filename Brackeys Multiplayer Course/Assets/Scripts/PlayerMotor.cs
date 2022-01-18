using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField] Camera playerCam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;

    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Run every physics iteration
    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    public void MovePlayer(Vector3 _playerVelocity)
    {
        velocity = _playerVelocity;
    }

    public void RotatePlayer(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    public void RotateCamera(Vector3 _cameraRotation)
    {
        cameraRotation = _cameraRotation;
    }

    // Perform movement based on velocity
    void PerformMovement()
    {
        if(velocity != Vector3.zero)
        {
            playerRb.MovePosition(playerRb.position + velocity * Time.deltaTime);
        }
    }

    // Perform rotation based on rotation
    void PerformRotation()
    {
        playerRb.MoveRotation(playerRb.rotation * Quaternion.Euler(rotation));
        if(playerCam != null)
        {
            playerCam.transform.Rotate(-cameraRotation);
        }
    }

}
