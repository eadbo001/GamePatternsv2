using UnityEngine;

public class AudioManager : MonoBehaviourSingleton<AudioManager>
{
     [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("Background Music")]
    [SerializeField] private AudioClip backgroundMusic;

    protected override void Awake()
    {
        base.Awake();

        
        if (Instance != this)
            return;

        // Start background music
        if (backgroundMusic != null)
        {
            PlayMusic(backgroundMusic);
        }
    }

    public static void PlayMusic(AudioClip clip)
    {
        if (clip == null || Instance == null)
            return;

        Instance.musicSource.clip = clip;
        Instance.musicSource.loop = true;
        Instance.musicSource.volume = 0.2f;
        Instance.musicSource.Play();
    }

    public static void PlaySFX(AudioClip clip)
    {
        if (clip == null || Instance == null)
            return;

        Instance.sfxSource.PlayOneShot(clip);
    }

}
