using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeletorDeLeveis : MonoBehaviour
{
    [SerializeField] private string level1;
    [SerializeField] private string level2;
    [SerializeField] private string level3;
    [SerializeField] private string sairDoJogo;

    public void ProximaFase01()
    {
        SceneManager.LoadSceneAsync(level1);
    }


    public void ProximaFase02()
    {
        SceneManager.LoadSceneAsync(level2);
    }

    public void ProximaFase03()
    {
        SceneManager.LoadSceneAsync(level3);
    }

    public void SairDoJogo()
    {
        SceneManager.LoadSceneAsync(sairDoJogo);
    }

}

