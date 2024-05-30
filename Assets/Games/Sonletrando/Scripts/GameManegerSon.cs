using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManegerSon : MonoBehaviour
{
    [SerializeField] private string proximaFase;
    [SerializeField] private string sair;
    
     public void ProximaFase()
    {
        SceneManager.LoadSceneAsync(proximaFase);
    }
    
   public void RetryScene()
   {
        
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);
    }

    public void Sair ()
    {
         SceneManager.LoadSceneAsync(sair);
    }
}
