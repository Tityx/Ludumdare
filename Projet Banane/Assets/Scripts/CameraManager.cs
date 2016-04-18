using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {


    Transform J1;
    Transform J2;

	// Use this for initialization
	void Start ()
    {
        J1 = GameObject.Find("J1").transform;
        J2 = GameObject.Find("J2").transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
