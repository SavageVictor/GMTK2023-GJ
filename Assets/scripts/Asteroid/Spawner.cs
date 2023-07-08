using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Camera cam;

    public GameObject enemyPrefab;

    public List<Sprite> asteroidSprites; // asteroid sprites

    private Vector3 topRight;
    private Vector3 bottomRight;

    float timer = 10f; // countdown starts at 10 seconds

    private MovingObjectPathfindingUpdating movingObjectPathifndingUpdating;

    [System.Serializable]
    public class Wave
    {
        public int count;
        public float rate;
    }

    public Wave[] waves;

    private void Start()
    {
        movingObjectPathifndingUpdating = GetComponent<MovingObjectPathfindingUpdating>();
        StartCoroutine(SpawnAllWaves());
    }

    void Update()
    {
        topRight = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, cam.nearClipPlane));
        bottomRight = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane));
    }


    private IEnumerator SpawnAllWaves()
    {
        for (int i = 0; i < waves.Length; i++)
        {
            yield return StartCoroutine(SpawnWave(waves[i]));
        }
    }

    private IEnumerator SpawnWave(Wave wave)
    {
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(enemyPrefab);
            yield return new WaitForSeconds(1f / wave.rate);
        }
    }

    private void SpawnEnemy(GameObject enemy)
    {
        GameObject asteroid = Instantiate(enemy, GetRandomPosition(topRight + Vector3.right * 1, bottomRight + Vector3.right * 1), Quaternion.identity);

        // Assign a random sprite to the newly instantiated asteroid
        SpriteRenderer asteroidSpriteRenderer = asteroid.GetComponent<SpriteRenderer>();
        if (asteroidSpriteRenderer != null && asteroidSprites.Count > 0)
        {
            int randomIndex = Random.Range(0, asteroidSprites.Count);
            asteroidSpriteRenderer.sprite = asteroidSprites[randomIndex];
        }

        // Adjust the polygon collider to match the sprite
        PolygonCollider2D asteroidCollider = asteroid.GetComponent<PolygonCollider2D>();
        if (asteroidCollider != null)
        {
            Destroy(asteroidCollider);
        }
        asteroidCollider = asteroid.AddComponent<PolygonCollider2D>();
        asteroidCollider.excludeLayers += LayerMask.GetMask("Obstacle");

        movingObjectPathifndingUpdating.movingObjects.Add(asteroid);
    }

    Vector3 GetRandomPosition(Vector3 a, Vector3 b)
    {
        float t = Random.Range(0f, 1f);
        return Vector3.Lerp(a, b, t);
    }
}
