using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class ChangeColliderSizePathfinding : MonoBehaviour
{
    void Start()
    {
        SpriteRenderer parentSprite = GetComponentInParent<SpriteRenderer>();

        if (parentSprite == null)
        {
            Debug.LogError("Parent object has no SpriteRenderer.");
            return;
        }

        CircleCollider2D collider = GetComponent<CircleCollider2D>();

        float maxSize = Mathf.Max(parentSprite.size.x, parentSprite.size.y);

        collider.radius = maxSize * 2;
    }
}
