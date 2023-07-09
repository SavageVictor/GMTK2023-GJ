using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRandomForceRB : MonoBehaviour
{
    public float minForce = 1f;
    public float maxForce = 10f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ApplyForce();
    }

    void ApplyForce()
    {
        float randomAngle = Random.Range(0, 360) * Mathf.Deg2Rad;
        Vector2 direction = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));

        float magnitude = Random.Range(minForce, maxForce);

        rb.AddForce(direction * magnitude, ForceMode2D.Impulse);
    }
}
