using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGameGuide : MonoBehaviour {

	float speed = 5;

	// // Use this for initialization
	// void Start () {
		
	// }
	
	// Update is called once per frame
	void Update () {
		Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Fly"), Input.GetAxisRaw("Vertical"));
		Vector3 direction = input.normalized;

		Vector3 moveMultiple =  direction*speed*Time.deltaTime;

		transform.Translate(moveMultiple);
	}
}
