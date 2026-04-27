using UnityEngine;
using UnityEngine.UI;
public class AudioToggleSetup : MonoBehaviour
{

    [SerializeField] SoundManager soundManager;

    [Header ("Toggles")]
    [SerializeField] Toggle musicToggle;
    [SerializeField] Toggle sfxToggle;

    [Header ("Sliders")]
    [SerializeField] Slider musicVolSlider;
    [SerializeField] Slider sfxVolSlider;

    void Start()
    {
        if(soundManager.isMusicEnabled())
        {
            musicToggle.SetIsOnWithoutNotify(true);
        }
        else
        {
            musicToggle.SetIsOnWithoutNotify(false);
        }

        if(soundManager.isSfxEnabled())
        {
            sfxToggle.SetIsOnWithoutNotify(true);
        }
        else
        {
            sfxToggle.SetIsOnWithoutNotify(false);
        }
        
        musicVolSlider.SetValueWithoutNotify(soundManager.getMusicVolume());
        sfxVolSlider.SetValueWithoutNotify(soundManager.getSfxVolume());
    }
}
