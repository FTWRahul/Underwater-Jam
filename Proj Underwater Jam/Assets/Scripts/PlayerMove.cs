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
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float input = Input.GetAxis("Horizontal");
        rb.AddTorque(new Vector3(0, 0, -input * rotationSpeed * 100 * Time.deltaTime));
        rb.AddForce(new Vector3(input * movementSpeed * 100 * Time.deltaTime, 0, 0));
    }
}
