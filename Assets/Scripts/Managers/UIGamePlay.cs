using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class UIGamePlay : MonoBehaviour
{
    //Displays the high score 
    public TextMeshProUGUI _HighScore;
    //Displays the total score 
    public TextMeshProUGUI _totalScoreText;

    //Reference to this screen "game over" 
    public GameObject _deathScreen;

    public static UIGamePlay Instance;

    private void Start()
    {
        _deathScreen.SetActive(false);
    }

    public void ShowDeathScreen()
    {
        _deathScreen.SetActive(true); 
    }

    public void RestartGame()
    {
        SceneManager.LoadSceneAsync(1); 
    }

    public void UpdateTotalScore()
    {
        _totalScoreText.text = "Score: " + ScoreManager.singleton.GetScore().ToString();
    }

    public void UpdateHighScore()
    {
        _HighScore.text = "High Score: " + ScoreManager.singleton.GetHigh().ToString();
        
    }
}
