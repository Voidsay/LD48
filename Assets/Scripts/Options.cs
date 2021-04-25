using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    public Slider sensetivity;
    public Toggle invx;
    public Toggle invy;

    public AudioMixer audioMixer;

    public void SaveMS(float val)
    {
        PlayerPrefs.SetFloat("MS", val);
        Variables.MS = val;
    }

    public void InvX(bool val)
    {
        Variables.InvMX = val ? -1 : 1;
        PlayerPrefs.SetInt("InvX", Variables.InvMX);
        Debug.Log(Variables.InvMX + " " + val);
    }
    public void InvY(bool val)
    {
        Variables.InvMY = val ? -1 : 1;
        PlayerPrefs.SetInt("InvY", Variables.InvMY);
    }

    void OnEnable()
    {
        sensetivity.value = Variables.MS;
        invx.isOn = Variables.InvMX == -1 ? true : false;
        invy.isOn = Variables.InvMY == -1 ? true : false;
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

}
