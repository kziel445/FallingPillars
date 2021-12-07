using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreWinTrigger : MonoBehaviour
{
    [SerializeField] GameObject victoryPoint;
    private void OnTriggerEnter(Collider other)
    {
        waitFor(5);
        victoryPoint.SetActive(true);

    }
    public IEnumerator waitFor(int time)
    {
        yield return new WaitForSeconds(time);
    }
}
