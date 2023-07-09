using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class music : MonoBehaviour
{
    public GameStateS _state;

    public AudioSource aud;
    public AudioClip[] soundTrack;

    private int next;
    private int prev;
    private bool isPlay = false;

    private float time;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (_state.MusicIsOn)
        {
            aud.volume = 1f;
        }
        else
        {
            aud.volume = 0f;
        }
        PlayMusic();
    }

    void PlayMusic()
    {
        if (!isPlay)
        {
            do
            {
                next = UnityEngine.Random.Range(0, soundTrack.Length);
            } while (next == prev);

            aud.PlayOneShot(soundTrack[next], 0.1f);
            isPlay = true;
        }
        else
        {
            if (time >= soundTrack[next].length)
            {
                isPlay = false;
                prev = next;
                time = 0;
            }
            else
            {
                time += Time.deltaTime;
            }
        }
    }

}
