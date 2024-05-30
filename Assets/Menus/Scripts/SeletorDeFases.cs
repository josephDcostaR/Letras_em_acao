using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeletorDeFases : MonoBehaviour
{
    [SerializeField] private string main;
    [SerializeField] private string fase_1;
    [SerializeField] private string fase_2;
    [SerializeField] private string fase_3;
    [SerializeField] private string fase_4;
    [SerializeField] private string fase_5;
    [SerializeField] private string fase_6;
    [SerializeField] private string fase_7;
    

     public void Inicio()
    {
        SceneManager.LoadSceneAsync(main);
    }
    
    public void Fase_1()
    {
        SceneManager.LoadSceneAsync(fase_1);
    }

    public void Fase_2()
    {
          SceneManager.LoadSceneAsync(fase_2);
    }

    public void Fase_3()
    {
         SceneManager.LoadSceneAsync(fase_3);
    }
     
     public void Fase_4()
    {
         SceneManager.LoadSceneAsync(fase_4);
    }

    public void Fase_5()
    {
         SceneManager.LoadSceneAsync(fase_5);
    }

     public void Fase_6()
    {
         SceneManager.LoadSceneAsync(fase_6);
    }

    public void Fase_7()
    {
          SceneManager.LoadSceneAsync(fase_7);
    }
    
    
}
