using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	// Use this for initialization

	Rigidbody r;

	void Start () {
		r = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		r.AddTorque(1f, 2f, 3f);
	}
}
