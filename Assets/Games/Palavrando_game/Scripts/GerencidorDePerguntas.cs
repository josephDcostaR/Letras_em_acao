using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GerencidorDePerguntas : MonoBehaviour
{
    public static GerencidorDePerguntas instance;

    [SerializeField] private GameObject gameOver;

    [SerializeField]
    private QuizDataScriptable questionData;
    [SerializeField]
    private Image questionImage;

    [SerializeField]
    private DataPalavras[] anwserWordArray;
    
    [SerializeField]
    private DataPalavras[] optionsWordArray;

    private char[] charArray = new char[12];
    private int currentAnswerIndex = 0;
    private bool correctAnswer = true;
    private List<int> selectedWordIndex;
    private int currentQuestionIndex = 0;

    private GameStatus gameStatus = GameStatus.Playing;
    private string answerWord;
    private int score = 0;

    int totalQuestions; 

    public Text scoreTxt;


    private void Awake() {
        if (instance == null) 
            instance = this;
        else
            Destroy(gameObject);

        selectedWordIndex = new List<int>();
    }

    private void Start() 
    {
        totalQuestions = questionData.questions.Count;
        SetQuestion();
    }
    
    private void SetQuestion()
    {
         currentAnswerIndex = 0;
         selectedWordIndex.Clear();


         questionImage.sprite = questionData.questions[currentQuestionIndex].questionImage;
         answerWord = questionData.questions[currentQuestionIndex].answer;
         

        ResetQuestion();

        for (int i = 0; i <  answerWord.Length; i++)
        {
            charArray[i] = char.ToUpper( answerWord[i]);
        }

        for(int i =  answerWord.Length; i < optionsWordArray.Length; i++)
        {
            charArray[i] = (char)UnityEngine.Random.Range(65,91);
        }

        charArray = ShuffleList.ShuffleListItems<char>(charArray.ToList()).ToArray();

        for (int i = 0; i < optionsWordArray.Length; i++)
        {
            optionsWordArray[i].SetChar(charArray[i]);
        }

        currentQuestionIndex++;
        gameStatus = GameStatus.Playing;
    }

    public void SelectedOption(DataPalavras dataPalavras)
    {
        if(gameStatus == GameStatus.Next || currentAnswerIndex >= answerWord.Length) return;

        selectedWordIndex.Add(dataPalavras.transform.GetSiblingIndex());

        if (currentAnswerIndex < anwserWordArray.Length){
            anwserWordArray[currentAnswerIndex].SetChar(dataPalavras.charValue);
        }
      
        dataPalavras.gameObject.SetActive(false);
        currentAnswerIndex++;

        if(currentAnswerIndex >=  answerWord.Length)
        {
            correctAnswer = true;

            for (int i = 0; i <   answerWord.Length; i++)
            {
                if(char.ToUpper(answerWord[i]) !=  char.ToUpper(anwserWordArray[i].charValue))
                {
                    correctAnswer = false;
                    break;
                }
            }

            if(correctAnswer)
            {
                
                gameStatus = GameStatus.Next;
                score += 1;
                Debug.Log("temos uma resposta correta: " + score);

                if(currentQuestionIndex < questionData.questions.Count)
                {
            
                    Invoke("SetQuestion",0.05f);

                }
                else 
                {
                    gameOver.SetActive(true);
                    scoreTxt.text = score + "/" + totalQuestions;
                }
            }

            
            else if(!correctAnswer)
            {
                Debug.Log("temos uma resposta errada");
            }
        }
    }

    private void ResetQuestion()
    {
        for(int i = 0; i < anwserWordArray.Length; i++)
        {
            anwserWordArray[i].gameObject.SetActive(true);
            anwserWordArray[i].SetChar('_');
        }

           for(int i =  answerWord.Length; i < anwserWordArray.Length; i++)
        {
            anwserWordArray[i].gameObject.SetActive(false);
        }

        for(int i = 0; i < optionsWordArray.Length ; i++)
        {
            optionsWordArray[i].gameObject.SetActive(true);
        }
    }

    public void ResetLastWord()
    {
        if(selectedWordIndex.Count > 0)
        {
            int index = selectedWordIndex[selectedWordIndex.Count - 1];
            optionsWordArray[index].gameObject.SetActive(true);
            selectedWordIndex.RemoveAt(selectedWordIndex.Count - 1);
            currentAnswerIndex--;
            anwserWordArray[currentAnswerIndex].SetChar('_');

        } 
    }

     public void retry()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }

}

[System.Serializable]
public class QuestionData
{
    public Sprite questionImage;
    public string answer;
}

public enum GameStatus
{
    Playing,
    Next
}
