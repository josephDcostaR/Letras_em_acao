using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private string returnSeletorGame;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pauseGui;
    // Start is called before the first frame update
    public void Return()
    {
         SceneManager.LoadSceneAsync(returnSeletorGame);
    }

    public void AbrirPauseMenu()
    {
        pauseGui.SetActive(true);
    }

    public void FecharPauseMenu()
    {
        pauseGui.SetActive(false);
       
      
        
    }

  
}
