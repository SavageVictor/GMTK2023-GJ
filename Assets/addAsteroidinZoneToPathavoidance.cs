using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class addAsteroidinZoneToPathavoidance : MonoBehaviour
{
    public MovingObjectPathifndingUpdating movingObjectPathfindingUpdating;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "asteroid")
        {
            movingObjectPathfindingUpdating.movingObjects.Add(other.gameObject);
        }
    }
}
