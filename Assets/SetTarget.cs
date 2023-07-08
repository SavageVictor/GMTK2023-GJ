using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class SetTarget : MonoBehaviour
{
    public AIDestinationSetter AiDestinationSetter;
    public ParseSafestPoint ParseSafestPoint;

    void Start()
    {
        AiDestinationSetter = GetComponent<AIDestinationSetter>();
    }

    void FixedUpdate()
    {
        AiDestinationSetter.target = ParseSafestPoint.farthestUnobstructed;
    }
}
