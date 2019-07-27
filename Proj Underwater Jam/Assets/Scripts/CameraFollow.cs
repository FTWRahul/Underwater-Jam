using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject targetPlayer;
    public Vector3 offset;
    public float speed = .05f;
    Rigidbody targetRb;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 5, -20);
        targetRb = targetPlayer.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(targetRb.velocity.y < -10)
        {
            speed = 0.15f;
        }
        else
        {
            speed = 0.05f;
        }
        transform.position += (targetPlayer.transform.position + offset - transform.position) * speed;
    }
}
