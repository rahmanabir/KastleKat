using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameScoreTalier : MonoBehaviour {
	
	private float castleHealth; 
	private GameObject[] castleBlocks;
	private int castleBlockcount;
	private int debugCount;
	private int orglen; 

	// Use this for initialization
	void Start () {
		castleBlocks = GameObject.FindGameObjectsWithTag("catblk");
		castleBlockcount = castleBlocks.Length;
		orglen = castleBlockcount;
		debugCount = 0;
		castleHealth = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		// castleBlocks = GameObject.FindGameObjectsWithTag("catblk");
		// castleBlockcount = castleBlocks.Length;

		// if(castleBlockcount != 0){
		// 	if(castleBlockcount > prev_length){
		// 		orglen = castleBlockcount;
		// 	}
		// 	castleHealth = calulateCastleHealth(castleBlocks);
		// 	prev_length =  castleBlocks.Length;
		// 	}
		// else{
		// 	castleHealth = 0;
		// }
		// if(castleBlockcount == 0){
		// 	castleHealth = 0;
		// 	print("Castle-Health: "+castleHealth);
		// }
		
		print("Castle-Health: "+castleHealth);
		

	}

	// Only should be used during initialization or rarely used if statements
	// usage during update() loop should be avoided
	float calulateCastleHealth(GameObject[] castleBlocks){

		float calHealth = 0f;
		float maxHealth = orglen*100;

		foreach (GameObject castleBlock in castleBlocks){

			//maxHealth += castleBlock.GetComponent<StoneBlockClass>().getMaxHealth();
			calHealth += castleBlock.GetComponent<StoneBlockClass>().getHealth();
    	}

		return 100*calHealth/maxHealth;
	}




	//getter and setter methods
	
	public void setCastleHealth(float health){

		castleHealth = health;
	}


	//adds health to castle health
	public void updateCastleHealth(float health){

		castleHealth += health;
	}

	
	public void setCastleBlockCount(int blk){

		castleBlockcount = blk;
	}


	//adds health to castle health
	public void updateCastleBlockCount(int blk){

		castleBlockcount += blk;
	}

	public float getCastleHealth(){
		return castleHealth;
	}

	public int getCastleBlockCount(){
		return castleBlockcount;
	}

}
