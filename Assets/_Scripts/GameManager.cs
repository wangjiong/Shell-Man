using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    public static int BoomPower = 1;

    public static int BoomCount = 1;

    public static bool BoomTime = false;

    //public static int BoomPower = 2;

    //public static int BoomCount = 2;

    //public static bool BoomTime = true;

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
        GameObject.Find("LevelText").GetComponent<Text>().text = "Level:" + Level.level;
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
