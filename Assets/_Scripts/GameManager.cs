using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    void Awake() {
        Time.timeScale = 1f;
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(this);
            return;
        }
    }

    void Start() {
        GameManager.FindObjectOfType<Text>().text = "Level:" + Level.level;
    }

    float mTime;
    public void Restart(float time) {
        if (this == null) {
            return;
        }
        StopAllCoroutines();
        mTime = time;
        StartCoroutine(Restart());
    }

    IEnumerator Restart() {
        float time = Time.realtimeSinceStartup;
        while (true) {
            yield return null;
            if (Time.realtimeSinceStartup - time > mTime) {
                SceneManager.LoadScene(0);
                break;
            }
        }
    }
}
