using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static Spawner;

public class bulletS : MonoBehaviour
{
    public float speed;

    public float damage;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * speed;
       
    }

 

  
}
