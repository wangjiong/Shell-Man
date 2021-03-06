﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDirection : MonoBehaviour {
    static string TAG = "ExplosionDirection==";

    RectTransform rectTransform;
    BoxCollider2D boxCollider2D;

    float speed = 0.3f;

    int mDirection;
    bool mIsTriggerWall;
    bool mIsTriggerBox;
    float power;

    public void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log (TAG + "OnTriggerEnter2D other:"+ other.tag);
        if (other.CompareTag("Wall")) {
            mIsTriggerWall = true;
        } else if (other.CompareTag("Box")) {
            mIsTriggerBox = true; 
            ReCaluatePower();
            Debug.Log(TAG + "OnTriggerEnter2D other:" + other.tag);
            int x = (int)((other.transform.position.x + 1.28f) / 2.56f);
            int y = (int)((other.transform.position.y + 1.28f) / 2.56f);
            string key = x + "-" + y;
            if (GenerateManager.sBoxsDictionary.ContainsKey(key)) {
                GenerateManager.sBoxsDictionary.Remove(key);
            }
            Destroy(other.gameObject);
        } else if (other.CompareTag("Player")) {
            Destroy(other.gameObject);
        } else if (other.CompareTag("Enemy")) {
            Destroy(other.gameObject);
        } else if (other.CompareTag("Shell")) {
            other.gameObject.GetComponent<Shell>().BoomImmediately(true);
            StopCoroutine("Anim");
        }
    }

    // 每次只能炸一个箱子
    private void ReCaluatePower() {
        float count = 1;
        if (mDirection == Explosion.DIRECTION_LEFT || mDirection == Explosion.DIRECTION_RIGHT) {
            count = (rectTransform.sizeDelta.x - 1.28f) / 2.56f + 1;
        } else {
            count = (rectTransform.sizeDelta.y - 1.28f) / 2.56f + 1;
        }
        if (count < GameManager.BoomPower) {
            power = 1.2f + 2.56f * (int)count;
        }
    }

    public void Boom(int direction) {
        rectTransform = GetComponent<RectTransform>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        mDirection = direction;

        StartCoroutine("Anim");
    }

    IEnumerator Anim() {
        power = 1.2f + 2.56f * GameManager.BoomPower;
        while (rectTransform.sizeDelta.x < power && rectTransform.sizeDelta.y < power) {
            if (!mIsTriggerWall) {
                if (mDirection == Explosion.DIRECTION_LEFT) {
                    LeftAndRightPower();
                    boxCollider2D.offset = new Vector2(-0.5f * rectTransform.sizeDelta.x, 0);
                } else if (mDirection == Explosion.DIRECTION_RIGHT) {
                    Debug.Log(TAG + "rectTransform.sizeDelta.x:" + rectTransform.sizeDelta.x);
                    LeftAndRightPower();
                    boxCollider2D.offset = new Vector2(0.5f * rectTransform.sizeDelta.x, 0);
                } else if (mDirection == Explosion.DIRECTION_UP) {
                    upAndDownPower();
                    boxCollider2D.offset = new Vector2(0, 0.5f * rectTransform.sizeDelta.y);
                } else if (mDirection == Explosion.DIRECTION_DOWN) {
                    upAndDownPower();
                    boxCollider2D.offset = new Vector2(0, -0.5f * rectTransform.sizeDelta.y);
                }
            }
            yield return null;
        }
        yield return new WaitForSeconds(1);

        GameObject parent = transform.parent.gameObject;
        if (parent != null) {
            Destroy(parent);
        }
    }

    private void LeftAndRightPower() {
        float leftPower = rectTransform.sizeDelta.x + speed;
        if (leftPower > power) {
            leftPower = power;
        }
        rectTransform.sizeDelta = new Vector2(leftPower, 2);
        boxCollider2D.size = rectTransform.sizeDelta;
    }

    private void upAndDownPower() {
        float leftPower = rectTransform.sizeDelta.y + speed;
        if (leftPower > power) {
            leftPower = power;
        }
        rectTransform.sizeDelta = new Vector2(2, leftPower);
        boxCollider2D.size = rectTransform.sizeDelta;
    }
}
