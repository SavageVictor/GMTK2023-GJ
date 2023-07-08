using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink_ship : MonoBehaviour
{
    public Stats_ship _stats_ship;
    public GameObject _ship;

    public bool chargeToBlink = false;

    public float _timeer = 5;
    public float _time;
    
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
            Debug.Log("He try to enter in my collider");
            if (UnityEngine.Random.Range(0, 2) == 0)
            {
                _ship.transform.position = _ship.transform.position + Vector3.up * 5;
            }
            else
            {
                _ship.transform.position =  _ship.transform.position + Vector3.down * 5;
            }

            chargeToBlink = false;
        }
    }

    Vector3 GetRandomPosition(Vector3 a, Vector3 b)
    {
        float t = Random.Range(0f, 1f);
        return Vector3.Lerp(a, b, t);
    }

}
