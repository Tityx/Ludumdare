using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {


    Transform J1;
    Transform J2;
    float z;
    float x;

	// Use this for initialization
	void Start ()
    {
        J1 = GameObject.Find("J1").transform;
        J2 = GameObject.Find("J2").transform;
	}
	
	// Update is called once per frame
	void Update ()
    {

        if(J1.transform.position.z > J2.transform.position.z)
        {
            z = J2.transform.position.z + (J1.transform.position.z - J2.transform.position.z);
            x = -15 - (J1.transform.position.z - J2.transform.position.z);
            this.transform.position = new Vector3(x, 4.9f, z);
        }
        else
        {
            z = J1.transform.position.z + (J2.transform.position.z - J1.transform.position.z);
            x = -15 - (J2.transform.position.z - J1.transform.position.z);
            this.transform.position = new Vector3(x, 4.9f, z);
        }

        
	}
}
