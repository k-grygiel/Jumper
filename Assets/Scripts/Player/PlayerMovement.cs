using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float speed;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float groundDrag;

        [Header("Jumps")]
        [SerializeField] private float jumpForce;
        [SerializeField] private float jumpMovementMultiplier;
        [SerializeField] private IntValue numberOfJumps;

        [Header("GroundCheck")]
        [SerializeField] float yOffset;
        [SerializeField] float radius;
        [SerializeField] private LayerMask groundLayer;

        [Space(20)]
        [SerializeField] private Transform camera;

        private PlayerMovementInput inputActions;
        private Rigidbody rigidbody;

        private Vector2 moveDirection;
        private Vector2 rotation;
        private float cameraRotationClamp = 89f;
        private float cameraRotation;
        private float playerRotation;
        private bool isGrounded;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        public void Init(PlayerMovementInput input)
        {
            inputActions = input;
            inputActions.Player.Jump.started += Jump;
        }

        private void Update()
        {
            moveDirection = inputActions.Player.Move.ReadValue<Vector2>();
            rotation = inputActions.Player.Look.ReadValue<Vector2>();

            isGrounded = CheckIfGrounded();
            rigidbody.drag = isGrounded ? groundDrag : 0;
        }

        private bool CheckIfGrounded()
        {
            Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - yOffset, transform.position.z);
            return Physics.CheckSphere(spherePosition, radius, groundLayer, QueryTriggerInteraction.Ignore);
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Jump(InputAction.CallbackContext obj)
        {
            if (!isGrounded)
                return;

            numberOfJumps.Value++;
            rigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }

        private void LateUpdate()
        {
            RotateCamera();
        }

        private void RotateCamera()
        {
            if (rotation.sqrMagnitude < Mathf.Epsilon)
                return;

            cameraRotation += rotation.y * rotationSpeed;
            playerRotation = rotation.x * rotationSpeed;

            cameraRotation = Mathf.Clamp(cameraRotation, -cameraRotationClamp, cameraRotationClamp);

            camera.localRotation = Quaternion.Euler(cameraRotation, 0, 0);
            transform.Rotate(Vector3.up * playerRotation);
        }

        private void Move()
        {
            Vector3 inputDirection = new Vector3(moveDirection.x, 0.0f, moveDirection.y).normalized;

            if (moveDirection != Vector2.zero)
                inputDirection = transform.right * moveDirection.x + transform.forward * moveDirection.y;

            if(isGrounded)
                rigidbody.AddForce(inputDirection.normalized * speed, ForceMode.Force);
            else
                rigidbody.AddForce(inputDirection.normalized * speed * jumpMovementMultiplier, ForceMode.Force);
        }
    }
}