using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputFireButton : MonoBehaviour, IPointerClickHandler/*IPointerEnterHandler, IPointerExitHandler*/
{
    static string TAG = "InputButton==";

    public void OnPointerClick(PointerEventData eventData)
    {
        if (PlayerController.instance != null)
        {
            PlayerController.instance.Boom();
        }

        //public void OnPointerEnter(PointerEventData eventData){
        //    Debug.Log(TAG + "OnPointerEnter type:" + type);
        //    if(PlayerController.instance!=null){
        //        PlayerController.instance.ControlByButton(type);
        //    }
        //}

        //public void OnPointerExit(PointerEventData eventData){
        //    Debug.Log(TAG + "OnPointerExit type:" + type);
        //    if (PlayerController.instance != null){
        //        PlayerController.instance.ControlByButton(0);
        //    }
        //}
    }
}
