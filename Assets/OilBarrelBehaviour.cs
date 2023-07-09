using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilBarrelBehaviour : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
