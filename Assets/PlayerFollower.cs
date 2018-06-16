using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour {

	// Use this for initialization
	public GameObject character;

	public float deadZone = 1f;
	void Start () {
		this.transform.Translate(character.transform.position.x - this.transform.position.x, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 delta = this.transform.position - character.transform.position;
		if (Mathf.Abs(delta.x) > deadZone) {
			this.transform.Translate(character.transform.position.x - this.transform.position.x + Mathf.Sign(delta.x) * deadZone, 0, 0);
		}
	}
}
