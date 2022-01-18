using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5.0f;
    [SerializeField] float lookSensitivity = 3.0f;

    PlayerMotor playerMotor;

    void Start()
    {
        playerMotor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        CalculateVelocity();
        CalculateRotation();
        CalculateCameraRotation();
    }

    // Calculate movement velocity as a 3D vector
    void CalculateVelocity()
    {
        float _xMovement = Input.GetAxisRaw("Horizontal");
        float _zMovement = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _xMovement;
        Vector3 _moveVertical = transform.forward * _zMovement;

        // Final Movement Vector
        Vector3 _playerVelocity = (_moveHorizontal + _moveVertical).normalized * playerSpeed;

        // Apply movement
        playerMotor.MovePlayer(_playerVelocity);
    }

    // Calculate rotation as a 3D vector (Turning around)
    void CalculateRotation()
    {
        float _yRotation = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0, _yRotation, 0f) * lookSensitivity;

        //Apply rotation
        playerMotor.RotatePlayer(_rotation);
    }

    // Calculate camera rotation as a 3D vector (Looking up/down)
    void CalculateCameraRotation()
    {
        float _xRotation = Input.GetAxisRaw("Mouse Y");

        Vector3 _cameraRotation = new Vector3(_xRotation, 0, 0) * lookSensitivity;

        //Apply rotation
        playerMotor.RotateCamera(_cameraRotation);
    }
}
