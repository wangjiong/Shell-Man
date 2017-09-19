using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	string TAG = "Enemy==";

	int moveDicection = 0;

	const int LEFT = 1;
	const int RIGHT = 2;
	const int UP = 3;
	const int DOWN = 4;

	List<int> passTemp =new List<int>();

	float speed = 3f;

	void Start () {
		Invoke ("Test" , 2);
	}

	bool test = true;
	private void Test(){
		test = false;
	}

	void Update () {
		if(test){
			return;
		};
		Debug.Log (TAG + "Update");
		int x = (int)((transform.position.x + 1.28f) / 2.56f);
		int y = (int)((transform.position.y + 1.28f) / 2.56f);
		Debug.Log (TAG + "Update x:" + x + " y:"+y);
		if( Mathf.Abs(transform.position.x - x*2.56f) < 0.01f && Mathf.Abs(transform.position.y - y*2.56f) < 0.01f){
			CalculateAround ();
		}
			
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
			moveDicection = passTemp[Random.Range(0,passTemp.Count)];
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
		if(FloorManager.sBoxsDictionary.ContainsKey(x+"-" + y)){
			Debug.Log (TAG + "3.箱子");
			return false;
		}
		// 4.炸弹
		Debug.Log (TAG + "4.OK");
		return true;
	}
}
