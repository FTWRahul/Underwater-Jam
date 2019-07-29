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

    public Animator animBackground;

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
                        index = 1;
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

    public void PointExit()
    {
        index = 0;
    }

    public void ButtonPressed()
    {
        if (activeMenuIndex == 0)
        {
            switch (index)
            {
                case 4:
                    OpenQuit();
                    break;
                case 3: 
                    OpenCredits();
                    break;
                case 2: 
                    OpenSettings();
                    break;
                case 1:
                    animBackground.SetTrigger("Play");
                    break;
                default:
                    break;
            }
        }
        else if(activeMenuIndex == 1)
        {
            if (index == 1)
            {
                OpenMain();
            }
        }
        else if(activeMenuIndex == 2)
        {
            if (index == 1)
            {
                OpenMain();
            }
        }
        else if (activeMenuIndex == 3)
        {
            switch (index)
            {
                case 2:
                    CloseGame();
                    break;
                case 1:
                    OpenMain();
                    break;
                default:
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

    public void CloseGame()
    {
        Application.Quit();
    }
}
