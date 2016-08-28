using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private const string MAX_SCORE = "MaxScore";

    private float score = 0.0f;
    private bool playing = true;
    public GameObject diePanel;

	void Start () {
	    
	}
	
	void Update () {
        if (playing)
        {
            score += 1000 * Time.deltaTime;
        }
	}

    public void GameOver()
    {
        playing = false;
        diePanel.SetActive(true);
        Text scoreValue = GameObject.Find("ScoreValue").GetComponent<Text>();
        Text maxScoreValue = GameObject.Find("MaxScoreValue").GetComponent<Text>();

        scoreValue.text = ((int)score) + "";

        int maxScore = 0;
        if (PlayerPrefs.HasKey(MAX_SCORE))
        {
            maxScore = PlayerPrefs.GetInt(MAX_SCORE);
        }
        if (score > maxScore)
        {
            maxScore = (int)score;
            PlayerPrefs.SetInt(MAX_SCORE, maxScore);
        }

        maxScoreValue.text = maxScore + "";
    }
}
