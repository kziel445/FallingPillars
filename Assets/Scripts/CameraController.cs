using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    public float sensitivity = 200f;

    float xMax = 90;
    float xMin = -90;
    float mouseYMove;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseYMove += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        mouseYMove = Mathf.Clamp(mouseYMove, xMin, xMax);

        transform.localRotation = Quaternion.Euler(-mouseYMove, 0f, 0f);
        player.Rotate(Vector3.up * mouseXMove);
    }
}
