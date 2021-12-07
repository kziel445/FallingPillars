using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreWinTrigger : MonoBehaviour
{
    [SerializeField] GameObject victoryPoint;
    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("Player").GetComponent<PlayerController>()
            .TeleportPlayerTo(gameObject.transform.position);
        victorPointActive(3);
    }
    public IEnumerator victorPointActive(int time)
    {
        yield return new WaitForSeconds(time);
        victoryPoint.SetActive(true);
    }
}
