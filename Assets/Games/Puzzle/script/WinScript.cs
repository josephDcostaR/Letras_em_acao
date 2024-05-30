using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinScript : MonoBehaviour
{
     public static WinScript instance;
    private int pointsToWin;
    private int currentPoints;
    public GameObject myItens;
    public GameObject WinGui;

    private int _score;
    [SerializeField] private TMP_Text Score;
    [HideInInspector] public bool hasWon = false;

    private bool isFirstLevel = false;
    private bool isSecundLevel = false;
    private string currentSceneName;

    void Start()
    {
        
        pointsToWin = myItens.transform.childCount;
         
        _score = PlayerPrefs.GetInt("Score", 0);

        isFirstLevel = SceneManager.GetActiveScene().buildIndex == 11;
        isSecundLevel = SceneManager.GetActiveScene().buildIndex == 18;
        if (isFirstLevel || isSecundLevel)
        {
            _score = 0;
            PlayerPrefs.SetInt("Score", _score);
            PlayerPrefs.Save();
        }

        UpdateScoreUI();
        Debug.Log(PlayerPrefs.GetInt("Score"));

        currentSceneName = SceneManager.GetActiveScene().name;
    }


    void Update()
    {
        if (!hasWon && currentPoints >= pointsToWin)
            {
                  
                hasWon = true;
                _score++;
                Score.text = "Pontuação: " + _score.ToString();
                WinGui.SetActive(true);

                PlayerPrefs.SetInt("Score", _score);
                PlayerPrefs.Save();
            }
    }

    public void AddPoints()
    {    
        currentPoints++;
        UpdateScoreUI();
    }

    
     private void UpdateScoreUI()
    {
        Score.text = "Pontuação: " + _score.ToString();
    }

    
    public void RetryScene()
    {
        
        if (SceneManager.GetActiveScene().name == currentSceneName)
        {
            _score--; 
            PlayerPrefs.SetInt("Score", _score);
            PlayerPrefs.Save();
            Score.text = "Pontuação: " + _score.ToString();
        }
     
        SceneManager.LoadScene(currentSceneName);
    }
}
