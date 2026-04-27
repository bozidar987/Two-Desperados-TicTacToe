
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "SoundManager", menuName = "Scriptable Objects/SoundManager")]
public class SoundManager : ScriptableObject
{
    [SerializeField] AudioMixerGroup musicMixerGroup;
    [SerializeField] AudioMixerGroup sfxMixerGroup;

    AudioSource backgroundMusic;
    AudioSource buttonClickSfx;
    AudioSource popupSfx;
    AudioSource markingSfx;
    AudioSource endGameSfx;

    bool musicEanbled = true;
    bool sfxEnabled = true;
    public void playButtonClickSfx()
    {
        if (sfxEnabled && !buttonClickSfx.isPlaying)
        {
            buttonClickSfx.Play();
        }
    }
    public void playMarkingSfx()
    {
        if (sfxEnabled && !markingSfx.isPlaying)
        {
            markingSfx.Play();
        }
    }

    public void playPopupSfx()
    {
        if (sfxEnabled && !popupSfx.isPlaying)
        {
            popupSfx.Play();
        }
    }
    public void playEndGameSfx()
    {
        if (sfxEnabled && !endGameSfx.isPlaying)
        {
            endGameSfx.Play();
        }
    }
    public void backgroundMusicToggle(bool isEnabled) 
    {         
        musicEanbled = isEnabled;
        if (musicEanbled && !backgroundMusic.isPlaying)
        {
            backgroundMusic.Play();
        }
        else
        {
            backgroundMusic.Stop();
        }
    }
    public void sfxToggle(bool isEnabled)
    {
        sfxEnabled = isEnabled;
    }
    public bool isSfxEnabled()
    {
        return sfxEnabled;
    }
    public bool isMusicEnabled()
    {
        return musicEanbled;
    }

    public void setMusicVolume(float value) 
    {
        float volume = Mathf.Log10(value) * 20;
        musicMixerGroup.audioMixer.SetFloat("musicVol", volume);
    }

    public float getMusicVolume() 
    {
        float volume;
        musicMixerGroup.audioMixer.GetFloat("musicVol", out volume);
        return Mathf.Pow(10, volume / 20);
    }

    public float getSfxVolume()
    {
        float volume;
        sfxMixerGroup.audioMixer.GetFloat("sfxVol", out volume);
        return Mathf.Pow(10, volume / 20);
    }
    public void setSfxVolume(float value)
    {
        float volume = Mathf.Log10(value) * 20;
        sfxMixerGroup.audioMixer.SetFloat("sfxVol", volume);
    }
    public void setBackgroundMusic(AudioSource audiosource)
    {
        backgroundMusic = audiosource;
    }
    public void setButtonClickSfx(AudioSource audiosource)
    {
        buttonClickSfx = audiosource;
    }
    public void setPopupSfx(AudioSource audiosource)
    {
        popupSfx = audiosource;
    }

    public void setMarkingSfx(AudioSource audiosource)
    {
        markingSfx = audiosource;
    }

    public void setEndGameSfx(AudioSource audiosource)
    {
        endGameSfx = audiosource;
    } 

}
