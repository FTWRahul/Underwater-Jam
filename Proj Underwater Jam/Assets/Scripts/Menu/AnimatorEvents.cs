using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimatorEvents : MonoBehaviour
{
    [SerializeField] MenuButtonController menuButtonController;
    public bool disableOnce;


    void PlaySound(AudioClip sound)
    {
        if (!disableOnce)
        {
            menuButtonController.audioSource.PlayOneShot(sound);
        }
        else
        {
            disableOnce = false;
        }
    }

    public void ButtonPressed()
    {
        menuButtonController.ButtonPressed();
    }
}
