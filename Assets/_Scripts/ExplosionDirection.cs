using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDirection : MonoBehaviour {
	static string TAG = "ExplosionDirection==";

	RectTransform rectTransform;
	BoxCollider2D boxCollider2D;

	float speed = 0.3f;

	int mDirection;
	bool mIsTrigger;

	public void OnTriggerEnter2D(Collider2D other){
		//Debug.Log (TAG + "OnTriggerEnter2D other:"+ other.tag);
		if(other.CompareTag("Wall")){
			mIsTrigger = true;
		}
	}

	public void Boom(int direction){
		rectTransform = GetComponent<RectTransform>();
		boxCollider2D = GetComponent<BoxCollider2D>();
		mDirection = direction;

		StartCoroutine("Anim");
	}

	IEnumerator Anim() {
		while (rectTransform.sizeDelta.x < 1.28f*3 && rectTransform.sizeDelta.y < 1.28f*3) {
			if (!mIsTrigger) {
				if (mDirection == Explosion.DIRECTION_LEFT) {
					rectTransform.sizeDelta = new Vector2 (rectTransform.sizeDelta.x + speed, rectTransform.sizeDelta.y);

					boxCollider2D.size = new Vector2 (rectTransform.sizeDelta.x, 2f);
					boxCollider2D.offset = new Vector2 (-0.5f * rectTransform.sizeDelta.x, 0);
				} else if (mDirection == Explosion.DIRECTION_RIGHT) {
					rectTransform.sizeDelta = new Vector2 (rectTransform.sizeDelta.x + speed, rectTransform.sizeDelta.y);

					boxCollider2D.size = new Vector2 (rectTransform.sizeDelta.x, 2f);
					boxCollider2D.offset = new Vector2 (0.5f * rectTransform.sizeDelta.x, 0);
				} else if (mDirection == Explosion.DIRECTION_UP) {
					rectTransform.sizeDelta = new Vector2 (2f, rectTransform.sizeDelta.y + speed);

					boxCollider2D.size = new Vector2 (2f, rectTransform.sizeDelta.y);
					boxCollider2D.offset = new Vector2 (0, 0.5f * rectTransform.sizeDelta.y);
				} else if (mDirection == Explosion.DIRECTION_DOWN) {
					rectTransform.sizeDelta = new Vector2 (2f, rectTransform.sizeDelta.y + speed);

					boxCollider2D.size = new Vector2 (2f, rectTransform.sizeDelta.y);
					boxCollider2D.offset = new Vector2 (0, -0.5f * rectTransform.sizeDelta.y);
				}
			}
			yield return null;
		}
		yield return new WaitForSeconds(1);

		GameObject parent = transform.parent.gameObject;
		if(parent!=null){
			Destroy (parent);
		}
	}
}
