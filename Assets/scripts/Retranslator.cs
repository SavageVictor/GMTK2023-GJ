using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retranslator : MonoBehaviour
{
    public GameStateS _state;
    public AudioSource _source;

    public GameStateS GetGameState()
    {
        return _state;
    }
}
