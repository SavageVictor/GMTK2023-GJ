using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastAsteroids : MonoBehaviour
{
    public float raycastLength = 5f;
    public LayerMask layerMask;

    void FixedUpdate()
    {
        // Raycast to the right (+X direction)
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, raycastLength, layerMask);

    }

    void OnDrawGizmos()
    {
        // Visualize the raycast in scene view
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * raycastLength);
    }
}
