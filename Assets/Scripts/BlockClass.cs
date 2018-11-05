using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BlockClass : MonoBehaviour {

	protected GameObject scoreTalier;

	protected float stoneHealth;
	protected float displacementThreshold;
	protected Vector3 originalPos;
	protected Vector3 curPos;
	protected Vector3 displacementVector;
	protected Rigidbody rb;
	protected float stoneMaxHeatlth;

	// Use this for initialization

	//destroys attached object
	protected void  DstryFunc(){
		Destroy(this.gameObject);
		scoreTalier.GetComponent<gameScoreTalier>().updateCastleBlockCount(-1);
		if(stoneHealth > 0){
			scoreTalier.GetComponent<gameScoreTalier>().updateCastleHealth(-1f*stoneHealth);
		}
	}

	public float getHealth(){

		return stoneHealth;
	}

	public float getMaxHealth(){

		return stoneMaxHeatlth;
	}


	public void setHealth(float health){
		scoreTalier.GetComponent<gameScoreTalier>().updateCastleHealth(health);
		scoreTalier.GetComponent<gameScoreTalier>().updateCastleBlockCount(1);
		stoneHealth =  health;
	}

	public void setMaxHealth(float health){
		stoneMaxHeatlth =  health;
	}

	public void deductHealth(float health){
		
		if(health > stoneHealth){
			scoreTalier.GetComponent<gameScoreTalier>().updateCastleHealth(-1f*stoneHealth);
			stoneHealth = 0;
		}
		else{
			scoreTalier.GetComponent<gameScoreTalier>().updateCastleHealth(-1f*health);
			stoneHealth -=  health;
		}

		// if (health > stoneHealth){
		// 	stoneHealth = 0;
		// }
		// else
		// {
		// stoneHealth -=  health;
		// }
	}


	//consists of multiple conditions which determine if the block 
	//is destroyed or not
	protected void destroyLogic(){

			if(rb.velocity.magnitude > 0){

					curPos = transform.position;
					displacementVector = curPos - originalPos;

					if(displacementVector.magnitude >= displacementThreshold){
						DstryFunc();
					}
				}
					
			else{
				
				originalPos = curPos;
				}

			if(stoneHealth <= 0){
				DstryFunc();
			}

		}

}
