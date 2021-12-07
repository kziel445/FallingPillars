using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Camera camera;
    public Vector3 offset;
    public bool useOffSetValues = true;
    public float rotateSpeed;
    public Transform pivot;

    void Start()
    {
        if (!useOffSetValues) offset = player.position - transform.position;
        pivot.transform.position = player.transform.position;
        pivot.transform.parent = player.transform;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        player.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        pivot.Rotate(-vertical, 0, 0);

        float desiredYAngle = player.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);

        transform.position = player.position - (rotation * offset);

        if (transform.position.y < player.position.y) transform.position = new Vector3(transform.position.x, player.position.y - 0.5f, transform.position.z);
        transform.LookAt(player);

        //if(Input.GetKeyDown("c")) useOffSetValues = !useOffSetValues;
        //if (!useOffSetValues) offset = player.position - transform.position;

    }
}
