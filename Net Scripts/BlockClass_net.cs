using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;



public class BlockClass_net : NetworkBehaviour {

    public GameObject breakParticles;
    protected GameObject scoreTalier;

	[SyncVar]
	public float stoneHealth;
	protected float prevHealth;
	
	protected float displacementThreshold;
	protected Vector3 originalPos;
	protected Vector3 curPos;
	protected Vector3 displacementVector;
	protected Rigidbody rb;
	protected float stoneMaxHeatlth;

	// Use this for initialization

	//destroys attached object
	[Command]
	protected void  CmdDstryFunc(){
        GameObject brickBoom = Instantiate(breakParticles, transform.position, transform.rotation);
		NetworkServer.Spawn(brickBoom);
		Destroy(this.gameObject);

        scoreTalier.GetComponent<gameTalier_net>().updateCastleBlockCount(-1);
		if(stoneHealth > 0){
			scoreTalier.GetComponent<gameTalier_net>().updateCastleHealth(-1f*stoneHealth);
		}
	}

	public float getHealth(){

		return stoneHealth;
	}

	public float getMaxHealth(){

		return stoneMaxHeatlth;
	}


	public void setHealth(float health){
		scoreTalier.GetComponent<gameTalier_net>().updateCastleHealth(health);
		scoreTalier.GetComponent<gameTalier_net>().updateCastleBlockCount(1);
		stoneHealth =  health;
	}

	public void setMaxHealth(float health){
		stoneMaxHeatlth =  health;
	}

	public void deductHealth(float health){
		
		if(health > stoneHealth){
			scoreTalier.GetComponent<gameTalier_net>().updateCastleHealth(-1f*stoneHealth);
			stoneHealth = 0;
		}
		else{
			scoreTalier.GetComponent<gameTalier_net>().updateCastleHealth(-1f*health);
			stoneHealth -=  health;
		}

	}

	
	public void deductHealth_hook(float health){

		float damage = prevHealth - health;
		print("here!!!!!!!!!!!");
		if(damage > prevHealth){
			scoreTalier.GetComponent<gameTalier_net>().updateCastleHealth(-1f*prevHealth);
			
		}
		else{
			scoreTalier.GetComponent<gameTalier_net>().updateCastleHealth(-1f*health);
		}

		prevHealth = health;
	}

	



	//consists of multiple conditions which determine if the block 
	//is destroyed or not
	protected void destroyLogic(){

			if(rb.velocity.magnitude > 0){

					curPos = transform.position;
					displacementVector = curPos - originalPos;

					if(displacementVector.magnitude >= displacementThreshold){
						CmdDstryFunc();
                        print("falling destroy");
					}
				}
					
			else{
				
				originalPos = curPos;
				}

			if(stoneHealth <= 0){
				CmdDstryFunc();
                print("health destroy");
			}

		}

}
