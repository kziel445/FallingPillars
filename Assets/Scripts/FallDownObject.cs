using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDownObject : MonoBehaviour
{
    [SerializeField] List<GameObject> toFall;
    public List<Rigidbody> rigidbody;
    private void Awake()
    {
        foreach(GameObject gameObj in toFall)
        {
            Rigidbody rb = gameObj.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = gameObj.AddComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ |
                    RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            }
            rigidbody.Add(rb);
        }
    }
    public IEnumerator goFall()
    {
        Debug.Log("1");
        foreach (Rigidbody rb in rigidbody)
        {
            Debug.Log("1");
            yield return new WaitForSeconds(1);
            Debug.Log("2");
            rb.constraints = RigidbodyConstraints.None;
        }
    }
    IEnumerator timeToFall(float time)
    {
        yield return new WaitForSeconds(time);
    }
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(goFall());
    }
}
