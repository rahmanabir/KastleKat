using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch_Target : MonoBehaviour {

	public Material hitMaterial;
	

	//public GameObject hitTarget;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			RaycastHit hitInfo;
			if(Physics.Raycast(ray, out hitInfo)){
				//Debug.Log("Object Hit");
				{
					var rig = hitInfo.collider.GetComponent<Rigidbody>();
					if(rig != null){
						rig.GetComponent<MeshRenderer>().material = hitMaterial;
						//rig.AddForceAtPosition(ray.direction * 50f ,hitInfo.point, ForceMode.VelocityChange);
						//print(hitInfo.point);
						this.GetComponent<RockLauncher>().set_raycast_target(hitInfo.point);
					}
					
				}
			}
		}
	}
}
