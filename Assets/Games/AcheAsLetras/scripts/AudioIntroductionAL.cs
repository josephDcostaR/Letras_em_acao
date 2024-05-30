using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioIntroductionAL : MonoBehaviour
{
    public AudioSource audioInicial;
    public float delay;
    public float duration;
    #pragma warning disable CS0414
    private bool audioPlayed = false;
    #pragma warning restore CS0414

    private void Start()
    {
        Invoke("PlayAudio", delay);
    }

    private void PlayAudio()
    {
        audioPlayed = true;
        StartCoroutine(PlayAudioAndDeactivate());
    }

    private System.Collections.IEnumerator PlayAudioAndDeactivate()
    {
        audioInicial.gameObject.SetActive(true);
        audioInicial.Play();

        yield return new WaitForSeconds(duration);

        audioInicial.Stop();
        audioInicial.gameObject.SetActive(false);
        audioPlayed = false;
    }
    
}
