using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(this);
            return;
        }
    }

    public void Restart(float time) {
        Invoke("Restart", time);
    }

    public void Restart() {
        SceneManager.LoadScene(0);
    }
}
