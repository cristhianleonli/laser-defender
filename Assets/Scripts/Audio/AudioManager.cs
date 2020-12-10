using UnityEngine;

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

    public void PlayTestSound(int level)
    {
        PlaySound(audioData.clickSound, level);
    }

    private void PlaySound(AudioClip audioClip, float level)
    {
        var soundLevel = level == 0 ? 0 : level / 10;
        effectsSource.PlayOneShot(audioClip, soundLevel);
    }

    public void PlayClick()
    {
        PlaySound(audioData.clickSound, effectsLevel);
    }

    public void PlayHover()
    {
        PlaySound(audioData.hoverSound, effectsLevel);
    }
}
