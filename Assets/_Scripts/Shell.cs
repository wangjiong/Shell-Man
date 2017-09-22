using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour {
    public GameObject explosion;

    Canvas canvas;
    void Start() {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }

	public void OnTriggerExit2D(Collider2D other) {
		if(other.CompareTag("Player")){
			GetComponent<BoxCollider2D> ().isTrigger = false;
		}
	}

    public void Boom() {
        Destroy(this.gameObject);
        GameObject g = Instantiate(explosion, canvas.GetComponent<RectTransform>());
        RectTransform rectTransform = g.GetComponent<RectTransform>();
        rectTransform.localPosition = transform.position;

        int x = (int)((transform.position.x + 1.28f) / 2.56f);
        int y = (int)((transform.position.y + 1.28f) / 2.56f);
        string key = x + "-" + y;
        if (GenerateManager.sShellDictionary.ContainsKey(key)) {
            GenerateManager.sShellDictionary.Remove(key);
        }
    }
}