using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
[System.Serializable]
public class Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	 
	private float nextFire;

    void Start()
    {
        UpdateBoundary();
        
    }

    void UpdateBoundary()
    {
        Vector2 half = Utils.GetHalfDimensionsInWorldUnits();

        boundary.xMin = -half.x + 0.7f;
        boundary.xMax = half.x - 0.7f;
        boundary.zMin = -half.y+6f;
        boundary.zMax = half.y-2f;
    }
    void Update ()
	{
        #if UNITY_ANDROID
        //Debug.Log("Running on Android Device.");
        if (CrossPlatformInputManager.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
        #else
        Debug.Log("Not running on mobile Device.");
                if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource>().Play ();
		}
        #endif

    }

    void FixedUpdate ()
	{
        #if UNITY_ANDROID
        float moveHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float moveVertical = CrossPlatformInputManager.GetAxis("Vertical");
        #else
        float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
        #endif

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().velocity = movement * speed;
		
		GetComponent<Rigidbody>().position = new Vector3
		(
			Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
		);
		
		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}
}
