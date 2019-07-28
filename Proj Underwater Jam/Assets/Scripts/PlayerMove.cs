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

    public static bool isGrounded;
    Vector3 lastPosi;
    Vector3 newPosi;
    bool isFalling;
    int fallCounter;

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
                isGrounded = true;
            }
        }
        else
        {
            isGrounded = false;
            isFalling = true;
           //Debug.Log("HitNothing");
            rotationSpeed = .5f;
        }
        if (isFalling && isGrounded)
        {
            CheckFallDistance(lastPosi, transform.position);
        }
        if (isGrounded && !isFalling)
        {
            lastPosi = transform.position;
        }
    }

    public void CheckFallDistance(Vector3 lastPosi, Vector3 newPosi)
    {
        float difference = lastPosi.y- newPosi.y;
        //Debug.Log("LAST POSI" + lastPosi);
        //Debug.Log("NEW POSI"+newPosi);
        //Debug.Log(difference);
        if (difference > 50)
        {
            Debug.Log("Huge fall");
        }
        else if (difference > 20)
        {
            Debug.Log("Medium fall");
        }
        fallCounter++;
        //else if(difference > 10)
        //{
        //    Debug.Log("Small fall");
        //}
        isFalling = false;
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
