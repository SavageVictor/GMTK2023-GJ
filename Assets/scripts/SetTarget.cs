using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class SetTarget : MonoBehaviour
{
    public AIDestinationSetter AiDestinationSetter;
    public ParseSafestPoint ParseSafestPoint;
    public AddBarrelsToTargets BarrelsToTarget;

    void Start()
    {
        AiDestinationSetter = GetComponent<AIDestinationSetter>();
    }

    void FixedUpdate()
    {
        if (BarrelsToTarget.ClosestBarrel != null)
        {
            AiDestinationSetter.target = BarrelsToTarget.ClosestBarrel.transform;
        }
        else
        {
            AiDestinationSetter.target = ParseSafestPoint.farthestUnobstructed;
        }
    }
}