using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class spawnCastle_net : NetworkBehaviour {

	public GameObject castle;
    public Transform parent;

	public override void OnStartServer(){

		GameObject castle_instance = Instantiate(castle, transform.position, transform.rotation, parent);
		NetworkServer.Spawn(castle_instance);
        Destroy(this.gameObject, 0.5f);
	}
}
