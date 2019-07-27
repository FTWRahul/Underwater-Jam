using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer masterMixer;

    public void SetMasterLv(float masterLvl)
    {
        masterMixer.SetFloat("masterVol", masterLvl);
    }

    public void SetSfxLv(float sfxLvl)
    {
        masterMixer.SetFloat("sfxVol", sfxLvl);
    }

    public void SetMusicLv(float musicLvl)
    {
        masterMixer.SetFloat("musicVol", musicLvl);
    }

    public void SetNarratorLv(float narratorLvl)
    {
        masterMixer.SetFloat("narratorVol", narratorLvl);
    }
}
