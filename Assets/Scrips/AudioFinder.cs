using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFinder : MonoBehaviour
{
    public void PlayCall(string name)
    {
        AudioManager.audioManager.Play(name);
    }
    public void PlayMusicCall(string name)
    {
        AudioManager.audioManager.PlayCorr(name);
    }
    public void StopCall(string name)
    {
        Debug.Log("eh hola");
        AudioManager.audioManager.StopCorr(name);
    }
}
