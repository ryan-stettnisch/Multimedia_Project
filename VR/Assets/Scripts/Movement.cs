using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 velocity;
    private Vector3 playerMovementInput;
    private Vector2 playerMouseInput;
    private float xRot;

    [SerializeField] private Transform playerCamera;
    [SerializeField] private CharacterController controller;

    [Header("Movement Settings")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float gravity = -9.81f;

    [Header("Look Settings")]
    [SerializeField] private float sensitivity = 2f;
    [SerializeField] private float minVerticalAngle = -90f;
    [SerializeField] private float maxVerticalAngle = 90f;

    private void Update()
    {
        playerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        playerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        MovePlayer();
        MovePlayerCamera();
    }

    private void MovePlayer()
    {
        Vector3 moveVector = transform.TransformDirection(playerMovementInput);
        speed = 10f;

        if (controller.isGrounded)
        {
            velocity.y = -1f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = jumpForce;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 20f;
            }
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }
        controller.Move(moveVector * speed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
    }

    private void MovePlayerCamera()
    {
        xRot -= playerMouseInput.y * sensitivity;
        xRot = Mathf.Clamp(xRot, minVerticalAngle, maxVerticalAngle);

        transform.Rotate(0f, playerMouseInput.x * sensitivity, 0f);
        playerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
    }
}