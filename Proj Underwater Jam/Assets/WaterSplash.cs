using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSplash : MonoBehaviour
{
    public GameObject waterSplash;

    public void ActivateSplash()
    {
        waterSplash.SetActive(true);
    }
}
