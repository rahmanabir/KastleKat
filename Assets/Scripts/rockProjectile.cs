﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockProjectile : MonoBehaviour {

	private float curSpeed = 0; 
	public float lifetime = 0.2f;

	public int mass = 20;
	//initialization
	void Start () {

		Rigidbody rb = GetComponent<Rigidbody>();
		rb.mass = mass;
	}

	
	// Update is called once per frame
	void Update () {
	
		if(lifetime > 0)
		{
			lifetime -= Time.deltaTime;
		}
		else
		{
			DestryFunc();
		}
	}


	void DestryFunc(){
		Destroy(this.gameObject);
	}

	float getSpeed(){
		return curSpeed;
	}

	void setSpeed(float speed){
		curSpeed = speed;
	}
}
