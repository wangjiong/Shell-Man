using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour {
    static string TAG = "FloorManager==";
    public GameObject Wall01;
    public GameObject Wall02;
	public GameObject Floor;

    public static Vector2 size = new Vector2(2.56f, 2.56f);

	// 这个row和col搞反了
    public const int row = 25;
	public const int col = 15;

	
    //int row = 5;
    //int col = 5;

    void Start() {
        //Debug.Log(TAG + "Floor height:" + (col+2)* size.x +" width:" + (row + 2) * size.x);
        GenerateFloor();
        GenerateWall();
    }

    private void GenerateFloor() {
        for (int i = 0; i < row; i++) {
            for (int j = 0; j < col; j++) {
                Vector3 position = new Vector3(i * size.x, j * size.y);
                GameObject g = GameObject.Instantiate(Floor, this.transform);
                g.transform.position = position;
            }
        }
    }

    private void GenerateWall() {
        // 上
        for (int i = -1; i <= row; i++) {
            Vector3 position = new Vector3(i * size.x, size.y * col);
            GameObject g = GameObject.Instantiate(Wall01, this.transform);
            g.transform.position = position;
        }
        // 下
        for (int i = -1; i <= row; i++) {
            Vector3 position = new Vector3(i * size.x, -size.y);
            GameObject g = GameObject.Instantiate(Wall01, this.transform);
            g.transform.position = position;
        }
        // 左
        for (int i = 0; i < col; i++) {
            Vector3 position = new Vector3(-size.x, size.y * i);
            GameObject g = GameObject.Instantiate(Wall01, this.transform);
            g.transform.position = position;
        }
        // 右
        for (int i = 0; i < col; i++) {
            Vector3 position = new Vector3(size.x * row, size.y * i);
            GameObject g = GameObject.Instantiate(Wall01, this.transform);
            g.transform.position = position;
        }
        // 中间
        for (int i = 1; i < row; i = i + 2) {
            for (int j = 1; j < col; j = j + 2) {
                Vector3 position = new Vector3(i * size.x, j * size.y);
                GameObject g = GameObject.Instantiate(Wall02, this.transform);
                g.transform.position = position;
            }
        }
    }
}
