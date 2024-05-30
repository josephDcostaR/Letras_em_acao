using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class P_Fases : MonoBehaviour
{
    [SerializeField] private string seletor_de_fases;
    [SerializeField] private string P_faseFrutas;
    [SerializeField] private string P_faseAnimais;

    // Start is called before the first frame update
     public void Retorno()
    {
        SceneManager.LoadSceneAsync(seletor_de_fases);
    }

    public void P_Frutas()
    {
        SceneManager.LoadSceneAsync(P_faseFrutas);
    }

    public void P_Animais()
    {
        SceneManager.LoadSceneAsync(P_faseAnimais);
    }
}
