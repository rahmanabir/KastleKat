using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Net;
using System.Net.Sockets;

public class projectileShooter_net : NetworkBehaviour {

	public GameObject rockProjectile;
	public Rigidbody castleBlock;
    public int speed_multiplier = 30;
    bool isShooting = false;

    //public Button shootButt;
    public TextMesh playerName;
    public string localIPAddress;

    void Start () {

        if (!isLocalPlayer) {
            return;
        }
        //shootButt = GameObject.Find("CanvasAR_SP").transform.GetChild(1).GetComponent<Button>();
        //print(shootButt.name);
        //shootButt.onClick.AddListener(CallCmdShootProj);
        var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
        foreach (var ip in host.AddressList) {
            if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) {
                localIPAddress = ip.ToString();
                print(localIPAddress);
                GameObject.Find("CanvasAR_SP").transform.GetChild(2).GetComponent<Text>().text = localIPAddress;
            }            
        }

        playerName = gameObject.transform.GetChild(0).GetComponent<TextMesh>();
        playerName.text = SystemInfo.deviceName;

    }

	
	// Update is called once per frame
	void Update () {

        if(!isLocalPlayer){
            print("Not Local Player");
            return;
        }

        print("Local Player");

        if (Input.GetButtonDown("Fire2")) CmdShootProj();

        if (Input.GetKeyDown(KeyCode.Escape)) {
            GameObject.Find("CanvasAR_SP").GetComponent<SceneMan>().LoadMenu();
        }

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

    void CallCmdShootProj() {
        CmdShootProj();
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
