using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster Instance;

    [Header("Audio")]
    [Tooltip("Audiosource for SFX")]
    public AudioSource audioSFXSource;

    [Tooltip("Audiosource for music")]
    public AudioSource audioMusicSource;

    [Header("UI")]
    public GameObject gameUI;

    [Header("Game Objects")]
    [Tooltip("Player game object")]
    public GameObject player;
    public GameObject cam;
    public GameObject topLeft;
    public GameObject bottomRight;

    public int Score { get; private set; }
    public GameState GameState { get; private set; }
    private bool hasInitialized = false;
    private Vector3 playerInitialPosition;
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


    public void Reset()
    {
        //Score = 0;
        //OnGameStateChange(GameState.Menu);
        player.transform.position = playerInitialPosition;
        cam.transform.position = new Vector3(0, 0, -10);
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

        playerInitialPosition = player.transform.position;
    }

    void Initialize()
    {
        Time.timeScale = 1f;
        OnGameStateChange(GameState.Menu);
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
