using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class MovingObjectPathfindingUpdating : MonoBehaviour
{
    public List<GameObject> movingObjects;

    public float Timer = 5;
    public float time = 5;


    void Update()
    {
        if (time <= 0)
        {
            foreach (GameObject obj in movingObjects)
            {
                if (obj != null)
                {
                    Collider2D collider = obj.GetComponentInChildren<Collider2D>();
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

            time = Timer;
        }
        else
        {
            time -= Time.deltaTime;
        }
    }

    private void RemoveGameObject()
    {

    }
}