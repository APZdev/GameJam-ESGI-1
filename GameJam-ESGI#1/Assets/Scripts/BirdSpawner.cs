using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    public GameObject birdPrefab;
    public Transform[] spawners;
    public float maxTime = 10;

    public float elaspedTime = 0;

    public float randomTime;

    public bool canSpawnRight;

    void Start()
    {
        randomTime = Random.Range(2f, maxTime);
    }

    void Update()
    {
        elaspedTime += Time.deltaTime;

        if(elaspedTime > randomTime)
        {
            SpawnBird();

            randomTime = Random.Range(2f, maxTime);
            elaspedTime = 0;
        }
    }

    private void SpawnBird()
    {
        var bird = Instantiate(birdPrefab);

        int spawnPoint = 0;
        spawnPoint = canSpawnRight ? spawnPoint = Random.Range(0, 1) : spawnPoint = Random.Range(0, 2);

        bool isRight = spawnPoint == 0 ? true : false;
        bird.GetComponent<BirdBehaviour>().isRight = isRight;
        bird.transform.position = spawners[spawnPoint].transform.position;

        Destroy(bird, 10f);
    }
}
