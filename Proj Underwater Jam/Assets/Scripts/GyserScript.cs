using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyserScript : MonoBehaviour
{

    [SerializeField]
    float maxForce;
    [SerializeField]
    float forceScale;
    [SerializeField]
    float startForce;
    [SerializeField]
    float forceAdder;
    [SerializeField]
    float colliderHeight;

    BoxCollider boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.size = new Vector3(2, colliderHeight, 2);
        boxCollider.center = new Vector3(0, colliderHeight / 2, 0);
    }

    private void OnTriggerStay(Collider other)
    {
        if (forceAdder < maxForce)
        {
            forceAdder += forceScale * Time.deltaTime;
        }
        other.GetComponent<ConstantForce>().force = new Vector3(0, forceAdder, 0);
    }

    private void OnTriggerExit(Collider other)
    {
        forceAdder = startForce;
        other.GetComponent<ConstantForce>().force = Vector3.zero;
    }
}
