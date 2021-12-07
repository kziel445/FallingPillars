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
    public void goFall()
    {
        foreach(Rigidbody rb in rigidbody)
        {
            rb.constraints = RigidbodyConstraints.None;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        goFall();
    }
}
