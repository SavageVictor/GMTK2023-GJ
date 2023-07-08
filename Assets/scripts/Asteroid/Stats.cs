using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = System.Random;
public class Stats : MonoBehaviour
{

    //TODO Try to create stats (health)

    Random r = new Random();


    public bool _isSelected = false;
    public bool _WasSelected = false;

    public int max_speed = 10;
    public int min_speed = 1;
    public int max_rot = 10;
    public int min_rot = 1;
    public int max_size = 3;
    public int min_size = 1;

    public float maxHealth;


    public float helth_per_scale = 100;


    //[HideInInspector]
    public float health;

    // [HideInInspector]
    public float _speed;

    //[HideInInspector]
    public float _speed_mem;

    //[HideInInspector]
    public float _rot;

    //[HideInInspector]
    public float _size;

    public void Awake()
    {
        _size = r.Next(min_size, max_size);
        _speed = r.Next(min_speed, max_speed);
        _rot = r.Next(min_rot, max_rot);
        _speed_mem = _speed;
        health = helth_per_scale * _size;
        maxHealth = health;
    }

    public float GetDamage()
    {
        return _size * (maxHealth + health)/maxHealth * 2;
    }
}