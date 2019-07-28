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

    int smallFallCounter;
    int bigFallCounter;

    List<AudioClip> smallFallClips;
    List<AudioClip> bigFallClips;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            if(bigFallCounter < bigFallClips.Count)
            {
                bigFallCounter++;
            }
            else
            {
                bigFallCounter = 0;
            }
            audioSource.clip = bigFallClips[bigFallCounter];
        }
        else if (difference > 20)
        {
            Debug.Log("Medium fall");
            if (smallFallCounter < smallFallClips.Count)
            {
                smallFallCounter++;
            }
            else
            {
                smallFallCounter = 0;
            }
            audioSource.clip = smallFallClips[smallFallCounter];
        }
        audioSource.Play();
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
