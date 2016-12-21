using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class ButtonClickScript : MonoBehaviour {

	public void ClickStart()
    {
        SceneManager.LoadScene("Game");
    }
    public void ClickQuit()
    {
        Application.Quit();
    }
}
