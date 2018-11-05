using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class StoneBlockClass : BlockClass {

	private float damageConstant;
	private int firstcount;
	//initialization
	void Start () {
		originalPos = transform.position;
		// stoneHealth = 100f;
		
		stoneMaxHeatlth = 100f;
		displacementThreshold = 9f;
		rb = GetComponent<Rigidbody>();
		damageConstant = 0.01f; //tune this to control damage upon impact.
		scoreTalier = GameObject.FindGameObjectsWithTag("tallyTool")[0];

		firstcount = 0;

		// tally.setCastleHealth(stoneHealth);
		// tally.setCastleBlockCount(1);

		// print(tally.getCastleHealth());
		// print(tally.getCastleBlockCount());
	}
	
	// Update is called once per frame
	void Update() {
		
		if(firstcount == 0){
			setHealth(100f);
			firstcount = 1;
		}

		destroyLogic();


	}

	void OnCollisionEnter(Collision col){
 
     if(col.relativeVelocity.magnitude > 10){ 


		Vector3 collisionForce = col.impulse / Time.fixedDeltaTime;
		//print(collisionForce); 
		float damageAmmount = damageConstant * collisionForce.magnitude; //impulse based damage 
		 //stoneHealth -= damageAmmount; 
		deductHealth(damageAmmount);
		
		} 
 
 	}


	
}
