using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CopyCamTransform : NetworkBehaviour {

    Camera mainCam;

    // Use this for initialization
    void Start () {
        if (!isLocalPlayer) {
            return;
        }
        //Transform camTrans = GameObject.Find("ARCamera").transform;
        //print(camTrans);
        mainCam = Camera.main.GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer) {
            return;
        }
        transform.position = mainCam.transform.position;
        transform.rotation = mainCam.transform.rotation;
	}
}
