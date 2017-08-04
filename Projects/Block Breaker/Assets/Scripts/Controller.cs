using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    [SerializeField]
    private float multiplicador = 10f;
    [SerializeField]
    private float force = 10f;

    void Update () {
        if (Input.GetKey(KeyCode.RightArrow)) {
            //this.transform.position = new Vector3(this.transform.position.x + Time.deltaTime * multiplicador, this.transform.position.y, this.transform.position.z);
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(force, 0f));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //this.transform.position = new Vector3(this.transform.position.x - Time.deltaTime * multiplicador, this.transform.position.y, this.transform.position.z);
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(-force, 0f));
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + Time.deltaTime * multiplicador, this.transform.position.z);
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, force));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - Time.deltaTime * multiplicador, this.transform.position.z);
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -force));
        }
    }
}
