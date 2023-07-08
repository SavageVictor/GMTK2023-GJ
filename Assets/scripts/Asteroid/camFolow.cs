using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFolow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(-20, 0, -20);
    private void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    void LateUpdate()
    {
        Vector3 target = new Vector3(player.position.x, player.position.y, player.position.z) + offset;
        transform.position = target;
    }
}
