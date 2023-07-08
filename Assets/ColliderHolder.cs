using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderHolder : MonoBehaviour
{
    public Collider2D Collider;
    // Start is called before the first frame update
    void Start()
    {
        Collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
