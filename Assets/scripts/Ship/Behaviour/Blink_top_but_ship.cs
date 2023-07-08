using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Blink_top_but_ship : MonoBehaviour
{
    public Stats_ship _stats_ship;
    public GameObject _ship;
    public GameObject TeleportationEffect;

    public bool chargeToBlink = false;

    public float _timeer = 5;
    public float _time;


    public AudioSource aud;
    public AudioClip[] BlinhClips;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (_time >= _timeer && !chargeToBlink)
        {
            chargeToBlink = true;
            _time = 0;
        }
        else if(!chargeToBlink)
        {
            _time += Time.deltaTime;
        }
    }

    void OnTriggerEnter2D()
    {

        if (chargeToBlink)
        {
            Instantiate(TeleportationEffect, _ship.transform.position, Quaternion.identity);
            Debug.Log("He try to enter in my collider");
            if (UnityEngine.Random.Range(0, 2) == 0)
            {
                _ship.transform.position = _ship.transform.position + Vector3.right * 5f;
            }
            else
            {
                _ship.transform.position =  _ship.transform.position + Vector3.left * 4.5f;
            }


            Instantiate(TeleportationEffect, _ship.transform.position, Quaternion.identity);

            aud.PlayOneShot(BlinhClips[UnityEngine.Random.Range(0, BlinhClips.Length)], 1);

            chargeToBlink = false;
        }
    }

    Vector3 GetRandomPosition(Vector3 a, Vector3 b)
    {
        float t = Random.Range(0f, 1f);
        return Vector3.Lerp(a, b, t);
    }

}
