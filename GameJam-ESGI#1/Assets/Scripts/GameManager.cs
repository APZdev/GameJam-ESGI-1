using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float itemSpeed = 5f;
    [SerializeField] private ItemSpawner spawner;
    [SerializeField] private Item[] itemsList;
    [SerializeField] private float spawnDelay = 1f;
    [SerializeField] private float spawnVariability = 0.5f;
    private float _lastSpawn;
    
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Update() {
        if (_lastSpawn > spawnDelay + Random.Range(-spawnVariability, spawnVariability)) {
            _lastSpawn = 0;
            int index = Random.Range(0, itemsList.Length);
            Instantiate(itemsList[index], spawner.transform.position, Quaternion.identity);
        }

        _lastSpawn += Time.deltaTime;
    }
}
