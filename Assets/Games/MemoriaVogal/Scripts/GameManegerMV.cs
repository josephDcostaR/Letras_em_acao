using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManegerMV : MonoBehaviour
{
    [SerializeField] private string sair;
    

    public void Sair ()
    {
         SceneManager.LoadSceneAsync(sair);
    }

    public void Restart()
    {
        SceneManager.LoadScene("MemoriaVogal");
    }
}
