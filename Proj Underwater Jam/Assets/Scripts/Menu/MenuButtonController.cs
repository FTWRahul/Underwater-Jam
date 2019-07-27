using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonController : MonoBehaviour
{
    public int index;
    [SerializeField] int maxIndex;

    public int activeMenuIndex;
    [SerializeField] bool keyDown;

    public AudioSource audioSource;

    public List<GameObject> panels;

    public GameObject mainMenu_pn;
    public GameObject settings_pn;
    public GameObject credits_pn;
    public GameObject quit_pn;

    private void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Input.GetAxis("Vertical") != 0)
        {
            if (!keyDown)
            {
                if (Input.GetAxis("Vertical") < 0)
                {
                    if (index < maxIndex)
                    {
                        index++;
                    }
                    else
                    {
                        index = 0;
                    }
                }
                else if(Input.GetAxis("Vertical") > 0)
                {
                    if(index > 0)
                    {
                        index--;
                    }
                    else
                    {
                        index = maxIndex;
                    }
                }

                keyDown = true;
            }
        }
        else
        {
            keyDown = false;
        }
    }

    public void PointEnter(int thisIndex)
    {
        index = thisIndex;
    }

    public void ButtonPressed()
    {
        if (activeMenuIndex == 0)
        {
            switch (index)
            {
                case 3: //Quit
                    OpenQuit();
                    break;
                case 2: //credits
                    OpenCredits();
                    break;
                case 1: //settings
                    OpenSettings();
                    break;
                case 0: // play button
                    LoadGame();
                    break;
                default:
                    break;
            }
        }
        else if(activeMenuIndex == 1)
        {
            OpenMain();
        }
        else if(activeMenuIndex == 2)
        {
            OpenMain();
        }
        else if (activeMenuIndex == 3)
        {
            switch (index)
            {
                case 1:
                    CloseGame();
                    break;
                case 0:
                    OpenMain();
                    break;
            }
        }
    }

    void OpenMain()
    {
        panels[activeMenuIndex].SetActive(false);
        panels[0].SetActive(true);
        activeMenuIndex = 0;
    }

    void OpenCredits()
    {
        panels[activeMenuIndex].SetActive(false);
        panels[2].SetActive(true);
        activeMenuIndex = 2;
    }

    void OpenSettings()
    {
        panels[activeMenuIndex].SetActive(false);
        panels[1].SetActive(true);
        activeMenuIndex = 1;
    }

    void OpenQuit()
    {
        panels[activeMenuIndex].SetActive(false);
        panels[3].SetActive(true);
        activeMenuIndex = 3;
    }

    void LoadGame()
    {
        //load scene?
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
