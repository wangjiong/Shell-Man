using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateManager : MonoBehaviour {

    public GameObject Box;
    public GameObject Enemy;
    public GameObject Door;
    public GameObject BoomPower;
    public GameObject BoomCount;
    public GameObject BoomTime;

    public static Dictionary<string, GameObject> sBoxsDictionary = new Dictionary<string, GameObject>();

    public static Dictionary<string, GameObject> sEnemyDictionary = new Dictionary<string, GameObject>();

    public static Dictionary<string, GameObject> sShellDictionary = new Dictionary<string, GameObject>();

    public static List<Shell> sShellTimeList = new List<Shell>();

    void Start() {
        sBoxsDictionary.Clear();
        sEnemyDictionary.Clear();
        sShellDictionary.Clear();
        sShellTimeList.Clear();

        GenerateBoxAndEnemy();
    }

    // 1.生成箱子和敌人
    void GenerateBoxAndEnemy() {
        for (int i = 0; i < FloorManager.row; i = i + 1) {
            for (int j = 0; j < FloorManager.col; j = j + 1) {
                if (i % 2 != 1 || j % 2 != 1) {
                    if (Random.value > 0.3f) {
                        if (!IsPlayerPosition(i, j)) {
                            // 敌人
                            if (Random.value > 0.95f) {
                                GenerateEnemy(i, j);
                            }
                        }
                        continue;
                    }
                    if (!IsPlayerPosition(i, j)) {
                        // 箱子
                        GererateBox(i, j);
                    }
                }
            }
        }
        // 生成特殊的箱子，保护初始位置
        int m = 0;
        int n = FloorManager.col - 3;
        if (!sBoxsDictionary.ContainsKey(m +"-" + n))
        {
            GererateBox(m,n);
        }
        m = 2;
        n = FloorManager.col - 1;
        if (!sBoxsDictionary.ContainsKey(m + "-" + n))
        {
            GererateBox(m, n);
        }

        // 生成门
        List<GameObject> boxs = new List<GameObject>(sBoxsDictionary.Values);
        GameObject g = GameObject.Instantiate(Door, this.transform);
        int index = Random.Range(0, sBoxsDictionary.Count);
        g.transform.position = boxs[index].transform.position;
        // 生成威力
        boxs.RemoveAt(index);
        g = GameObject.Instantiate(BoomPower, this.transform);
        index = Random.Range(0, sBoxsDictionary.Count);
        g.transform.position = boxs[index].transform.position; 
        // 生成个数
        boxs.RemoveAt(index);
        g = GameObject.Instantiate(BoomCount, this.transform);
        index = Random.Range(0, sBoxsDictionary.Count);
        g.transform.position = boxs[index].transform.position;
        // 生成定时器
        boxs.RemoveAt(index);
        g = GameObject.Instantiate(BoomTime, this.transform);
        index = Random.Range(0, sBoxsDictionary.Count);
        g.transform.position = boxs[index].transform.position;
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

        if (i == FloorManager.col - 1 && j == 2)
        {
            return true;
        }
        if (i == FloorManager.col - 3 && j == 0)
        {
            return true;
        }
        return false;
    }

    // 生成敌人
    private void GenerateEnemy(int i, int j) {
        Vector3 position = new Vector3(i * FloorManager.size.x, j * FloorManager.size.y);
        GameObject g = GameObject.Instantiate(Enemy, this.transform);
        g.transform.position = position;
        GenerateManager.sEnemyDictionary.Add(i + "-" + j, g);
    }

    // 生成箱子
    private void GererateBox(int i, int j) {
        Vector3 position = new Vector3(i * FloorManager.size.x, j * FloorManager.size.y);
        GameObject g = GameObject.Instantiate(Box, this.transform);
        g.transform.position = position;
        GenerateManager.sBoxsDictionary.Add(i + "-" + j, g);
    }
}
