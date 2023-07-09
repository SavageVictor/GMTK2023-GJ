using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static Spawner;

public class bulletS : MonoBehaviour
{
    public float speed;

    public int damage;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * speed;
       
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "asteroid")
        {
            coll.SendMessage("TakeDamage", damage);

            Destroy(gameObject);
        }
    }

  
}
