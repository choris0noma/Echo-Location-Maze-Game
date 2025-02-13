using UnityEngine;
using UnityEngine.UI;

namespace MazeGame.UI
{
    public class SettingsMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _settingsPanel;
        [SerializeField] private Slider _volumeSlider, _senseSlider;
        private SliderPublisher _volumePublisher, _sensePublisher;
        private void Awake () 
        { 
            _volumePublisher = _volumeSlider.GetComponent<SliderPublisher>();
            _sensePublisher = _senseSlider.GetComponent<SliderPublisher>();
        }
        private void Start()
        {
            LoadSettings();
        }
        public void BackToDefault() 
        { 
            SetSoundVolume(1);
            SetSenseValue(0);
            _volumePublisher.SetSliderValue(1);
            _sensePublisher.SetSliderValue(0);
            SaveSettings();
        }
        public void CloseSettings()
        {
            _settingsPanel?.SetActive(false);
            SetSoundVolume((int)_volumeSlider.value);
            SetSenseValue((int)_senseSlider.value);
            SaveSettings(); 
        }

        public void SetSoundVolume(int _soundVolume)
        {
            PlayerPrefs.SetInt("SoundVolume", _soundVolume);
        }

        public void SetSenseValue(int _senseValue)
        {
            PlayerPrefs.SetInt("SenseValue", _senseValue);
        }


        private void LoadSettings()
        {
            _volumePublisher.
                SetSliderValue(PlayerPrefs.GetInt("SoundVolume", 1));
            _sensePublisher.
                SetSliderValue(PlayerPrefs.GetInt("SenseValue", 0));
        }
        private void SaveSettings()
        {
            PlayerPrefs.Save();
        }
    }
}
