using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalancaController : MonoBehaviour
{
    public Vector3 Pivot;
    private float mult = 40f;
    public bool DebugInfo = false;

    //it could be a Vector3 but its more user friendly
    public bool RotateX = false;
    public bool RotateY = true;
    public bool RotateZ = false;

    void FixedUpdate()
    {
        transform.position += (transform.rotation * Pivot);

        //if (RotateX)
        //    transform.rotation *= Quaternion.AngleAxis(45 * mult * Time.deltaTime, Vector3.right);
        //if (RotateY)
        //    transform.rotation *= Quaternion.AngleAxis(45 * mult * Time.deltaTime, Vector3.up);
        Debug.Log(""+transform.rotation.z);
        if (RotateZ && Input.GetKey(KeyCode.Space) && this.transform.rotation.z * 180 / Mathf.PI < 60f)
        {
            if(this.transform.rotation.z * 180 / Mathf.PI < 12f)
                transform.rotation *= Quaternion.AngleAxis(45 * mult * Time.deltaTime, Vector3.forward);
        }
        else
            while(this.transform.rotation.z * 180 / Mathf.PI > 8f)
                transform.rotation *= Quaternion.AngleAxis(-45 * mult * Time.deltaTime, Vector3.forward);


        transform.position -= (transform.rotation * Pivot);

        if (DebugInfo)
        {
            Debug.DrawRay(transform.position, transform.rotation * Vector3.up, Color.black);
            Debug.DrawRay(transform.position, transform.rotation * Vector3.right, Color.black);
            Debug.DrawRay(transform.position, transform.rotation * Vector3.forward, Color.black);

            Debug.DrawRay(transform.position + (transform.rotation * Pivot), transform.rotation * Vector3.up, Color.green);
            Debug.DrawRay(transform.position + (transform.rotation * Pivot), transform.rotation * Vector3.right, Color.red);
            Debug.DrawRay(transform.position + (transform.rotation * Pivot), transform.rotation * Vector3.forward, Color.blue);
        }
    }
}
