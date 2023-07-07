using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class MovingObjectPathifndingUpdating : MonoBehaviour
{
    public List<GameObject> movingObjects;

    void Update()
    {
        foreach (GameObject obj in movingObjects)
        {
            Bounds bounds = new Bounds(obj.transform.position, Vector3.one);
            AstarPath.active.UpdateGraphs(bounds);
        }
    }
}