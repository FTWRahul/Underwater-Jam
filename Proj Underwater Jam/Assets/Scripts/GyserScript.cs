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
    float forceAdder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        other.GetComponent<ConstantForce>().force = Vector3.zero;
    }
}
