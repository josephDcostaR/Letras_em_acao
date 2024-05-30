using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManegerPl : MonoBehaviour
{
    [SerializeField] private string proximaFase;
    [SerializeField] private string sairFase;
    
     public void ProximaFase()
    {
        SceneManager.LoadSceneAsync(proximaFase);
    }

      public void SairFase()
    {
        SceneManager.LoadSceneAsync(proximaFase);
    }
    
}
