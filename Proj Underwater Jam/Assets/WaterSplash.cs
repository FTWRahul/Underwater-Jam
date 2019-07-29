using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterSplash : MonoBehaviour
{
    public GameObject waterSplash;
    public GameObject canvas;

    public AudioClip sound;

    public void DisableCanvas()
    {
        canvas.SetActive(false);
    }

    public void ActivateSplash()
    {
        waterSplash.SetActive(true);

        GetComponent<AudioSource>().PlayOneShot(sound);
    }

    void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
