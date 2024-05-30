using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
  public List<PerguntasErespostas> per;
  public GameObject[] options;
  public int perguntaAtual;
  public Image imagemDaPergunta;
  public Sprite[] imagensDasPerguntas;
  public TMP_Text perguntaTxt;
  public GameObject quizPanel;
  public GameObject GOPanel;
  public TMP_Text ScoreTxt;
  int totalPerguntas = 0;
  public int score;
  

   private void Start()
   {
      totalPerguntas = per.Count;
      perguntaAtual = 0;
      quizPanel.SetActive(true);
      GOPanel.SetActive(false);
      geradorDePerguntas();
      
   }

   public void GameOver()
   {
     quizPanel.SetActive(false);
     GOPanel.SetActive(true);
     ScoreTxt.text = score + "/" + totalPerguntas;
   }

   public void Correto()
   {
        
        score += 1;
        int imagemIndex = per[perguntaAtual].ImagemIndex;
        per.RemoveAt(perguntaAtual);
        geradorDePerguntas();
        
        if (perguntaAtual < per.Count)
        {
       
         geradorDePerguntas();

        
         per[perguntaAtual].ImagemIndex = imagemIndex;   
        }
        else
        {
   
         GameOver();
        }
   }

   public void Errado()
   {
   if (perguntaAtual >= 0 && perguntaAtual < per.Count)
    {
       per.RemoveAt(perguntaAtual);
    }
     
     geradorDePerguntas();
   }

   void SetRespostas()
   {
     for (int i = 0; i < options.Length; i++)
     {
        options[i].GetComponent<RespostasScript>().isCorreto = false;

        options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = per[perguntaAtual].Respostas[i];

        if (per[perguntaAtual].respostaCorreta == i + 1)
        {
            options[i].GetComponent<RespostasScript>().isCorreto = true;
        }
     }
   }

   void geradorDePerguntas()
   {
      if(per.Count > 0)
      {

         perguntaAtual = Random.Range(0, per.Count);

         perguntaTxt.text = per[perguntaAtual].Pergunta;

         if (per[perguntaAtual].ImagemIndex >= 0 && per[perguntaAtual].ImagemIndex < imagensDasPerguntas.Length)
         {
            imagemDaPergunta.sprite = imagensDasPerguntas[per[perguntaAtual].ImagemIndex];
         }

         else
         {   
            Debug.LogWarning("Índice de imagem inválido para a pergunta atual.");
         }

          SetRespostas(); 
      }

      else
      {
          Debug.Log("Fora das questões");
          GameOver();
      }
   }

   public void retry()
   {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }

}




