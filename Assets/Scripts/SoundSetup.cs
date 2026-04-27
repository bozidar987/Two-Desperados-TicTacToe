using System.Collections.Generic;
using UnityEngine;

public class SoundSetup : MonoBehaviour
{
    [SerializeField] SoundManager soundManager;
    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] AudioSource buttonClickSfx;
    [SerializeField] AudioSource popupSfx;
    [SerializeField] AudioSource markingSfx;
    [SerializeField] AudioSource endGameSfx;

    public static SoundSetup instance { get; private set; }

    private void Awake()
    {
        if(instance  != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        soundManager.setBackgroundMusic(backgroundMusic);
        soundManager.setButtonClickSfx(buttonClickSfx);
        soundManager.setPopupSfx(popupSfx);   
        soundManager.setMarkingSfx(markingSfx);
        soundManager.setEndGameSfx(endGameSfx);

        soundManager.backgroundMusicToggle(soundManager.isMusicEnabled());
    }
}
