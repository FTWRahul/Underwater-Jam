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

    public void LoadMenu()
    {
        //load mainMenu there
    }

    public void ButtonPressed()
    {
        switch (menuButtonController.index)
        {
            case 3: //Quit
                CloseGame();
                break;
            case 2: //credits
                break;
            case 1: //settings
                break;
            case 0: // play button
                LoadGame();
                break;
            default:
                break;
        } 
    }

    public void LoadGame()
    {
       //Load scene
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
