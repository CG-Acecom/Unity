using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {
    public LevelManager levelmanager;

    void OnTriggerEnter2D(Collider2D trigger)
    {
        print("Trigger");
        levelmanager.LoadLevel("Win");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
    }
}
