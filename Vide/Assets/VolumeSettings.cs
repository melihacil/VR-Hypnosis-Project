using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{

    [SerializeField] private AudioMixer _mainMixer;
    float maxVol = 0f;
    float minVol = -80f;
    float volume = 0f;

    public void SetMixerVolume( float volume )
    {
        _mainMixer.SetFloat("MusicVol", Mathf.Log10(volume) * 20);
    }



    public void IncreaseVolume()
    {
        if (volume + 0.1f > maxVol)
            volume = maxVol;
        else
            volume += 3f;
        _mainMixer.SetFloat("MusicVol", volume);
        Debug.Log(volume);
    }
    public void DecreaseVolume()
    {
        if (volume - 3f < minVol)
            return;
        volume -= 3f;
        _mainMixer.SetFloat("MusicVol", volume);
        Debug.Log(volume);

    }
}
