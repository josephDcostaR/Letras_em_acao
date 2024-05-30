using UnityEngine;

public class AudioStart : MonoBehaviour
{
    public AudioSource audioInicial;
    public float delay;
    public float duration;
    private bool audioPlayed = false;

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

    public void StartAudioPlayback()
    {
        if (!audioPlayed)
        {
            PlayAudio();
        }
    }
}
