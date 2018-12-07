using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class projectileShooter_net : NetworkBehaviour {

	public GameObject rockProjectile;
	public Rigidbody castleBlock;
    public int speed_multiplier = 30;
    bool isShooting = false;

    void Start () {
		
        // if(!isLocalPlayer){
        //     Destroy(this);
        //     return;
        // }

	}

	
	// Update is called once per frame
	void Update () {


        if(!isLocalPlayer){
            return;
        }

        if (Input.GetButtonDown("Fire2")) CmdShootProj();

        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("Scene_Menu");

        if (Input.GetKeyDown(KeyCode.F)){
		    Vector3 curPos = transform.position;
		    Vector3 normPos = curPos.normalized;
		    Vector3 newPos = curPos+normPos*-5;

		    Rigidbody cblock = Instantiate(castleBlock, newPos, transform.rotation);
	    }
        
	}

    void NotShooting() {
        isShooting = false;
    }

    [Command]
    public void CmdShootProj() {
        if (!isShooting) {
            isShooting = true;
            GameObject rock = Instantiate(rockProjectile, transform.position, transform.rotation);
            rock.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * speed_multiplier);

            NetworkServer.Spawn(rock);

            Invoke("NotShooting", 1f);
        }
    }

    public void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
