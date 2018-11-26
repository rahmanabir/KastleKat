using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour {

	public void LoadCastle() {
        SceneManager.LoadScene("Scene_AR");
    }
    public void LoadNoBox() {
        SceneManager.LoadScene("Scene_ARnoBox");
    }
    public void LoadMulti() {
        SceneManager.LoadScene("Scene_MP");
    }
    public void Quit() {
        Application.Quit();
    }
    public void LoadMenu() {
        SceneManager.LoadScene("Scene_Menu");
    }
}
