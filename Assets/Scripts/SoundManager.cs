using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; set; }

    private AudioSource uiSFX;
    private AudioSource musicSource;

    public AudioClip ButtonPressedSFX;
    public AudioClip[] MusicClips;

    private void Awake()
    {
        // ��������� ������� Singleton, ����� ��������� SoundManager �� ������ ��������
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // ���� ������ ����� ������������ ����� �������
        }
        else
        {
            Destroy(gameObject);  // ������� ��������, ���� �� ��� ����������
        }

        uiSFX = gameObject.AddComponent<AudioSource>();
        uiSFX.playOnAwake = false;

        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.playOnAwake = true;
    }
    void Start()
    {
        PlayMusic(0);
    }

    void Update()
    {
        
    }



    /// <summary>
    /// This method plays music from a MusicClips list in SoundManager
    /// </summary>
    /// <param name="clipIndex">Track number</param>
    public void PlayMusic(int clipIndex)
    {
        if (clipIndex >= 0 && clipIndex < MusicClips.Length)
        {
            musicSource.clip = MusicClips[clipIndex];
            musicSource.Play();
        }
    }



    public void ToggleSound(bool isOn)
    {
        musicSource.mute = !isOn;
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
