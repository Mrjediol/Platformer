using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioManager;
    public Sound[] sounds;
    public AudioMixerGroup outputGroup;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.mixerGroup;
        }
        if (audioManager == null)
        {
            audioManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Play(string name)
    {

        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
            return;
        s.source.volume = s.volume;
        s.source.pitch = s.pitch;


        s.source.Play();
    }
    public void PlayCorr(string name)
    {
        StartCoroutine(PlayMusic(name, 1));
    }
    public IEnumerator PlayMusic(string name, float fadeDuration)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
            yield break;

        AudioSource source = s.source;

        // Establecer el volumen y pitch del sonido
        source.volume = s.volume;
        source.pitch = s.pitch;

        // Establecer el volumen inicial en cero
        source.volume = 0;

        // Gradualmente aumentar el volumen
        float fadeSpeed = s.volume / fadeDuration;

        while (source.volume < s.volume)
        {
            source.volume += fadeSpeed * Time.deltaTime;
            yield return null;
        }

        // Asegurarse de que el volumen sea el deseado
        source.volume = s.volume;

        // Reproducir el sonido
        source.Play();
    }
   





    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
            return;

        s.source.Stop();
    }
    public void StopCorr(string name)
    {
        StartCoroutine(StopMusic(name, 1));
    }
    public IEnumerator StopMusic(string name, float fadeDuration)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
            yield break;

        AudioSource source = s.source;

        // Obtener el volumen actual del sonido
        float currentVolume = source.volume;

        // Reducir gradualmente el volumen
        float fadeSpeed = currentVolume / fadeDuration;
        Debug.Log(currentVolume + " " + fadeSpeed);
        while (source.volume > 0)
        {
            Debug.Log(currentVolume + " ++ " + fadeSpeed);
            source.volume -= fadeSpeed * Time.deltaTime;
            yield return null;
        }

        // Asegurarse de que el volumen sea cero
        source.volume = 0;

        // Parar el sonido
        source.Stop();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
