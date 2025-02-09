using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; set; }

    public AudioClip[] sfxClips;
    public AudioClip[] musicClips;

    public AudioSource _uiSFX;
    public AudioSource _musicSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        _uiSFX = gameObject.AddComponent<AudioSource>();
        _uiSFX.playOnAwake = false;

        _musicSource = gameObject.AddComponent<AudioSource>();
        _musicSource.playOnAwake = true;
    }
    void Start()
    {
        PlayMusic(0);
    }

    void Update()
    {
        
    }



    /// <summary>
    /// This method plays music from a musicClips list in SoundManager
    /// </summary>
    /// <param name="clipIndex">Track number</param>
    public void PlayMusic(int clipIndex)
    {
        if (clipIndex >= 0 && clipIndex < musicClips.Length)
        {
            _musicSource.clip = musicClips[clipIndex];
            _musicSource.Play();
        }
    }



    public void ToggleSounds(bool isOn)
    {
        _musicSource.mute = !isOn;
    }   

    /// <summary>
    /// Plays the audioClip once through the audioSource.
    /// </summary>
    /// <param name="audioSource">AudioSource which is going to play the sound.</param>
    /// <param name="audioClip">AudioClip that needs to be played.</param>
    
    public void PlaySoundOnce(AudioSource audioSource, AudioClip audioClip)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }

}
