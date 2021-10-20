using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float gravityScale;
    public CharacterController controller;
    private Vector3 moveDirection;
    private Vector3 jumpDirection;
    float yStore;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        if (controller.isGrounded)
        {
            jumpDirection = Vector3.zero;
            moveDirection.y = 0f;
            moveDirection = (transform.right * Input.GetAxis("Horizontal")) + (transform.forward * Input.GetAxis("Vertical"));
            moveDirection = moveDirection.normalized * moveSpeed;

            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }
        else if (!controller.isGrounded)
        {
            jumpDirection = (transform.right * Input.GetAxis("Horizontal")) + (transform.forward * Input.GetAxis("Vertical"));
            jumpDirection = jumpDirection.normalized * moveSpeed * 1 / 4 ;
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move((moveDirection + jumpDirection) * Time.deltaTime);
    }
}
