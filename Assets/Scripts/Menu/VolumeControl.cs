using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioClip tester;
    float volume;

    void Start()
    {
        volume = 0.5f;
        volumeSlider.value = volume;
    }
    
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        AudioSource.PlayClipAtPoint(tester, Camera.main.transform.position);
    }
}
