using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    static string TAG = "PlayerController==";
    public GameObject p_shell;

    float speed = 10;
    Rigidbody2D rb2D;

    public static PlayerController instance;

    void Awake() {
        instance = this;
    }

    void Start() {
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Door")) {
            Level.level++;
            Time.timeScale = 0f;
            GameManager.Instance.Restart(2);
        }
        if (other.CompareTag("Enemy")) {
            Destroy(gameObject);
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)) {
            Boom();
        }
    }

    public void Boom(){
        if (GenerateManager.sShellDictionary.Count > 0){
            return;
        }
        GameObject shell = GameObject.Instantiate(p_shell);

        int x = (int)((transform.position.x + 1.28f) / 2.56f);
        int y = (int)((transform.position.y + 1.28f) / 2.56f);
        Vector2 position = new Vector2(x * 2.56f, y * 2.56f);
        shell.transform.position = position;
        GenerateManager.sShellDictionary[x + "-" + y] = shell;
        StartCoroutine(Boom(shell.GetComponent<Shell>()));
    }

    int buttonType = 0;

    public void ControlByButton(int type) {
        buttonType = type;
    }

    void FixedUpdate() {
        float moveHorizontal = 0; 
        float moveVertical = 0;
#if UNITY_ANDROID
        switch (buttonType)
        {
            case 1:
                moveVertical = 1;
                break;
            case 2:
                moveVertical = -1;
                break;
            case 3:
                moveHorizontal = -1;
                break;
            case 4:
                moveHorizontal = 1;
                break;
            default:
                moveHorizontal = 0;
                moveVertical = 0;
                break;
        }
#else
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
#endif
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2D.velocity = movement * speed;
    }

    IEnumerator Boom(Shell shell) {
        yield return new WaitForSeconds(2);
        shell.Boom();
    }

    void OnDestroy() {
        GameManager.Instance.Restart(2);
    }

}