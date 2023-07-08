using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackwardsToFakeEnvironment : MonoBehaviour
{
    public float speed = -1.0f;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }
}