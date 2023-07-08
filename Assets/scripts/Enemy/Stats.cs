using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = System.Random;
public  class Stats
{

    //TODO Try to create stats (helth)

    Random r = new Random();


    public int max_speed = 10;
    public int min_speed = 1;
    public int max_rot = 10;
    public int min_rot = 1;
    public int max_size = 3;
    public int min_size = 1;


    public float helth_per_scale = 100;


    //[HideInInspector]
    public float helth;

   // [HideInInspector]
    public float _speed;

    //[HideInInspector]
    public float _speed_mem;
    
    //[HideInInspector]
    public float _rot;

    //[HideInInspector]
    public float _size;

    public Stats()
    {

        _size = r.Next(min_size, max_size);
        _speed = r.Next(min_speed, max_speed);
        _rot = r.Next(min_rot, max_rot);
        _speed_mem = _speed;
        helth = helth_per_scale * _size / _speed;
    }

}
