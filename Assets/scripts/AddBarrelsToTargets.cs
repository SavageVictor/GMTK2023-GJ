using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AddBarrelsToTargets : MonoBehaviour
{
    public List<GameObject> BarrelsToTarget;
    public GameObject Player;
    public GameObject ClosestBarrel;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "oil")
        {
            BarrelsToTarget.Add(other.gameObject);
        }
    }

    void FixedUpdate()
    {
        UpdateClosestBarrel();
    }

    void UpdateClosestBarrel()
    {
        BarrelsToTarget.RemoveAll(item => item == null);  // Remove any null references

        if (BarrelsToTarget.Count == 0)
        {
            ClosestBarrel = null;
            return;
        }

        ClosestBarrel = BarrelsToTarget[0];
        float minDistance = Vector3.Distance(Player.transform.position, ClosestBarrel.transform.position);

        for (int i = 1; i < BarrelsToTarget.Count; i++)
        {
            if (BarrelsToTarget[i] != null)  // Check if the barrel exists
            {
                float distance = Vector3.Distance(Player.transform.position, BarrelsToTarget[i].transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    ClosestBarrel = BarrelsToTarget[i];
                }
            }
        }
    }

}