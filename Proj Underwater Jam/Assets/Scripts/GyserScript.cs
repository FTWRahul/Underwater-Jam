using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyserScript : MonoBehaviour
{

    [SerializeField]
    float maxForce;
    [SerializeField][Tooltip("How fast the force reaches with max")]
    float forceScale;
    [SerializeField]
    float startForce;
    float forceAdder;
    [SerializeField][Tooltip("Keep it close to the maxForce")]
    float particleWidthFactor;
    [SerializeField][Tooltip("Lower Value = faseter bubbles")]
    float particleSpeedFactor;
    [SerializeField]
    float colliderHeight;
    [SerializeField]
    float colliderWidth;
    BoxCollider boxCollider;

    [SerializeField]
    ParticleSystem particles;
    GameObject particleObj;

    CameraShake camShake;

    public AudioSource airAudio;
    // Start is called before the first frame update
    void Start()
    {
        camShake = FindObjectOfType<CameraShake>();
        forceAdder = startForce;
        SetUpParticles();
        particleObj = transform.GetChild(0).gameObject;
        //particleObj.SetActive(false);
        //enabled = false;

    }

    public void SetUpParticles()
    {
        particles = GetComponentInChildren<ParticleSystem>();
        var main = particles.main;
        main.startLifetime = colliderHeight * 2f;
        main.simulationSpeed = maxForce / particleSpeedFactor;
        main.simulationSpeed = maxForce;
        var shape = particles.shape;
        shape.radius = maxForce / particleWidthFactor;
        var particleCol = particles.collision;
        particleCol.lifetimeLoss = .8f;
        //main.gravityModifier. *= maxForce / 2f;
        //particles.startLifetime = colliderHeight
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.size = new Vector3(colliderWidth, colliderHeight, 2);
        boxCollider.center = new Vector3(0, colliderHeight / 2, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        airAudio.Play();
        StartCoroutine(lerpAudio(0, 0.5f, false));
    }

    private void OnTriggerStay(Collider other)
    {
        if (forceAdder < maxForce)
        {
            forceAdder += forceScale * Time.deltaTime;
        }
        camShake.Trauma += .8f;
        other.GetComponent<ConstantForce>().force = new Vector3(0, forceAdder, 0);
    }

    private void OnTriggerExit(Collider other)
    {
        forceAdder = startForce;
        StartCoroutine(lerpAudio(0.5f,0, true));
        other.GetComponent<ConstantForce>().force = Vector3.zero;
    }

    public IEnumerator lerpAudio(float startValue, float endValue, bool shouldEnd)
    {
        //yield return null;
        float t = 0;
        while(t < 1)
        {
            t += Time.deltaTime;
            airAudio.volume = Mathf.Lerp(startValue, endValue, t);
            yield return new WaitForEndOfFrame();
        }
        if(shouldEnd)
        {
            airAudio.Stop();
        }
    }
}
