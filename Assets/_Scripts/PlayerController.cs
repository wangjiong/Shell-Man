using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    static string TAG = "PlayerController==";
    public GameObject p_shell;

    float speed = 10;
    Rigidbody2D rb2D;

    void Start() {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.KeypadEnter)) {
            GameObject shell = GameObject.Instantiate(p_shell);

            int x = (int)((transform.position.x + 1.28f) / 2.56f);
            int y = (int)((transform.position.y + 1.28f) / 2.56f);
            Debug.Log(TAG + "x:"+ x + " y:"+y);
            Vector2 position = new Vector2(x * 2.56f, y * 2.56f);
            shell.transform.position = position;
        }
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2D.velocity = movement * speed;
    }
}