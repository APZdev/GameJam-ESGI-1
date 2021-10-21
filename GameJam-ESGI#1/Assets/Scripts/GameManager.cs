using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float itemSpeed = 5f;
    [SerializeField] private ItemSpawner spawner;
    [SerializeField] private Item[] itemsList;
    [SerializeField] private float spawnDelay = 1f;
    [SerializeField] private float spawnVariability = 0.5f;
    [SerializeField] private float spawnMinimumDelay = 0.5f;
    
    public AnimationCurve SpeedIncrease;
    public AnimationCurve EnemyIncrease;
    
    private float _lastSpawn;
    private float timeToSpawn;

    private float timeElapsed;
    private float startTime;
    private float baseSpeed;
    
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
        startTime = Time.time;
        baseSpeed = itemSpeed;
    }

    private void Update()
    {
        timeElapsed = Time.time - startTime;
        itemSpeed = baseSpeed * SpeedIncrease.Evaluate(timeElapsed);
        if (_lastSpawn > timeToSpawn) {
            _lastSpawn = 0;
            timeToSpawn = spawnMinimumDelay + (spawnDelay)/itemSpeed * Random.Range(0, spawnVariability);
            float i = Random.Range(0f, 1f);
            int index = i >= EnemyIncrease.Evaluate(timeElapsed) ? 0 : 1;
            Instantiate(itemsList[index], spawner.transform.position, Quaternion.identity);
        }

        _lastSpawn += Time.deltaTime;
        
        
    }
}
