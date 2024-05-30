using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Minigames_Controller : MonoBehaviour
{
   [SerializeField] private string exit_for_minigames;
    [SerializeField] private string play;
    [SerializeField] private string how_To_Play;

    // Start is called before the first frame update
     public void Return()
    {
        SceneManager.LoadSceneAsync( exit_for_minigames);
    }

    public void Play()
    {
        SceneManager.LoadSceneAsync(play);
    }

    public void How_To_Play()
    {
        SceneManager.LoadSceneAsync(how_To_Play);
    }
}
