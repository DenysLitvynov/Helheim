using System.Collections;
using UnityEngine;

public class DelaySonido : MonoBehaviour
{
    public AudioClip[] sounds; // Array de AudioClips
    public float timeBetweenSounds = 10.0f; // Tiempo entre sonidos

    [SerializeField] AudioSource audioSource; // AudioSource del GameObject

    void Start()
    {
        // Obtiene el componente AudioSource
        audioSource = GetComponent<AudioSource>();

        // Inicia la corutina para reproducir sonidos indefinidamente
        StartCoroutine(SoundLoopForever());
    }

    // Corutina para reproducir el sonido indefinidamente
    private IEnumerator SoundLoopForever()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenSounds);
            audioSource.clip = sounds[Random.Range(0, sounds.Length)];
            audioSource.Play();
        }
    }
}
