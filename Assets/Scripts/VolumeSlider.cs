using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;

    [SerializeField] private bool everything;
    [SerializeField] private bool isMusic;
    [SerializeField] private bool isSFX;
    

    private void Start()
    {
        if(isMusic)
        {
            MusicVolume();
        }
        if(everything)
        {
            Everything();
        }
    }

    public void MusicVolume()
    {
        SoundManger.Instance.Music(slider.value);
        slider.onValueChanged.AddListener(val => SoundManger.Instance.Music(val));
    }

    public void Everything()
    {
        SoundManger.Instance.Allsounds(slider.value);
        slider.onValueChanged.AddListener(val => SoundManger.Instance.Allsounds(val));
    }

    
}
