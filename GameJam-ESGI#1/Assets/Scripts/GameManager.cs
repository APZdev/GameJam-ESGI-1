using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float itemSpeed = 5f;
    
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
            //cameras = new List<ShakeTransform>();
        }
        else {
            Destroy(gameObject);
        }
    }
}
