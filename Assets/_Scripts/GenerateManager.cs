using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateManager : MonoBehaviour {

    public GameObject Box;
    public GameObject Enemy;

    public static Dictionary<string, GameObject> sBoxsDictionary = new Dictionary<string, GameObject>();

    public static Dictionary<string, GameObject> sEnemyDictionary = new Dictionary<string, GameObject>();

    public static Dictionary<string, GameObject> sShellDictionary = new Dictionary<string, GameObject>();



    void Start () {
        GenerateBoxAndEnemy();
    }

    // 1.生成箱子和敌人
    void GenerateBoxAndEnemy() {
        for (int i = 0; i < FloorManager.row; i = i + 1) {
            for (int j = 0; j < FloorManager.col; j = j + 1) {
                if (i % 2 != 1 || j % 2 != 1) {
                    if (Random.value > 0.3f) {
                        if (!IsPlayerPosition(i, j)) {
                            if (Random.value > 0.95f) {
                                GenerateEnemy(i, j);
                            }
                        }
                        continue;
                    }
                    if (!IsPlayerPosition(i,j)) {
                        GererateBox(i,j);
                    }
                }
            }
        }
    }

    private bool IsPlayerPosition(int j, int i) {
        if (i == FloorManager.col - 2 && j == 0) {
            return true;
        }
        if (i == FloorManager.col - 1 && j == 0) {
            return true;
        }
        if (i == FloorManager.col - 1 && j == 1) {
            return true;
        }
        return false;
    }

    private void GenerateEnemy(int i , int j) {
        Vector3 position = new Vector3(i * FloorManager.size.x, j * FloorManager.size.y);
        GameObject g = GameObject.Instantiate(Enemy, this.transform);
        g.transform.position = position;
        GenerateManager.sEnemyDictionary.Add(i + "-" + j, g);
    }

    private void GererateBox(int i , int j) {
        Vector3 position = new Vector3(i * FloorManager.size.x, j * FloorManager.size.y);
        GameObject g = GameObject.Instantiate(Box, this.transform);
        g.transform.position = position;
        GenerateManager.sBoxsDictionary.Add(i + "-" + j, g);
    }
}
