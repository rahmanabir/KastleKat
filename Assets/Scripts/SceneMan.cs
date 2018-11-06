using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour {

	public void LoadCastle() {
        SceneManager.LoadScene("Test_AR");
    }
    public void LoadPhysics() {
        SceneManager.LoadScene("Test_ARphy");
    }
    public void Quit() {
        Application.Quit();
    }
}
