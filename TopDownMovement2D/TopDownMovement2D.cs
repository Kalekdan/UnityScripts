using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Top down movement script to make the player (or any GameObject the script is attached to) move
 * based on the horizontal and vertical axis values
 * 
 * This script and more available at: https://github.com/Kalekdan/UnityScripts
 */
public class TopDownMovement2D : MonoBehaviour
{
    // RigidBody2D is required on the GameObject - this handles the movement
    private Rigidbody2D _rb;

    // Move Speed defines the maximum distance the player can move in any direction on a given frame
    [SerializeField] private float _moveSpeed = .1f;

    // Private variables to hold the input values, and the starting z coordinate
    private float _horizontalInput, _verticalInput;
    private float _startZPos;

    // Initialises the RigidBody2D paramater with the RigidBody2D attached to the GameObject
    // Initialises the starting z coordinate parameter to ensure the player doesnt move towards or away from the camera
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _startZPos = transform.position.z;
    }

    // Called at a fixed interval every frame
    //  - Gets the current axis input values
    //  - Calculates the new position based on the current position, the inputs and the move speed
    //  - Moves the RigidBody2D to the new position
    void FixedUpdate()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");

        var newPos = transform.position + new Vector3(_horizontalInput * _moveSpeed, _verticalInput * _moveSpeed, _startZPos);
        _rb.MovePosition(newPos);
    }
}
