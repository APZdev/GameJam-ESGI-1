using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public float itemSpeed = 5f;
    [SerializeField] private ItemSpawner spawner;
    [SerializeField] private Item[] itemsList;
    [SerializeField] private float spawnDelay = 1f;
    [SerializeField] private float spawnVariability = 0.5f;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private int lives = 5;
    [SerializeField] private GameObject gameOverPanel;
    private float _lastSpawn;
    
    public static GameManager Instance { get; private set; }

    [NonSerialized] public bool Running;
    
    private int _currentScore;
    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }

        livesText.text = lives.ToString();
        Running = true;
    }

    private void Update() {
        if (!Running) return;
        if (_lastSpawn > spawnDelay + Random.Range(-spawnVariability, spawnVariability)) {
            _lastSpawn = 0;
            int index = Random.Range(0, itemsList.Length);
            Instantiate(itemsList[index], spawner.transform.position, Quaternion.identity);
        }

        _lastSpawn += Time.deltaTime;
    }

    public void AddPoint(int value) {
        _currentScore += value;
        scoreText.text = value.ToString();
    }

    public void TakeDamage(int value) {
        lives -= value;

        if (lives <= 0) {
            lives = 0;
            gameOverPanel.SetActive(true);
            Running = false;
        }
        
        
        livesText.text = lives.ToString();
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
