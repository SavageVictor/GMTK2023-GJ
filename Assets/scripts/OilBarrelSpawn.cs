using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilBarrelSpawn : MonoBehaviour
{
    public GameStateS state;
    public GameObject gameObjectToMove;
    public float forceAmount = 10f;
    public float minSpawnInterval = 1f; // Minimum spawn interval
    public float maxSpawnInterval = 5f; // Maximum spawn interval

    void Start()
    {
        
        StartCoroutine(SpawnAtRandomIntervals());
    }

    IEnumerator SpawnAtRandomIntervals()
    {
        while (true)
        {
           
                yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));

                SpawnAtPosition(-10f, 10f);
            
        }
    }

    public void SpawnAtPosition(float minYPos, float maxYPos)
    {
        if (!state.GameIsPause)
        {
            float randomYPos = Random.Range(minYPos, maxYPos);
            float randomRotation = Random.Range(0f, 360f); // Random rotation in degrees

            Vector3 spawnPosition = new Vector3(this.transform.position.x, randomYPos, 0);
            Quaternion spawnRotation = Quaternion.Euler(0, 0, randomRotation); // Rotation around Z axis
            GameObject spawnedObject = Instantiate(gameObjectToMove, spawnPosition, spawnRotation);
            spawnedObject.transform.parent = this.transform;

            Rigidbody2D rb2d = spawnedObject.GetComponent<Rigidbody2D>();
            if (rb2d != null)
            {
                rb2d.AddForce(new Vector2(-forceAmount, 0));
            }
        }
    }

}