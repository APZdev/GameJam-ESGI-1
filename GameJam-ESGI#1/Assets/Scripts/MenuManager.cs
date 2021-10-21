using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public float highScore;

    public TextMeshProUGUI highScoreTxt;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        highScore = PlayerPrefs.GetFloat("HighScore");
    }

    void Update()
    {
        highScoreTxt.text =  $"HIGHSCORE : {highScore}";
    }

    public void SetHighScore(float _highScore)
    {
        PlayerPrefs.SetFloat("HighScore", _highScore);
    }

    public void OnClick_ChangeScene()
    {
        SceneManager.LoadScene(1);
    }
}
