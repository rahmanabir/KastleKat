using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameScoreTalier : MonoBehaviour {
	
	private float castleHealth;
	private float maxCastleHealth;  
	private GameObject[] castleBlocks;
	private int castleBlockcount;
	private int debugCount;
	private int orglen; 

	private int firstUpdate;

    private float castleHealthPercent = 0;
    public Slider healthSlider;
    public bool hasWon = false;
    public Transform winCat;


	// Use this for initialization
	void Start () {
		castleBlocks = GameObject.FindGameObjectsWithTag("catblk");
		castleBlockcount = castleBlocks.Length;
		orglen = castleBlockcount;
		debugCount = 0;
		castleHealth = 0;
		firstUpdate = 1;
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
		if(castleBlockcount == 0){
			castleHealth = 0;
			print("Castle-Health: "+castleHealth);
		}
		
		if (firstUpdate == 1){

			maxCastleHealth = castleHealth;
			firstUpdate = 0;
		}

        castleHealthPercent = 100 * (castleHealth / maxCastleHealth);

        print("Castle-Health: " + castleHealthPercent);
        healthSlider.value = castleHealthPercent;
        //print("Max-Castle-Health: "+maxCastleHealth);
        if (castleHealthPercent <= 100 && castleHealthPercent > 75) {
            healthSlider.transform.GetChild(3).gameObject.SetActive(true);
            healthSlider.transform.GetChild(4).gameObject.SetActive(false);
            healthSlider.transform.GetChild(5).gameObject.SetActive(false);
            healthSlider.transform.GetChild(6).gameObject.SetActive(false);
        }
        else if (castleHealthPercent <= 75 && castleHealthPercent > 50) {
            healthSlider.transform.GetChild(3).gameObject.SetActive(false);
            healthSlider.transform.GetChild(4).gameObject.SetActive(true);
            healthSlider.transform.GetChild(5).gameObject.SetActive(false);
            healthSlider.transform.GetChild(6).gameObject.SetActive(false);
        }
        else if (castleHealthPercent <= 50 && castleHealthPercent > 25) {
            healthSlider.transform.GetChild(3).gameObject.SetActive(false);
            healthSlider.transform.GetChild(4).gameObject.SetActive(false);
            healthSlider.transform.GetChild(5).gameObject.SetActive(true);
            healthSlider.transform.GetChild(6).gameObject.SetActive(false);
        }
        else if (castleHealthPercent <= 25 && castleHealthPercent > 0) {
            healthSlider.transform.GetChild(3).gameObject.SetActive(false);
            healthSlider.transform.GetChild(4).gameObject.SetActive(false);
            healthSlider.transform.GetChild(5).gameObject.SetActive(false);
            healthSlider.transform.GetChild(6).gameObject.SetActive(true);
        }
        else GameOver();

	}

    private void GameOver() {
        print("wow gameover health zero");
        if (!hasWon) {
            hasWon = true;
            winCat.gameObject.SetActive(true);
            Invoke("GoToMenu", 3);
        }
    }

    void GoToMenu() {
        SceneManager.LoadScene("Scene_Menu");
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
