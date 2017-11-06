using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollCircle : ScrollRect
{
    string TAG = "ScrollCircle==";
    
    protected float mRadius = 0f;

    protected override void Start()
    {
        base.Start();
        //计算摇杆块的半径
        mRadius = (transform as RectTransform).sizeDelta.x * 0.5f;
        Debug.Log(TAG + "mRadius:" + mRadius);

        //float asin = (contentPostion.y / contentPostion.x);

        //Debug.Log(Mathf.Asin(0));
        //Debug.Log(Mathf.Asin(1));
        //print(Mathf.Asin(0.5F));

        print(Mathf.Sin(Mathf.PI));
    }

    public override void OnDrag(UnityEngine.EventSystems.PointerEventData eventData)
    {
        base.OnDrag(eventData);
        var contentPostion = this.content.anchoredPosition;
        //Debug.Log(TAG + "OnDrag contentPostion:" + contentPostion);

        if (contentPostion.magnitude > mRadius)
        {
            contentPostion = contentPostion.normalized * mRadius;
            SetContentAnchoredPosition(contentPostion);
        }

        float x = contentPostion.x;
        float y = contentPostion.y;

        if (x>0 && y>0 && Mathf.Abs(y) / Mathf.Abs(x) > 1 || x<0 && y>0 && Mathf.Abs(y) / Mathf.Abs(x)>1)
        {
            // UP
            print(TAG + "UP");
            PlayerController.instance.ControlByButton(1);
        }
        if (x>0 && y<0 && Mathf.Abs(y) / Mathf.Abs(x) > 1 || x < 0 && y < 0 && Mathf.Abs(y) / Mathf.Abs(x) > 1)
        {
            // DOWN
            print(TAG + "DOWN");
            PlayerController.instance.ControlByButton(2);
        }
        if (x < 0 && y > 0 && Mathf.Abs(y) / Mathf.Abs(x) < 1 || x < 0 && y < 0 && Mathf.Abs(y) / Mathf.Abs(x) < 1)
        {
            // LEFT
            print(TAG + "LEFT");
            PlayerController.instance.ControlByButton(3);
        }
        if (x > 0 && y > 0 && Mathf.Abs(y) / Mathf.Abs(x) < 1 || x > 0 && y < 0 && Mathf.Abs(y) / Mathf.Abs(x) < 1)
        {
            // RIGHT
            print(TAG + "RIGHT");
            PlayerController.instance.ControlByButton(4);
        }

    }


    public override void OnEndDrag(UnityEngine.EventSystems.PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        print(TAG + "OnEndDrag");
        PlayerController.instance.ControlByButton(0);
    }
    
}