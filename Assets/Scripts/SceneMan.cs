using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour {

    public GameObject closerMenu;

    public void LoadCastle() {
        Invoke("InvokeLoadCastle", 1.1f);
        closerMenu.SetActive(true);
    }
    public void LoadNoBox() {
        Invoke("InvokeLoadCastle", 1.1f);
        closerMenu.SetActive(true);
    }
    public void LoadMulti() {
        Invoke("InvokeLoadMulti", 1.1f);
        closerMenu.SetActive(true);
    }
    public void Quit() {
        Application.Quit();
    }
    public void LoadMenu() {
        Invoke("InvokeLoadMenu", 1.1f);
        closerMenu.SetActive(true);
    }

    public void InvokeLoadCastle() {
        SceneManager.LoadScene("Scene_AR");
    }
    public void InvokeLoadNoBox() {
        SceneManager.LoadScene("Scene_ARnoBox");
    }
    public void InvokeLoadMulti() {
        SceneManager.LoadScene("Scene_TestMP");
    }
    public void InvokeLoadMenu() {
        SceneManager.LoadScene("Scene_Menu");
    }
}
