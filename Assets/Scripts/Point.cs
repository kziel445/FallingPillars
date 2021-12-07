using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] int points = 1;
    void Update()
    {
        gameObject.transform.Rotate(1, 1, -1);

    }
    private void OnTriggerEnter(Collider other)
    {
        ManagerUI.instance.points += points;
        Destroy(gameObject);
    }
}
