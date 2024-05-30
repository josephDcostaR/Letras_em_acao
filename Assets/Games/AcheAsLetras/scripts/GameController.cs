using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] List<AudioClip> _audioClips;
    public char Letter = 'a';
    int _correctAnswers = 5;
    int _correctClicks;
    
    public static GameController Instance { get; private set; }

    AudioSource _audioSource;

    void Awake()
    {
        Instance = this;
        _audioSource = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        GenerateBoard();
        UpdateDiplayLetters();
    }

    void GenerateBoard()
    {
        var clickables = FindObjectsOfType<ClickedLetter>();

        List<char> charsList = new List<char>();

        for (int i = 0; i < _correctAnswers; i++)
            charsList.Add(Letter);

        for (int i = _correctAnswers; i < clickables.Length; i++)
        {
            var chosenLetter = ChooseInvalidRandomLetter();
            charsList.Add(chosenLetter);
        }

        charsList = charsList
            .OrderBy(t => UnityEngine.Random.Range(0, 10000))
            .ToList();

        for (int i = 0; i < clickables.Length; i++)
        {
            clickables[i].SetLetter(charsList[i]);
        }

        FindObjectOfType<RemainingCouterText>().SetRemaining(_correctAnswers - _correctClicks);
    }

    internal void HandleCorrectLetterClick(bool upperCase)
    {

        _correctClicks++;
        FindObjectOfType<RemainingCouterText>().SetRemaining(_correctAnswers - _correctClicks);
        if (_correctClicks >= _correctAnswers)
        {
            MoveToNextLetter();
            UpdateDiplayLetters();
            _correctClicks = 0;
            GenerateBoard();
        }
    }

    private void MoveToNextLetter()
    {
        Letter++;
        if (Letter > 'z')
        {
            RestartScene();
        }
        
    }

     private void RestartScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(sceneIndex);
    }

    private void UpdateDiplayLetters()
    {
        foreach (var displayletter in FindObjectsOfType<DisplayLetter>())
        {
            displayletter.SetLetter(Letter);
        }
    }

    private char ChooseInvalidRandomLetter()
    {
        int a = UnityEngine.Random.Range(0, 26);
        var randomLetter = (char)('a' + a);

        while (randomLetter == Letter)
        {
            a = UnityEngine.Random.Range(0, 26);
            randomLetter = (char)('a' + a);
        }

        return randomLetter;
    }
}