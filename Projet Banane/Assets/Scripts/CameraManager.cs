using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {


    Transform J1;
    Transform J2;
    float z;
    float x;
    float y;

	// Use this for initialization
	void Start ()
    {
        J1 = GameObject.Find("J1").transform;
        J2 = GameObject.Find("J2").transform;
	}
	
	// Update is called once per frame
	void Update ()
    {

        y = J2.transform.position.y +1.5f;

        if (J1.transform.position.z > J2.transform.position.z)
        {
            z = J2.transform.position.z + (J1.transform.position.z - J2.transform.position.z);
            x = -15 - (J1.transform.position.z - J2.transform.position.z);
            this.transform.position = new Vector3(x, y, z);
        }
        else
        {
            z = J1.transform.position.z + (J2.transform.position.z - J1.transform.position.z);
            x = -15 - (J2.transform.position.z - J1.transform.position.z);
            this.transform.position = new Vector3(x, y, z);
        }

        
	}
}
