using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMusic : MonoBehaviour
{
    public int level;


    private void Start()
    {
        AudioManager.audioManager.PlayCorr(level+ "LevelBgMusic");
    }
}
