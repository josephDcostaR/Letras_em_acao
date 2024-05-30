using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeletorDeLeveisP : MonoBehaviour
{
      [SerializeField] private string retornoFasesP;
    [SerializeField] private string nextLevel1;
    [SerializeField] private string nextLevel2;

     public void RetornoParaFasesP()
    {
         SceneManager.LoadSceneAsync(retornoFasesP);
    }

    public void ProximaFase01()
    {
         SceneManager.LoadSceneAsync(nextLevel1);
    }

    
    public void ProximaFase02()
    {
         SceneManager.LoadSceneAsync(nextLevel2);
    }
}
