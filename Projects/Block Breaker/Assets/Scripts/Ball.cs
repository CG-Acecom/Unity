using UnityEngine;

public class Ball : MonoBehaviour {
    [SerializeField]
    private Paddle paddle;

    private bool hasStarted = false;

    private Vector3 paddleToBallVector;
	
    // Use this for initialization
	void Start () {
        paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (!hasStarted)
        {
            this.transform.position = paddle.transform.position + paddleToBallVector;

            if (Input.GetMouseButton(0))
            {
                hasStarted = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
            }
        }
    }
}
