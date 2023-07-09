using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class MovingObjectPathifndingUpdating : MonoBehaviour
{
    public List<GameObject> movingObjects;

    void FixedUpdate()
    {
        movingObjects.RemoveAll(item => item == null);

        Bounds combinedBounds = new Bounds();

        bool hasBounds = false;

        foreach (GameObject obj in movingObjects)
        {
            if (obj != null)
            {
                ColliderHolder colliderHolder = obj.GetComponentInChildren<ColliderHolder>();
                Collider2D collider = colliderHolder.Collider;
                if (collider != null)
                {
                    if (hasBounds)
                    {
                        combinedBounds.Encapsulate(collider.bounds);
                    }
                    else
                    {
                        combinedBounds = collider.bounds;
                        hasBounds = true;
                    }
                }
                else
                {
                    Debug.LogError("No 2D collider attached to the GameObject " + obj.name);
                }
            }
        }

        if (hasBounds)
        {
            AstarPath.active.UpdateGraphs(combinedBounds);
        }
    }
}