using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTriggerScript : MonoBehaviour
{
    public AudioManager audioManager;
    public bool boat;
    public bool plane;
    public bool victory;

    public bool geyserLines;
    static bool firstGeyser = true;

    public AudioClip boatAudio;
    public AudioClip victoryAudio;
    public AudioClip planeAudio;

    public GameObject player;

    public static bool isPlayingDialogue;


    private void Start()
    {
        player = FindObjectOfType<PlayerMove>().gameObject;
        audioManager = FindObjectOfType<AudioManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(geyserLines)
            {
                PlayGeysers(other.GetComponent<PlayerMove>().audioSource);
            }
            else
            {
                PlayThoughts(other.GetComponent<PlayerMove>().audioSource);
            }
            isPlayingDialogue = true;
            Invoke("BoolSwitch", 8f);
        }
    }

    void BoolSwitch()
    {
        isPlayingDialogue = false;
    }

    public void PlayGeysers(AudioSource audioSource)
    {
        if(firstGeyser)
        {
            //int random = Random.Range(0, audioManager.randomThoughts.Count);
            audioSource.clip = audioManager.geyserThoughts[0];
            audioManager.geyserThoughts.Remove(audioManager.randomThoughts[0]);
            audioSource.Play();
            firstGeyser = false;
            //Destroy(this);
            return;
        }
        if(Random.value > .95f)
        {
            int random = Random.Range(0, audioManager.randomThoughts.Count);
            audioSource.clip = audioManager.randomThoughts[random];
            audioManager.randomThoughts.Remove(audioManager.randomThoughts[random]);

            audioSource.Play();
            //Destroy(this);
        }
    }

    public void PlayThoughts(AudioSource audioSource)
    {
        if (boat)
        {
            audioSource.clip = boatAudio;
        }
        else if (plane)
        {
            audioSource.clip = planeAudio;
        }
        else if(victory)
        {
            audioSource.clip = victoryAudio;
            FindObjectOfType<PlayerMove>().enabled = false;
            GameManager.gm.GameOver();
        }
        else
        {
            int random = Random.Range(0, audioManager.randomThoughts.Count);
            audioSource.clip = audioManager.randomThoughts[random];
            audioManager.randomThoughts.Remove(audioManager.randomThoughts[random]);
        }
        audioSource.Play();
        Destroy(this);
    }
}