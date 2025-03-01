using UnityEngine;
using UnityEngine.UI;

public class VolumeSettingsApplier : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private SoundManager _soundManager;

    private void Start()
    {
        _slider.maxValue = 1.0f;
        _slider.minValue = 0.0f;
        _soundManager = SoundManager.Instance;
        _slider.onValueChanged.AddListener(_soundManager.SetVolume);
    } 
}