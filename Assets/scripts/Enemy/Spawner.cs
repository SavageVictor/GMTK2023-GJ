using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using Random = System.Random;
public class Spawner : MonoBehaviour
{
    public GameObject Metior;
    public Camera cam;

    public int SpawnRate = 10;
    public int MaxMetior = 10;
    public int MinMetior = 1;

    private Vector3 topRight;
    private Vector3 bottomRight;

    float timer = 10f; // countdown starts at 10 seconds



    [System.Serializable]
    public class Wave
    {
        public GameObject enemyPrefab;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    //public Transform spawnPoint;

    private void Start()
    {
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
            SpawnEnemy(wave.enemyPrefab);
            yield return new WaitForSeconds(1f / wave.rate);
        }
    }

    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, GetRandomPosition(topRight, bottomRight), Quaternion.identity);
    }

    Vector3 GetRandomPosition(Vector3 a, Vector3 b)
    {
        float t = Random.Range(0f, 1f);
        return Vector3.Lerp(a, b, t);
    }

    /*

        // Start is called before the first frame update
        void Start()
        {
            //MeteorSize = r.Next(MeteorSize_Min, MeteorSize_Max);
            topRight = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, cam.nearClipPlane));
            bottomRight = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane));

            SpawnObject(1);
        }

        // Update is called once per frame
        void Update()
        {
             topRight = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, cam.nearClipPlane));
             bottomRight = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane));

             if (timer > 0)
             {
                 timer -= Time.deltaTime;
             }
             else
             {
                 Debug.Log("Countdown has finished!");
                 // perform any action when the countdown is over
             }



        }

        Vector3 GetRandomPosition(Vector3 a, Vector3 b)
        {
            float t = Random.Range(0f, 1f);
            return Vector3.Lerp(a, b, t);
        }

        void SpawnObject(float seconds)
        {
            Instantiate(Metior,GetRandomPosition(topRight, bottomRight), Quaternion.identity);
        }*/
}
