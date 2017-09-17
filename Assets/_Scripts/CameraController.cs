using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    static string TAG = "CameraController==";

    public GameObject player;

    private Vector3 offset;

    Vector3 position = new Vector3(0, 0, -10);

    Vector3 pLeftDown = new Vector3();
    Vector3 pRightUp = new Vector3();
    void Start() {
        offset = transform.position - player.transform.position;

        float widthOffset = Camera.main.orthographicSize * Camera.main.aspect - FloorManager.size.x * 3 / 2;
        float heightOffset = Camera.main.orthographicSize - FloorManager.size.y * 3 / 2;

        pLeftDown.x = widthOffset;
        pLeftDown.y = heightOffset;

        pRightUp.x = (FloorManager.row - 1) * FloorManager.size.x - widthOffset;
        pRightUp.y = (FloorManager.col - 1) * FloorManager.size.y - heightOffset;
    }

    void LateUpdate() {
        position.x = Mathf.Clamp((player.transform.position + offset).x, pLeftDown.x, pRightUp.x);
        position.y = Mathf.Clamp((player.transform.position + offset).y, pLeftDown.y, pRightUp.y);
        transform.position = position;
    }
}