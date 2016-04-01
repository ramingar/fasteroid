using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class LandingSceneStartGame : MonoBehaviour {
	
    public void startGame ()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scene001");
    }
}
