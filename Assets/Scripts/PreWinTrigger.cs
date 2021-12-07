using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreWinTrigger : MonoBehaviour
{
    [SerializeField] GameObject victoryPoint;
    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("Player").GetComponent<PlayerController>().spawnPoint = 
            gameObject.transform.position;
        victoryPoint.SetActive(true);
    }
}
