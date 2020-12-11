using UnityEngine;

public enum SoundType
{
    Hurt,
    Pill,
    HurtShield,
    AddShield,
    RemoveShield,
    Click,
    EmptyClick,
    Hover,
    OpenLevel,
    CloseLevel,
    PlayerLaser
}

public class AudioManager : MonoBehaviour
{
    public AudioSource backgroundSource;
    public AudioSource effectsSource;

    [SerializeField] private AudioData audioData;

    private float musicLevel = 5;
    private float effectsLevel = 5;

    public static AudioManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SetupAudioSources();
        UpdateBackgroundLevel();
    }

    private void OnDestroy()
    {
        backgroundSource.Stop();
        effectsSource.Stop();
    }

    private void SetupAudioSources()
    {
        //backgroundSource.clip = audioData.backgroundLoop;
        //backgroundSource.loop = true;
    }

    public void UpdateBackgroundLevel()
    {
        var soundLevel = musicLevel == 0 ? 0 : musicLevel / 10;
        backgroundSource.volume = soundLevel;
    }

    public void PlaySound(SoundType sound)
    {
        PlaySound(FetchClip(sound), effectsLevel);
    }

    private AudioClip FetchClip(SoundType sound)
    {
        switch (sound)
        {
            case SoundType.Hurt:
                return audioData.hurtSound;
            case SoundType.Pill:
                return audioData.pillSound;
            case SoundType.HurtShield:
                return audioData.hurtShieldSound;
            case SoundType.AddShield:
                return audioData.addShieldSound;
            case SoundType.RemoveShield:
                return audioData.removeShieldSound;
            case SoundType.Click:
                return audioData.clickSound;
            case SoundType.EmptyClick:
                return audioData.emptyClickSound;
            case SoundType.Hover:
                return audioData.hoverSound;
            case SoundType.OpenLevel:
                return audioData.openLevelSound;
            case SoundType.CloseLevel:
                return audioData.closeLevelSound;
            case SoundType.PlayerLaser:
                return audioData.playerLaserSound;
        }

        return audioData.clickSound;
    }

    private void PlaySound(AudioClip audioClip, float level)
    {
        var soundLevel = level == 0 ? 0 : level / 10;
        effectsSource.PlayOneShot(audioClip, soundLevel);
    }
}
