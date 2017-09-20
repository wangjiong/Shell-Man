using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	string TAG = "Enemy==";

	int moveDicection = 0;
    int originMoveDicection;

    const int LEFT = 1;
	const int RIGHT = 2;
	const int UP = 3;
	const int DOWN = 4;

	List<int> passTemp =new List<int>();

	float speed = 5f;

    Vector2 originPosition;
    Vector2 nextPosition;

    

    void Start () {
        CalculateAround();
    }

	void Update () {
        // 判断是否移动到下一个位置了
        if (moveDicection == LEFT) {
            float distance = originPosition.x - transform.position.x;
            if (distance >= 2.56f) {
                // 已经移动到左边的一个位置
                transform.position = new Vector2(originPosition.x - 2.56f, transform.position.y);
                CalculateAround();
            }
        } else if (moveDicection == RIGHT) {
            float distance = transform.position.x - originPosition.x;
            Debug.Log(TAG + "RIGHT distance:"+ distance);
            if (distance >= 2.56f) {
                // 已经移动到右边的一个位置
                transform.position = new Vector2(originPosition.x + 2.56f, transform.position.y);
                CalculateAround();
            }
        } else if (moveDicection == UP) {
            float distance = transform.position.y - originPosition.y;
            Debug.Log(TAG + "UP distance:" + distance);
            if (distance >= 2.56f) {
                // 已经移动到上边的一个位置
                transform.position = new Vector2(transform.position.x , originPosition.y + 2.56f);
                CalculateAround();
            }
        } else if (moveDicection == DOWN) {
            float distance = originPosition.y - transform.position.y;
            if (distance >= 2.56f) {
                // 已经移动到下边的一个位置
                transform.position = new Vector2(transform.position.x , originPosition.y - 2.56f);
                CalculateAround();
            }
        } else {
            //CalculateAround();
        }
			
        // 移动
		switch(moveDicection){
		case LEFT:
			transform.Translate (Vector2.left * speed * Time.deltaTime);
			break;
		case RIGHT:
			transform.Translate (Vector2.right * speed * Time.deltaTime);
			break;
		case UP:
			transform.Translate (Vector2.up * speed * Time.deltaTime);
			break;
		case DOWN:
			transform.Translate (Vector2.down * speed * Time.deltaTime);
			break;
		default:
			break;
		}
	}

	// 计算出下一步方向
	private void CalculateAround(){
		Debug.Log (TAG + "CalculateAround");
        originPosition = transform.position;
        originMoveDicection = moveDicection;
        // origin
        int x = (int)((transform.position.x + 1.28f) / 2.56f);
		int y = (int)((transform.position.y + 1.28f) / 2.56f);
		Debug.Log (TAG + "CalculateAround x:" + x + " y:"+y);
		// left
		bool leftPass = IsPass (x - 1 , y);
		// right
		bool rightPass = IsPass (x + 1 , y);
		// up
		bool upPass = IsPass (x, y+1);
		// down
		bool downPass = IsPass (x , y-1);

		// 随机方向
		passTemp.Clear();
		if(leftPass){
			passTemp.Add (LEFT);
		}
		if(rightPass){
			passTemp.Add (RIGHT);
		}
		if(upPass){
			passTemp.Add (UP);
		}
		if(downPass){
			passTemp.Add (DOWN);
		}
		if(passTemp.Count > 0){
            int i = 0;
            for (; i < passTemp.Count; i++) {
                if (passTemp[i] == originMoveDicection) {
                    break;
                }
            }
            if (i >= passTemp.Count) {
                // 1.可选的方向没有之前的方向，那么随机一个
                moveDicection = passTemp[Random.Range(0, passTemp.Count)];
            } else {
                // 2.可选的方向有之前的方向，那么65%用之前的方向
                if (Random.value < 0.65f) {
                    moveDicection = originMoveDicection;
                } else {
                    moveDicection = passTemp[Random.Range(0, passTemp.Count)];
                }
            }
        }
		Debug.Log (TAG + " moveDicection:" + moveDicection);
	}

	private bool IsPass(int x , int y){
		Debug.Log (TAG + "IsPass x:" + x + " y:"+ y);
		// 1.超出地图
		if(x < 0 || y < 0 || x > FloorManager.row -1 || y > FloorManager.col -1){
			Debug.Log (TAG + "1.超出地图");
			return false;
		}
		// 2.墙壁
		if(x%2 == 1 && y%2 ==1){
			Debug.Log (TAG + "2.墙壁");
			return false;
		}
		// 3.箱子
		if(GenerateManager.sBoxsDictionary.ContainsKey(x+"-" + y)){
			Debug.Log (TAG + "3.箱子");
			return false;
		}
        // 4.炸弹
        if (GenerateManager.sShellDictionary.ContainsKey(x + "-" + y)) {
            Debug.Log(TAG + "4.炸弹");
            return false;
        }
        Debug.Log (TAG + "5.OK");
		return true;
	}
}
