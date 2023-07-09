using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Blink_ship : MonoBehaviour
{
    public Stats_ship _stats_ship;
    public GameObject _ship;
    public GameObject TeleportationEffect;

    public bool isSideDodge;
    
    public string frontDodge = "FB-CLD ";

    public TextMeshProUGUI culdownOutput; 

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
        if (_time <= 0 && !chargeToBlink)
        {
            culdownOutput.text = $"FB-CLD R";
            chargeToBlink = true;
            _time = _timeer;
        }
        else if(!chargeToBlink)
        {
            _time -= Time.deltaTime;
            culdownOutput.text = $"FB-CLD {_time.ToString("0")} ";
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
                _ship.transform.position = _ship.transform.position + Vector3.up * 4.5f;
            }
            else
            {
                _ship.transform.position =  _ship.transform.position + Vector3.down * 4.5f;
            }


            Instantiate(TeleportationEffect, _ship.transform.position, Quaternion.identity);

            aud.PlayOneShot(BlinhClips[UnityEngine.Random.Range(0, BlinhClips.Length)], 0.5f);

            chargeToBlink = false;
        }
    }

    Vector3 GetRandomPosition(Vector3 a, Vector3 b)
    {
        float t = Random.Range(0f, 1f);
        return Vector3.Lerp(a, b, t);
    }

}
