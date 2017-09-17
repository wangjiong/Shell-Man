using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explosion : MonoBehaviour {
	public static int DIRECTION_LEFT = 1;
	public static int DIRECTION_RIGHT = 2;
	public static int DIRECTION_UP = 3;
	public static int DIRECTION_DOWN = 4;

    public Image Left;
    public Image Right;
    public Image Up;
    public Image Down;

	ExplosionDirection explosionDirectionLeft;
	ExplosionDirection explosionDirectionRight;
	ExplosionDirection explosionDirectionUp;
	ExplosionDirection explosionDirectionDown;

    void Start() {
		explosionDirectionLeft = Left.GetComponent<ExplosionDirection>();
		explosionDirectionRight = Right.GetComponent<ExplosionDirection>();
		explosionDirectionUp = Up.GetComponent<ExplosionDirection>();
		explosionDirectionDown = Down.GetComponent<ExplosionDirection>();

		explosionDirectionLeft.Boom (DIRECTION_LEFT);
		explosionDirectionRight.Boom (DIRECTION_RIGHT);
		explosionDirectionUp.Boom (DIRECTION_UP);
		explosionDirectionDown.Boom (DIRECTION_DOWN);
    }
}