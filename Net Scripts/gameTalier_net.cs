using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class gameTalier_net : NetworkBehaviour {


	private float castleHealth;
	private float maxCastleHealth;  
	
	private GameObject[] castleBlocks;
	private int castleBlockcount;
	private int debugCount;
	private int orglen; 

	private int firstUpdate = -1;
	
	private int look_bool = 1;

    [SyncVar(hook = "healthBarUpdate")]
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

        //Invoke("DoneFinding", 2f);
	}

	void keepLooking(){	
		if(look_bool == 1){
			print("looking for blocks!");
			if(castleHealth != 0){
				look_bool = 0;
				Invoke("DoneFinding", 2f);
			}
		}
    }

    void DoneFinding() {
		firstUpdate = 1;
    }
	
	// Update is called once per frame
	void Update () {
		
		if (!isServer)
        {
            return;
        }

		keepLooking();

		if(castleBlockcount == 0){
			castleHealth = 0;
			print("ZERO");
		}
		
		if (firstUpdate == 1){
            print("FirstUpdate MaxHealth Get");
			maxCastleHealth = castleHealth;
			firstUpdate = 0;
		}
		else if (firstUpdate == 0){

			castleHealthPercent = 100 * (castleHealth / maxCastleHealth);

			print("Maximum: " + maxCastleHealth);
			print("Current: " + castleHealth);
			print("Percent: " + castleHealthPercent);
		}
	}



	void healthBarUpdate(float castleHealthPercent){

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
			else if (castleHealthPercent <= 25 && castleHealthPercent > 5) {
				healthSlider.transform.GetChild(3).gameObject.SetActive(false);
				healthSlider.transform.GetChild(4).gameObject.SetActive(false);
				healthSlider.transform.GetChild(5).gameObject.SetActive(false);
				healthSlider.transform.GetChild(6).gameObject.SetActive(true);
			}
			else if (castleHealthPercent <=5 && castleHealthPercent >= 0) GameOver();
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
