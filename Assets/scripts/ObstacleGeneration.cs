using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    
    public GameObject objectToSpawn; 
    public float launchForceMin = 1f; 
    public float launchForceMax = 5f;

    private MovingObjectPathifndingUpdating movingObjectPathifndingUpdating;

    void Start()
    {
        movingObjectPathifndingUpdating = GetComponent<MovingObjectPathifndingUpdating>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            SpawnAndLaunchObject();
        }
    }

    void SpawnAndLaunchObject()
    {
        GameObject instance = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        movingObjectPathifndingUpdating.movingObjects.Add(instance);
        Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            float launchForce = Random.Range(launchForceMin, launchForceMax);

            Vector2 direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

            rb.AddForce(direction.normalized * launchForce, ForceMode2D.Impulse);
        }
        else
        {
            Debug.LogError("The object to spawn does not have a Rigidbody2D component");
        }
    }
}