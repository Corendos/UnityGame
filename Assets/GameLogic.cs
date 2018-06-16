using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {

	public GameObject panel;

	public float heightToGameOver = -10f; 

	// Use this for initialization
	void Start () {
		panel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < heightToGameOver) {
			panel.SetActive(true);
		}
	}
}
