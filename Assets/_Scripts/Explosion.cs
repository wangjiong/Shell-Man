using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explosion : MonoBehaviour {
    public Image Left;
    public Image Right;
    public Image Up;
    public Image Down;

    RectTransform rectTransformLeft;
    RectTransform rectTransformRight;
    RectTransform rectTransformUp;
    RectTransform rectTransformDown;

    float speed = 0.3f;
    void Start() {
        rectTransformLeft = Left.GetComponent<RectTransform>();
        rectTransformRight = Right.GetComponent<RectTransform>();
        rectTransformUp = Up.GetComponent<RectTransform>();
        rectTransformDown = Down.GetComponent<RectTransform>();
        Boom();
    }

    public void Boom() {
        StartCoroutine("Anim");
    }

    IEnumerator Anim() {
        while (rectTransformLeft.sizeDelta.x < 4) {
            rectTransformLeft.sizeDelta = new Vector2(rectTransformLeft.sizeDelta.x + speed, rectTransformLeft.sizeDelta.y);
            rectTransformRight.sizeDelta = new Vector2(rectTransformRight.sizeDelta.x + speed, rectTransformRight.sizeDelta.y);

            rectTransformUp.sizeDelta = new Vector2(rectTransformUp.sizeDelta.x, rectTransformUp.sizeDelta.y + speed);
            rectTransformDown.sizeDelta = new Vector2(rectTransformDown.sizeDelta.x, rectTransformDown.sizeDelta.y + speed);
            yield return null;
        }
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}