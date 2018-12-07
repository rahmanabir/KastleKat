using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class StoneBlockClass_net : BlockClass_net {

	private float damageConstant;
	private int firstcount;

	public int mass;
	public int maxHealth;

	//initialization
	void Start () {
		originalPos = transform.position;
		// stoneHealth = 100f;
		
		stoneMaxHeatlth = maxHealth;
		displacementThreshold = 29f;
		rb = GetComponent<Rigidbody>();
		rb.mass = mass;
		damageConstant = 0.01f; //tune this to control damage upon impact.
        scoreTalier = GameObject.FindGameObjectWithTag("tallyTool");
		prevHealth = maxHealth;
		firstcount = 0;


		// tally.setCastleHealth(stoneHealth);
		// tally.setCastleBlockCount(1);

		// print(tally.getCastleHealth());
		// print(tally.getCastleBlockCount());
	}
	
	// Update is called once per frame
	void Update() {
		
		if (!isServer)
        {
            return;
        }


		if(firstcount == 0){
			print("setting Health!");
			setHealth(maxHealth);
			firstcount = 1;
		}

		destroyLogic();
	}

	
	void OnCollisionEnter(Collision col){
		
		if (!isServer)
        {
            return;
        }

        if(col.relativeVelocity.magnitude > 10){ 
            Vector3 collisionForce = col.impulse / Time.fixedDeltaTime;
            //print(collisionForce); 
            float damageAmmount = damageConstant * collisionForce.magnitude/(0.05f*mass); //impulse based damage 
            //stoneHealth -= damageAmmount; 
            deductHealth(damageAmmount);
        } 
 
 	}


	
}
