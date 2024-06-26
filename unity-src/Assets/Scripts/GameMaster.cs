using System;
using System.Collections;
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
    public GameObject menuUI;
    public GameObject playerUI;

    [Header("Game Objects")]
    [Tooltip("Player game object")]
    public GameObject player;
    public GameObject cam;
    public GameObject topLeft;
    public GameObject bottomRight;
    public GameObject background;
    public GameObject level;
    public GameObject root;

    [Header("Game Settings")]
    [Tooltip("What tilt feedback method should be used")]
    public GameVersion GameVersion;

    private GameVersion gameVersionFromJs;

    public int Deaths { get; set; }
    public float PlayTimeSeconds { get; private set; }
    public GameState GameState { get; private set; }
    public Vector3 PlayerInitialPosition { get; private set; }



    private bool hasInitialized = false;
    public void PlaySFX(string path)
    {
        AudioClip audioClip = Resources.Load<AudioClip>("SFX/" + path);
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

    public void Start()
    {
        gameVersionFromJs = JsBridgeHelper.GetGameVersion();
    }

    public void Update()
    {
        if (!hasInitialized)
        {
            Initialize();
        }
        if (GameState == GameState.Playing)
        {
            PlayTimeSeconds += Time.deltaTime;
        }
    }


    public void Reset()
    {
        Deaths = 0;
        PlayTimeSeconds = 0.0f;
    }

    public void OnGameStateChange(GameState gameState)
    {
        GameState = gameState;
        switch (gameState)
        {
            case GameState.Menu:
                menuUI.SetActive(true);
                root.SetActive(false);
                break;
            case GameState.Playing:
                SetFeedback();
                menuUI.SetActive(false);
                root.SetActive(true);
                break;
            case GameState.GameOver:
                menuUI.SetActive(true);
                gameUI.SetActive(false);
                root.SetActive(false);
                break;
        }
    }

    void SetFeedback()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        var gameVersion = gameVersionFromJs;
#else
        var gameVersion = GameVersion;
#endif     
        if (gameVersion == GameVersion.NoFeedback)
        {
            playerUI.SetActive(false);
            gameUI.SetActive(false);
        }
        else if (gameVersion == GameVersion.TopBar)
        {
            gameUI.SetActive(true);
            playerUI.SetActive(false);
        }
        else if (gameVersion == GameVersion.Character)
        {
            gameUI.SetActive(false);
            playerUI.SetActive(true);
        }
    }

    void Awake()
    {
        if (Instance != null)
            GameObject.Destroy(Instance);
        else
            Instance = this;
        DontDestroyOnLoad(this);

        PlayerInitialPosition = player.transform.position;
    }

    void Initialize()
    {
        Time.timeScale = 1f;
        OnGameStateChange(GameState.Menu);
        hasInitialized = true;
    }

    public void Done()
    {
        PlaySFX("win");

        StartCoroutine(FinishGame());
    }

    public IEnumerator FinishGame()
    {
        player.GetComponent<PlayerController>().SetInput(false);
        yield return new WaitForSeconds(0.5f);
        OnGameStateChange(GameState.GameOver);
        SubmitResults();
    }

    public void SubmitResults()
    {
        var data = new ReportedDataObject
        {
            Deaths = Deaths,
            PlayTimeSecondsStr = PlayTimeSeconds.ToString("F4")
        };
        JsBridgeHelper.ReportData(data.SaveToJsonString());
    }
}

public class ReportedDataObject
{
    public int Deaths;
    public string PlayTimeSecondsStr;
    
    public string SaveToJsonString()
    {
        return JsonUtility.ToJson(this);
    }
}

public enum GameState
{
    Menu,
    Playing,
    GameOver
}