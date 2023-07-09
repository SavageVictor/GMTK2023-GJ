using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Spawner;

public class fire_ship : MonoBehaviour
{

    public GameStateS _gameState;

    public Stats_ship _stats_ship;
    public bool CanFire = true;

    public int counter = 0;

    public GameObject fire_point;
    public GameObject bullet;


    public AudioSource aud;
    public AudioClip[] Shoot;

    public float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (_gameState.GameIsStart)
        {
            if (CanFire)
            {
                if (time >= 1 / _stats_ship.ship_fire_speed)
                {
                    Fire();
                    time = 0;
                    counter++;
                }
                else
                {
                    time += Time.deltaTime;
                }

                if (counter == 20)
                {
                    counter = 0;
                    CanFire = false;
                }
            }
            else
            {
                if (time >= _stats_ship.reloding_time)
                {
                    CanFire = true;
                    time = 0;
                }
                else if (!CanFire)
                {
                    time += Time.deltaTime;
                }
            }

        }
    }

   
    private void Fire()
    {

        if(_gameState.SoundIsOn) aud.PlayOneShot(Shoot[UnityEngine.Random.Range(0, Shoot.Length)], 0.5f);
        Instantiate(bullet, fire_point.transform.position, Quaternion.identity);
    }
}
