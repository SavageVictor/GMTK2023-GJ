using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateS : MonoBehaviour
{
    public bool GameIsStart = false;

    public bool SoundIsOn = true;
    public bool MusicIsOn = true;

    public int LevelOfDif;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameIsStart = true;
        }
    }

    public void ChangeSoundState()
    {
        SoundIsOn = !SoundIsOn;
    }

    public void ChangeMusicState()
    {
        MusicIsOn = !MusicIsOn;
    }

    public void SetDifToEase()
    {
        LevelOfDif = 0;
    }
    public void SetDifNormal()
    {
        LevelOfDif = 1;
    }
    public void SetDifToHard()
    {
        LevelOfDif = 2;
    }
}
