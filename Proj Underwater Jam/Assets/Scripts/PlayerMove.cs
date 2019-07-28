using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    float movementSpeed;
    [SerializeField]
    float rotationSpeed;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();
        RaycastHit hit;
        //if(Physics.Raycast(transform.position, Vector3.down * 0.2f, out hit ))
        Debug.DrawLine(transform.position, transform.position + new Vector3(0, -1.2f, 0), Color.red);
        if(Physics.Raycast(transform.position, Vector3.down, out hit, 1.2f))
        {
            if(hit.collider.CompareTag("Ground"))
            {
                //Debug.Log("GroundHit");
                rotationSpeed = 5f;
            }
        }
        else
        {
           //Debug.Log("HitNothing");
            rotationSpeed = .5f;
        }
    }

    private void MovePlayer()
    {
        float input = Input.GetAxis("Horizontal");
        if(Mathf.Abs(rb.angularVelocity.z) < 4)
        {
            rb.AddTorque(new Vector3(0, 0, -input * rotationSpeed * 100 * Time.deltaTime));
        }
        rb.AddForce(new Vector3(input * movementSpeed * 100 * Time.deltaTime, 0, 0));
    }
}
