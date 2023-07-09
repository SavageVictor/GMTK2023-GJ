using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;


public class Metior_behaviour : MonoBehaviour
{/*
    public Slider _slider;
    public GameObject _sliderObj;
*/
    public GameStateS state = null;
    //public Retranslator ret;
    public GameObject ImpactExplosion;

    public Move camObj;
    public Stats _stats;
    

    public int camDethBorder = 10;

    private Vector3 topRight;
    private Vector3 topLeft;
    private Vector3 bottomRight;
    private Vector3 bottomLeft;

    private float Timer = 1;
    private float time = 0;

    public AudioSource colis;
    public AudioClip[] babch1;

    // Start is called before the first frame update
    void Awake()
    {


      
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (state == null)
        {
            state = (GameStateS)GetComponentInParent<Retranslator>()._state;
        }
        topRight = camObj.cam.ScreenToWorldPoint(new Vector3(camObj.cam.pixelWidth, camObj.cam.pixelHeight,
            camObj.cam.nearClipPlane));
        bottomLeft = camObj.cam.ScreenToWorldPoint(new Vector3(0, 0, camObj.cam.nearClipPlane));
        amIDead();

        if (state.SoundIsOn)
        {
            colis.volume = 1;
        }
        else
        {
            colis.volume = 0;
        }
    }

    private void amIDead()
    {
        if (time <= 0)
        {
            if (transform.position.x > bottomLeft.x + camDethBorder ||
                transform.position.x < topRight.x - camDethBorder / 2 ||
                transform.position.y > topRight.y + (camDethBorder / 2) ||
                transform.position.y < bottomLeft.y - (camDethBorder / 2)
               )
            {
                Deth();
            }

            if (_stats.health <= 0)
            {
                Deth();
            }

            time = Timer;
        }
        else
        {
            time -= Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
     
           colis.PlayOneShot(babch1[UnityEngine.Random.Range(0, babch1.Length)], _stats._size/10);
        
        if (coll.tag == "asteroid")
        {
            _stats.health -= 10;
        }

        if (coll.tag == "Player")
        {
            //coll.collider.SendMessage("TakeDamage", _stats.GetDamage()); 
            Deth();
        }

        if (coll.tag == "bullet")
        {
            
        }
    //  _slider.value = _stats.health;
    }

    void TakeDamage(int damage)
    {
        _stats.health -= damage;
    }

    public void Deth()
    {
        // Instantiate ImpactExplosion
        GameObject explosionInstance = Instantiate(ImpactExplosion, gameObject.transform.position, Quaternion.identity);

        // Match the scale of the parent gameObject
        explosionInstance.transform.localScale = gameObject.transform.localScale;

        // Destroy the parent object
        Destroy(gameObject);
    }



}
