using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class simul_ship : MonoBehaviour
{
    public Slider _slider;

    public GameObject ParentGameObject;
    public GameObject explosionEffect; 
    public GameObject destoyedParts;

    public GameStateS _gameState;

    public int numberOfExplosions = 5; 
    public float explosionDelay = 0.5f; 
    public float explosionRadius = 1f;

    private bool isNotDying = true;

    private Stats_ship _stats_ship;
    private Stats enemyStats;


    public AudioSource aud;
    public AudioClip[] DeathSound;


    // Start is called before the first frame update
    void Start()
    {
        _stats_ship = GetComponent<Stats_ship>();
        _slider.maxValue = _stats_ship.Max_Helth;
        _slider.value = _stats_ship.Max_Helth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_stats_ship.helth <= 0 && isNotDying)
        {
            Destroyed();
        }
    }

/*    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Sempi entered on my collider");
    }*/

    void OnTriggerEnter2D(Collider2D collider)
    {
       // Debug.Log("Sempi entered on my collider");
       if (collider.tag == "asteroid")
       {    
           TakeDamage(collider.GetComponent<Stats>().GetDamage()); //TODO Fix damage

           _stats_ship.ScoreUpdate(-5);
            //Debug.Log("Sempi entered on my collider");
        }
       else if (collider.tag == "oil")
       {
           _stats_ship.helth += 25;
           if (_stats_ship.helth > 100)
           {
               _stats_ship.helth = 100;
           }

           _stats_ship.ScoreUpdate(25);
       }

       _slider.value = _stats_ship.helth;
    }

    private void TakeDamage(float damage)
    {
        _stats_ship.helth -= damage;
        //_stats_ship.helth -= enemyStats.GetDamage();
        _slider.value = _stats_ship.helth;
    }

    private void Destroyed()
    {
        isNotDying = false;
        StartCoroutine(ExplosionEffectCoroutine());

        if (_gameState.SoundIsOn) aud.PlayOneShot(DeathSound[UnityEngine.Random.Range(0, DeathSound.Length)], 1);

        // Disable all components in the parent and children except SpriteRenderers
        foreach (Transform child in ParentGameObject.GetComponentsInChildren<Transform>(true))
            {
                foreach (var component in child.GetComponents<Component>())
                {
                    if (!(component is Transform || component is SpriteRenderer))
                    {
                        // Checking if the component is Behaviour to ensure it can be enabled/disabled
                        // Some components like RectTransform, Collider etc. can't be enabled/disabled
                        Behaviour behaviour = component as Behaviour;
                        if (behaviour != null)
                        {
                            behaviour.enabled = false;
                        }
                        else
                        {
                            Debug.Log("Component " + component.GetType() + " in " + child.name + " can't be disabled.");
                        }
                    }
                }
            }

        Instantiate(destoyedParts, ParentGameObject.transform.position, ParentGameObject.transform.rotation);
        Destroy(ParentGameObject);
    }

    private IEnumerator ExplosionEffectCoroutine()
    {
        for (int i = 0; i < numberOfExplosions; i++)
        {
            Vector3 explosionPosition = ParentGameObject.transform.position + Random.insideUnitSphere * explosionRadius;
            Instantiate(explosionEffect, explosionPosition, ParentGameObject.transform.rotation);
            yield return new WaitForSeconds(explosionDelay);
        }
    }
}
