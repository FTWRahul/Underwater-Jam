using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Properties myProperties;

    public bool camShakeActive;

    //Property to change through other scripts
    public float Trauma
    {
        get
        {
            return myProperties.trauma;
        }
        set
        {
            myProperties.trauma = Mathf.Clamp01(value);
        }
    }

    IEnumerator ShakeCam(Properties inProperties)
    {
        while (true)
        { //shake camera based values
            if (camShakeActive && Trauma > 0)
            {
                inProperties.timeCounter += Time.deltaTime * Mathf.Pow(inProperties.trauma, 0.3f) * inProperties.traumaMult;
                //Vector3 newPosi = GetVector3() * inProperties.traumaMagnitude * Trauma;

                //transform.localPosition = newPosi;

                transform.localRotation = Quaternion.Euler(GetVector3() * Trauma * inProperties.traumaRotMagnitude);
                Trauma -= Time.deltaTime * inProperties.traumaDecay * Trauma;

                if (inProperties.timeCounter > 100)
                {
                    inProperties.timeCounter = 0;
                }
            }
            else
            {
                //set position and rotation back to normal
                //Vector3 newPosi = Vector3.Lerp(transform.localPosition, Vector3.zero, Time.deltaTime);
                //transform.localPosition = newPosi;
                transform.localRotation = Quaternion.Euler(Vector3.zero * inProperties.traumaRotMagnitude);
                inProperties.timeCounter = 0;
            }
            yield return null;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShakeCam(myProperties));
    }

    //Perlin Noise is always better
    float GetFloat(float seed)
    {
        return (Mathf.PerlinNoise(seed, myProperties.timeCounter) - 0.5f) * 2;
    }

    //Random vector3 based on the perlin seed
    Vector3 GetVector3()
    {
        return new Vector3(GetFloat(1), GetFloat(10), GetFloat(20) * myProperties.traumaDepthMagnitude);
    }

    [System.Serializable]
    public class Properties
    {
        [Range(0, 1)]
        public float trauma;
        public float traumaMult = 5f;
        public float traumaMagnitude = .8f;
        public float traumaRotMagnitude = 1f;
        public float traumaDepthMagnitude = 0f;
        public float traumaDecay = 1.2f;
        public float timeCounter;

        public Properties(float trauma, float traumaMult, float traumaMagnitude, float traumaRotMagnitude, float traumaDepthMagnitude, float traumaDecay, float timeCounter)
        {
            this.trauma = trauma;
            this.traumaMult = traumaMult;
            this.traumaMagnitude = traumaMagnitude;
            this.traumaRotMagnitude = traumaRotMagnitude;
            this.traumaDepthMagnitude = traumaDepthMagnitude;
            this.traumaDecay = traumaDecay;
            this.timeCounter = timeCounter;
        }
    }
}
