using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class MovingObjectPathifndingUpdating : MonoBehaviour
{
    public List<GameObject> movingObjects;

    void FixedUpdate()
    {

        movingObjects.RemoveAll(item => item == null);
        foreach (GameObject obj in movingObjects)
        {
            if (obj != null)
            {
                ColliderHolder colliderHolder = obj.GetComponentInChildren<ColliderHolder>();
                Collider2D collider = colliderHolder.Collider;
                if (collider != null)
                {
                    Bounds bounds = collider.bounds;
                    AstarPath.active.UpdateGraphs(bounds);
                }
                else
                {
                    Debug.LogError("No 2D collider attached to the GameObject " + obj.name);
                }
            }
            else
            {
                //movingObjects.Remove(obj);
            }
        }
    }

    private void RemoveGameObject()
    {

    }
}