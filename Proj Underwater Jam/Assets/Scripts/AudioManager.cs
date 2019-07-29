using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    public List<AudioClip> randomThoughts;

    public List<AudioClip> geyserThoughts;

    public AudioSource source;

    public AudioClip firstBoi;
    public AudioClip secondBoi;

    private void Start()
    {
        StartCoroutine(StartingSqeuence());
    }

    IEnumerator StartingSqeuence()
    {
        source.clip = firstBoi;
        source.Play();
        yield return new WaitForSeconds(8f);
        GetComponent<PlayerMove>().enabled = true;
        source.clip = secondBoi;
        source.Play();

    }
}
