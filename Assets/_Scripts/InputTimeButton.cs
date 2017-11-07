using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputTimeButton : MonoBehaviour, IPointerClickHandler/*IPointerEnterHandler, IPointerExitHandler*/
{
    static string TAG = "InputTimeButton==";

    public void OnPointerClick(PointerEventData eventData)
    {
        if (PlayerController.instance != null)
        {
            PlayerController.instance.BoomByTime();
        }
    }
}