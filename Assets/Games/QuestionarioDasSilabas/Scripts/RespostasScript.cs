using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespostasScript : MonoBehaviour
{
    public bool isCorreto = false;
    public QuizManager quizManager;
    public Color startColor;
    private void Start()
    {
        startColor = GetComponent<Image>().color;
    }

    public void Resposta()
    {

        if (isCorreto)
        {
            GetComponent<Image>().color = Color.green;
            Debug.Log("Resposta correta");
            quizManager.Correto();
        }
        else
        {
            GetComponent<Image>().color = Color.red;
            Debug.Log("Resposta errada");
            quizManager.Errado();
        }

        if (gameObject.activeInHierarchy) 
        {
            StartCoroutine(RestaurarCorAfterDelay());
        }

    }

      private IEnumerator RestaurarCorAfterDelay()
    {
        yield return null; 

        if (gameObject.activeInHierarchy) 
        {
            RestaurarCor();
        }
    }

    private void RestaurarCor()
    {
        GetComponent<Image>().color = startColor;
    }
}
