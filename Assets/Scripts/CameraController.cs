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
    void Start()
    {
        if (!useOffSetValues) offset = player.position - transform.position;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        player.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        player.Rotate(-vertical, 0, 0);

        float desiredYAngle = player.eulerAngles.y;
        float desiredXAngle = player.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);

        transform.position = player.position - (rotation * offset);
        //transform.position = player.position - offset;
        transform.LookAt(player.transform);

        //if(Input.GetKeyDown("c")) useOffSetValues = !useOffSetValues;
        //if (!useOffSetValues) offset = player.position - transform.position;

    }
}
