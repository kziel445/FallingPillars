using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private Vector3 move;
    private Vector3 moveInAir;
    public Vector3 spawnPoint = new Vector3(15, 75, 5);
    private bool groundedPlayer;
    private float playerSpeed = 10.0f;
    public float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        if(groundedPlayer)
        {
            move = transform.right * moveX + transform.forward * moveZ;
            moveInAir = Vector3.zero;
        }
        if (!groundedPlayer)
        {
            moveInAir = (transform.right * moveX + transform.forward * moveZ)*1/4;
        }

        controller.Move((move + moveInAir) * Time.deltaTime * playerSpeed);

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (gameObject.transform.position.y < 0 && ManagerUI.instance.lives == 0)
        {
            ManagerUI.instance.lives -= 1;
            TeleportPlayerTo(spawnPoint);
        }
        if (Input.GetKeyDown(KeyCode.B)) TeleportPlayerTo(spawnPoint);
    }
    public void TeleportPlayerTo(Vector3 position)
    {
        gameObject.transform.position = position;
    }    
}
