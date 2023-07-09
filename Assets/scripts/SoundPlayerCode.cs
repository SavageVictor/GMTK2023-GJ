using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayerCode : MonoBehaviour
{
    public GameStateS _state;

    public AudioSource AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_state.SoundIsOn)
        {
            AudioSource.volume = 0;
        }
        else
        {
            AudioSource.volume = 1;
        }
    }
}
