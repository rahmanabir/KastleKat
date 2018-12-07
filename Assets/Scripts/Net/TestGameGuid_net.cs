using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TestGameGuid_net : NetworkBehaviour {

	float speed = 5;
	
	void start(){		
		
		// if (isLocalPlayer)
        // {
        //         GameObject.Find("Main Camera").gameObject.transform.parent = this.transform;
        //     }
        
	}

	// Update is called once per frame
	void FixedUpdate () {


		if(!isLocalPlayer){
			return;
        }


		Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Fly"), Input.GetAxisRaw("Vertical"));
		Vector3 direction = input.normalized;

		Vector3 moveMultiple =  direction*speed*Time.deltaTime;

		transform.Translate(moveMultiple);

		Camera mainCam = Camera.main.GetComponent<Camera>();
		
		mainCam.transform.position = transform.position;
		mainCam.transform.rotation = transform.rotation;

	}
}
