using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateS : MonoBehaviour
{
    public bool GameIsStart = false;

    public bool SoundIsOn = true;
    public bool MusicIsOn = true;

    

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
}
