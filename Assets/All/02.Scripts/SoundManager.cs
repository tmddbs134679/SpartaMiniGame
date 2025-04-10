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

    [Header("Audio Sources")]
    [SerializeField] private AudioSource bgmSource;  
    [SerializeField] private AudioSource playerSource;
    [SerializeField] private AudioSource etcSource; 


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
        AudioSource source = GetSource(type);

        if (source.isPlaying && source.clip == clip) return;

        source.clip = clip;
        source.loop = true;
        source.Play();
    }


    public void PlayOneShot(SoundType type, AudioClip clip)
    {
        AudioSource source = GetSource(type);
        if (clip != null)
            source.PlayOneShot(clip);
    }


    public void StopLoop(SoundType type)
    {
        AudioSource source = GetSource(type);
        if (source.isPlaying)
            source.Stop();
    }

   
    private AudioSource GetSource(SoundType type)
    {
        return type switch
        {
            SoundType.BGM => bgmSource,
            SoundType.Player => playerSource,
            SoundType.ETC => etcSource,
            _ => null
        };
    }
}
