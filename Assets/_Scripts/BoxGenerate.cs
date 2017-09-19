using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGenerate : MonoBehaviour {

	public FloorManager mFloorManager;

	void Start () {
		mFloorManager.GenerateBox ();
	}

}
