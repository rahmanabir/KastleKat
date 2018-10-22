using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileShooter : MonoBehaviour {

	public Rigidbody rockProjectile;
	public Rigidbody castleBlock;
	
	// Update is called once per frame
	void Update () {

    
	
	if(Input.GetButtonDown("Fire1")){

		Rigidbody rock = Instantiate(rockProjectile, transform.position, transform.rotation);
		rock.velocity = transform.TransformDirection(Vector3.forward * 30);
	}
	if(Input.GetButtonDown("Fire2")){

		Vector3 curPos = transform.position;
		Vector3 normPos = curPos.normalized;
		Vector3 newPos = curPos+normPos*-5;

		Rigidbody cblock = Instantiate(castleBlock, newPos, transform.rotation);

	}


	}
}
