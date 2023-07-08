using Pathfinding;
using UnityEngine;

public class MoveGridWithPlayer : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        var graph = AstarPath.active.data.gridGraph;
        graph.center = player.position;
       // AstarPath.active.Scan();
    }
}