using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.Rotate(3, 3, -3);

    }
    private void OnTriggerEnter(Collider other)
    {
        ManagerUI.instance.points += 1;
        Destroy(gameObject);
    }
}
