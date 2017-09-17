using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour {
    public GameObject explosion;

    Canvas canvas;
    void Start() {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        Invoke("Boom", 2f);
    }

    public void Boom() {
        Destroy(this.gameObject);
        GameObject g = Instantiate(explosion, canvas.GetComponent<RectTransform>());
        RectTransform rectTransform = g.GetComponent<RectTransform>();
        rectTransform.localPosition = transform.position;
    }
}