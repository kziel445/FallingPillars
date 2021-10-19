using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public CharacterController controller;
    private Vector3 moveDirection;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        float xAxis = Input.GetAxis("Horizontal") * moveSpeed;
        float zAxis = Input.GetAxis("Vertical") * moveSpeed;
        moveDirection = new Vector3(xAxis, 0f, zAxis);

        if(Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpForce;
        }
        controller.Move(moveDirection * Time.deltaTime);
    }
}
