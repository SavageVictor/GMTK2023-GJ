using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // GameObject SpawnerP;
    public GameStateS gameState;
    
    public Camera cam;

    public GameObject enemyPrefab;

    public List<Sprite> asteroidSprites; // asteroid sprites

    private Vector3 topRight;
    private Vector3 bottomRight;

    private bool WaweStart = false;

    public float _timeer = 2;
    public float _time;

    float timer = 10f; // countdown starts at 10 seconds

    private MovingObjectPathifndingUpdating movingObjectPathifndingUpdating;

    [System.Serializable]
    public class Wave
    {
        //public int count;
        public float rate;
    }

    public Wave[] waves;

    private void Start()
    {
        movingObjectPathifndingUpdating = GetComponent<MovingObjectPathifndingUpdating>();
      
    }

    void Update()
    {
        if (gameState.GameIsStart)
        {
            if (_time >= _timeer && !WaweStart)
            {
                WaweStart = true;
                StartCoroutine(SpawnAllWaves());
                //_time = 0;
            }
            else
            {
                _time += Time.deltaTime;
            }

            topRight = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, cam.nearClipPlane));
            bottomRight = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane));
        }
    }


    private IEnumerator SpawnAllWaves()
    {
     /*   for (int i = 0; i < waves.Length; i++)
        {*/
            yield return StartCoroutine(SpawnWave(waves[gameState.LevelOfDif]));
        //}
    }

    private IEnumerator SpawnWave(Wave wave)
    {
        while (gameState.GameIsStart && !gameState.GameIsPause)
        {
            SpawnEnemy(enemyPrefab);
            yield return new WaitForSeconds(1f / wave.rate);
        }
    }

    private void SpawnEnemy(GameObject enemy)
    {
        GameObject asteroid = Instantiate(enemy, GetRandomPosition(topRight + Vector3.right * 1, bottomRight + Vector3.right * 1), Quaternion.identity);
        asteroid.transform.SetParent(transform, true);
        // Adjust the circle collider to match the sprite
        CircleCollider2D asteroidCollider = asteroid.GetComponent<CircleCollider2D>();
        if (asteroidCollider != null)
        {
            Destroy(asteroidCollider);
        }
        asteroidCollider = asteroid.AddComponent<CircleCollider2D>();

        // Assuming your GameObject has a SpriteRenderer
        SpriteRenderer spriteRenderer = asteroid.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null && asteroidSprites.Count > 0)
        {
            int randomIndex = Random.Range(0, asteroidSprites.Count);
            spriteRenderer.sprite = asteroidSprites[randomIndex];
        }

        if (spriteRenderer != null)
        {
            // Get the size of the sprite
            float spriteSize = spriteRenderer.bounds.size.x;

            // Set the radius of the CircleCollider2D based on the size of the sprite
            asteroidCollider.radius = spriteSize / 2.0f;
        }
    }

    Vector3 GetRandomPosition(Vector3 a, Vector3 b)
    {
        float t = Random.Range(0f, 1f);
        return Vector3.Lerp(a, b, t);
    }
}
