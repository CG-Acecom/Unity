using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCollider : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D trigger)
    {
        print("Trigger");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
        SceneManager.LoadScene("Win");
    }
}
