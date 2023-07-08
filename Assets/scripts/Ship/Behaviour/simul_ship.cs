using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class simul_ship : MonoBehaviour
{
    public Slider _slider;
    
    private Stats_ship _stats_ship;
    private Stats enemyStats;
    // Start is called before the first frame update
    void Start()
    {
        _stats_ship = GetComponent<Stats_ship>();
        _slider.maxValue = _stats_ship.Max_Helth;
        _slider.value = _stats_ship.Max_Helth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

/*    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Sempi entered on my collider");
    }*/

    void OnTriggerEnter2D()
    {
       // Debug.Log("Sempi entered on my collider");
        TakeDamage(10); //TODO Fix damage
    }

    private void TakeDamage(float damage)
    {
        _stats_ship.helth -= damage;
        //_stats_ship.helth -= enemyStats.GetDamage();
        _slider.value = _stats_ship.helth;
    }
}
