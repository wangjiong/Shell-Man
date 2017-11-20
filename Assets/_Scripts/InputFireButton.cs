using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputFireButton : MonoBehaviour, IPointerClickHandler/*IPointerEnterHandler, IPointerExitHandler*/
{
    static string TAG = "InputFireButton==";

    public void OnPointerClick(PointerEventData eventData)
    {
        if (PlayerController.instance != null)
        {
            PlayerController.instance.Boom();
        }
    }
}
