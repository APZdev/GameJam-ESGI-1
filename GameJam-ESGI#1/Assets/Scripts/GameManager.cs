
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
    [SerializeField] private float spawnMinimumDelay = 0.5f;
    
    public AnimationCurve SpeedIncrease;
    public AnimationCurve EnemyIncrease;
    
    private float _lastSpawn;
    private float timeToSpawn;

    private float timeElapsed;
    private float startTime;
    private float baseSpeed;
    
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

        startTime = Time.time;
        baseSpeed = itemSpeed;
    }

    private void Update() {
        if (!Running) return;
        
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

    public void AddPoint(int value) {
        _currentScore += value;
        scoreText.text = _currentScore.ToString();
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
