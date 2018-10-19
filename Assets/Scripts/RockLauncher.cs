using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockLauncher : MonoBehaviour {

    public Rigidbody rock;
    public Transform target;

    public float h = 25;    //Max height to be reached by the rock 
    public float gravity = -18; //Gravity value

    public bool debugPath;


    private void Start()
    {
        rock.useGravity = false; 
    }


    private void Update(){

        if (Input.GetKeyDown(KeyCode.Space)){
            Launch(); 
        }

        if (debugPath == true)
        {
            DrawPath();
        }
    
    }

    void Launch(){

        Physics.gravity = Vector3.up * gravity;
        rock.useGravity = true; 
        rock.velocity = CalculateLaunchData().initailVelocity;
        //print(CalculateLaunchVelocity());
    }



    LaunchData CalculateLaunchData() {

                    
       float displacementY = target.position.y - rock.position.y; //Vertically down displacement : Displacement = Py - h 
       Vector3 displacementXZ = new Vector3(target.position.x - rock.position.x, 0, target.position.z - rock.position.z);

        float time = (Mathf.Sqrt(-2 * h / gravity) + Mathf.Sqrt(2 * (displacementY - h) / gravity));


       Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * h);
       Vector3 velocityXZ = displacementXZ / time;

       return new LaunchData (velocityXZ  + velocityY * -Mathf.Sign(gravity), time);
    }


    void DrawPath()
    {
        LaunchData launchData = CalculateLaunchData();
        Vector3 previousDrawPoint = rock.position;


        int resolution = 30; 
        for (int i = 1; i <= resolution; i++)
        {
            float simulationTime = i/(float)resolution * launchData.timeToTarget;
            Vector3 displacement = (launchData.initailVelocity * simulationTime) + ((Vector3.up *gravity * simulationTime * simulationTime) / 2f); //Third equation of motion, refer to Abirs Notebook Manual
            Vector3 drawPoint = rock.position + displacement;
            Debug.DrawLine(previousDrawPoint, drawPoint, Color.green);
            previousDrawPoint = drawPoint;
        }
    }


    struct LaunchData {

        public readonly Vector3 initailVelocity;
        public readonly float timeToTarget; 

        public LaunchData (Vector3 initialVelocity, float timeToTarget){

            this.initailVelocity = initialVelocity;
            this.timeToTarget = timeToTarget;

        }
    }        

   
}
