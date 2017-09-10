using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
[System.Serializable]
public class Boundary 
{
    public GameObject boundary;

    public Vector2 GetXLimits(float a, float b)
    {
        Vector2 half = Utils.GetHalfDimensionsInWorldUnits();
        float x = half.y * 15.0f / 20;
        return new Vector2(-x * a, x * b);
    }

    public Vector2 GetZLimits(float a, float b)
    {
        Vector2 half = Utils.GetHalfDimensionsInWorldUnits();
        return new Vector2(-half.y * a, half.y * b);
    }
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

        Vector2 xlimits = boundary.GetXLimits(12.0f / 15, 12.0f / 15);
        Vector2 zlimits = boundary.GetZLimits(4.0f/20, 10.0f/20);

        GetComponent<Rigidbody>().position = new Vector3
		(
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, xlimits.x, xlimits.y),
            0.0f, 
            Mathf.Clamp (GetComponent<Rigidbody>().position.z, zlimits.x, zlimits.y)
        );
		
		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}
}
