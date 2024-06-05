using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro; 

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private int totalScore;
   
    [SerializeField]
    public TextMeshProUGUI _scoreText;

    [SerializeField]
    private int highestScore;

    public UnityEvent<int> OnTotalScoreChange;
    public UnityEvent<int> OnHighScoreChange;

    public static ScoreManager singleton;

    private void Awake()
    {
        singleton = this;
        totalScore = 0;
    }

    private void Start()
    {
        highestScore = PlayerPrefs.GetInt("HSCORE"); //retrieve highest score
        OnHighScoreChange.Invoke(highestScore); 
    }

    public void RegisterHighScore()
    {
        if(totalScore > highestScore)//When get higher score 
        {
            PlayerPrefs.SetInt("HSCORE", totalScore); //save score into PlayerPrefs. 
            highestScore = totalScore;
            OnTotalScoreChange.Invoke(highestScore);
        }
    }

    public void IncreaseScore()
    {
        totalScore += 1;
        OnTotalScoreChange.Invoke(totalScore); 
        _scoreText.text = "Score: " + totalScore.ToString();
    }

    public int GetHigh()
    {
        return highestScore; 
    }

    public int GetScore()
    {
        return totalScore; 
    }
}
