//Script created by Abir Rahman, SpaceKnight Studios 
//This script creates a flight path towards a given target. All calculations regarding this are done here. You might want to brush up on your physics. 


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockLauncher : MonoBehaviour {

    public Rigidbody rock;
    //private Transform target;
    private Vector3 target;
    //protected Transform raycast_target;

    public float sliderMultiplier = 1.0f;


    public float h = 25;    //Max height to be reached by the rock 
    public float gravity = -18; //Gravity value

    public bool debugPath;


    private void Start()
    {
        rock.useGravity = false;
        target = transform.position; 
    }

    public void set_raycast_target(Vector3 ray_target){
        target = ray_target;
    }

    private void Update(){

        if (Input.GetKeyDown(KeyCode.Space)){
            Launch(); 
        }

        if (debugPath == true)
        {
           // DrawPath();
        }
    
    }

    void Launch(){

        Physics.gravity = Vector3.up * gravity;
        
        Rigidbody rocky = Instantiate(rock, transform.position, transform.rotation);

        rocky.useGravity = true; 
        rocky.velocity = CalculateLaunchData(rocky).initailVelocity*sliderMultiplier;
      
        print(rocky.velocity);
    }



    LaunchData CalculateLaunchData(Rigidbody rock) {

                    
       float displacementY = target.y - rock.position.y; //Vertically down displacement : Displacement = Py - h 
       Vector3 displacementXZ = new Vector3(target.x - rock.position.x, 0, target.z - rock.position.z);

        float time = (Mathf.Sqrt(-2 * h / gravity) + Mathf.Sqrt(2 * (displacementY - h) / gravity));


       Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * h);
       Vector3 velocityXZ = displacementXZ / time;

       return new LaunchData (velocityXZ  + velocityY * -Mathf.Sign(gravity), time);
    }


    // void DrawPath()
    // {
    //     LaunchData launchData = CalculateLaunchData();
    //     Vector3 previousDrawPoint = rock.position;


    //     int resolution = 30; 
    //     for (int i = 1; i <= resolution; i++)
    //     {
    //         float simulationTime = i/(float)resolution * launchData.timeToTarget;
    //         Vector3 displacement = (launchData.initailVelocity * simulationTime) + ((Vector3.up *gravity * simulationTime * simulationTime) / 2f); //Third equation of motion, refer to Abirs Notebook Manual
    //         Vector3 drawPoint = rock.position + displacement;
    //         Debug.DrawLine(previousDrawPoint, drawPoint, Color.green);
    //         previousDrawPoint = drawPoint;
    //     }
    // }


    struct LaunchData {

        public readonly Vector3 initailVelocity;
        public readonly float timeToTarget; 

        public LaunchData (Vector3 initialVelocity, float timeToTarget){

            this.initailVelocity = initialVelocity;
            this.timeToTarget = timeToTarget;

        }
    }        

   
}
