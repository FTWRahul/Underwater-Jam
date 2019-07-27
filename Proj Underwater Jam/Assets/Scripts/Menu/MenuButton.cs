using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] Animator anim;
    [SerializeField] AnimatorEvents animEvents;
    [SerializeField] int thisIndex;

    private void Start()
    {
        anim = GetComponent<Animator>();
        animEvents = GetComponent<AnimatorEvents>();
    }

    private void Update()
    {
        if(menuButtonController.index == thisIndex)
        {
            anim.SetBool("Selected", true);

            if (Input.GetAxis("Submit") == 1|| Input.GetMouseButton(0))
            {
                anim.SetBool("Pressed", true);
            }
            else if (anim.GetBool("Pressed"))
            {
                anim.SetBool("Pressed", false);
                animEvents.disableOnce = true;
            }
        }
        else
        {
            anim.SetBool("Selected", false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        menuButtonController.index = thisIndex;
    }
}
