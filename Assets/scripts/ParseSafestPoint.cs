using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParseSafestPoint : MonoBehaviour
{
    public LayerMask layerMask;
    public Transform farthestUnobstructed;
    public Transform defaulTransform;

    void FixedUpdate()
    {
        float maxDistance = 0;

        foreach (Transform child in transform)
        {
            RaycastHit2D hit = Physics2D.Raycast(child.position, Vector2.right, 30, layerMask);

            if (hit.collider != null)
            {
                float distance = hit.distance;

                if (distance > maxDistance)
                {
                    maxDistance = distance;
                    farthestUnobstructed = child;
                }

                Debug.DrawRay(child.position, Vector2.right * distance, Color.red);
            }
            else
            {
                float distance = Vector2.Distance(Vector2.zero, child.transform.position);

                if (distance > maxDistance)
                {
                    maxDistance = distance;
                    farthestUnobstructed = child;
                }

                Debug.DrawRay(child.position, Vector2.right * distance, Color.green);
            }
        }
    }
}
