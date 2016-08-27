using UnityEngine;
using System.Collections;

public class PausePlayManager : MonoBehaviour {

    public void PauseGame()
    {
        Time.timeScale = 0.0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
    }
}
