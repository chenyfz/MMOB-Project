using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameMaster : MonoBehaviour
{
    public static GameMaster Instance;

    [Tooltip("Audiosource for SFX")]
    public AudioSource audioSFXSource;

    [Tooltip("Audiosource for music")]
    public AudioSource audioMusicSource;

    [NonSerialized]
    public Dictionary<string, GameObject> enemies = new Dictionary<string, GameObject>();

    public UnityEvent OnScoreChange = new(), OnLevelChange = new();

    public int Score { get; private set; }

    public GameState GameState { get; private set; }

    [Header("UI")]

    public GameObject gameUI;

    [Header("Game Objects")]


    [Tooltip("Player game object")]
    public GameObject player;


    private bool hasInitialized = false;
    public void PlaySFX(string path)
    {
        AudioClip audioClip = Resources.Load<AudioClip>("Sound/" + path);
        audioSFXSource.PlayOneShot(audioClip);
    }

    public void SwitchMusic(string path)
    {
        AudioClip audioClip = Resources.Load<AudioClip>("Music/" + path);
        if (audioMusicSource.clip != audioClip)
        {
            audioMusicSource.Stop();
            audioMusicSource.loop = true;
            audioMusicSource.Stop();
            audioMusicSource.clip = audioClip;
            audioMusicSource.Play();
        }
    }

    public void Update()
    {
        if (!hasInitialized)
        {
            Initialize();
        }
    }

    public void ReadEnemies()
    {

    }

    public void CreateEnemyPrefabs()
    {

    }


    public void Reset()
    {
        Score = 0;
        OnScoreChange.Invoke();
        OnGameStateChange(GameState.Menu);
    }

    public void OnGameStateChange(GameState gameState)
    {
        GameState = gameState;
        switch (gameState)
        {
            case GameState.Menu:
                break;
            case GameState.Playing:
                break;
            case GameState.GameOver:
                break;
            case GameState.Paused:
                break;
        }
    }

    void Awake()
    {
        if (Instance != null)
            GameObject.Destroy(Instance);
        else
            Instance = this;
        DontDestroyOnLoad(this);
    }

    void Initialize()
    {
        Time.timeScale = 1f;
        OnGameStateChange(GameState.Menu);
        //ReadEnemies();
        //CreateEnemyPrefabs();
        hasInitialized = true;
    }
}

public enum GameState
{
    Menu,
    Playing,
    Paused,
    GameOver
}
