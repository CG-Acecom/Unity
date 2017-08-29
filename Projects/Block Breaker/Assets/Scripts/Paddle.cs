using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;

    private Ball _refBall;

    // Use this for initialization
    void Start () {
        _refBall = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
        if (autoPlay)
        {
            AutoPlay();
        }else
        {
            MoveWithMouse();
        }
    }

    void AutoPlay() {
        Vector3 paddlePos = new Vector3(-1.35f, this.transform.position.y, 0f);
        Vector3 ballPosition=_refBall.transform.position;

        paddlePos.x = Mathf.Clamp(ballPosition.x, 0f, 15f);
        this.transform.position = paddlePos;
    }

    void MoveWithMouse()
    {
        Vector3 paddlePos = new Vector3(-1.35f, this.transform.position.y, 0f);
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 17.15f;

        paddlePos.x = Mathf.Clamp(mousePosInBlocks, -1.35f, 17.15f);
        this.transform.position = paddlePos;
    }
}
