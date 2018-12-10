using UnityEngine;
using UnityEngine.SceneManagement;

public class projectileShooter : MonoBehaviour {

	public Rigidbody rockProjectile;
	public Rigidbody castleBlock;

    bool isShooting = false;
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire2")) ShootProj();

        if (Input.GetKeyDown(KeyCode.Escape)) {
            GetComponent<SceneMan>().LoadMenu();
        }

        if (Input.GetKeyDown(KeyCode.F)){
		    Vector3 curPos = transform.position;
		    Vector3 normPos = curPos.normalized;
		    Vector3 newPos = curPos+normPos*-5;

		    //Rigidbody cblock = Instantiate(castleBlock, newPos, transform.rotation);
	    }
        
	}

    void NotShooting() {
        isShooting = false;
    }

    public void ShootProj() {
        if (!isShooting) {
            isShooting = true;
            Rigidbody rock = Instantiate(rockProjectile, transform.position, transform.rotation);
            rock.velocity = transform.TransformDirection(Vector3.forward * 30);
            Invoke("NotShooting", 1f);
        }
    }

    public void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
