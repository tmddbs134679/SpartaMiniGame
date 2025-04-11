using UnityEngine;


public enum SoundType
{
    BGM,
    Player,
    ETC
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("Audio Events")]
    [SerializeField] private StageResultEventChannel eventChannel;
    [SerializeField] private PlayerEventChannel playereventChannel;
    [Header("Audio Sources")]
    [SerializeField] private GameAudioClips clips;
    [SerializeField] private AudioSource bgmSource;  
    [SerializeField] private AudioSource playerSource;
    [SerializeField] private AudioSource etcSource;
    private void OnEnable()
    {
        eventChannel.OnGameResult += HandleGameResultPlay;
        playereventChannel.OnPlayerEvent += HandlePlayer;

    }

    private void OnDisable()
    {
        eventChannel.OnGameResult -= HandleGameResultPlay;
        playereventChannel.OnPlayerEvent -= HandlePlayer;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
       
    }

    public void PlayLoop(SoundType type, AudioClip clip)
    {
        AudioSource source = GetSourceType(type);

        if (source.isPlaying && source.clip == clip) 
            return;

        source.clip = clip;
        source.loop = true;
        source.Play();
    }


    public void StopLoop(SoundType type)
    {
        AudioSource source = GetSourceType(type);
        if (source.isPlaying)
            source.Stop();
    }


    public void ButtonPlay()
    {
        etcSource.PlayOneShot(clips.buttonClick);
    }


    private AudioSource GetSourceType(SoundType type)
    {
        return type switch
        {
            SoundType.BGM => bgmSource,
            SoundType.Player => playerSource,
            SoundType.ETC => etcSource,
            _ => throw new System.ArgumentException("Invalid SoundType: " + type)
        };
    }


    #region Events
    public void HandleGameResultPlay(RESULT result)
    {
        etcSource.PlayOneShot(clips.stageClearClip);
    }

    public void HandlePlayer(bool toggle)
    {
        playerSource.PlayOneShot(toggle ? clips.boxCrushClips[0] : clips.boxCrushClips[1]);

    }

    #endregion
}
