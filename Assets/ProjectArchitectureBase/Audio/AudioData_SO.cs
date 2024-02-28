using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "AudioData", fileName = "AudioData")]
public class AudioData_SO : ScriptableObject
{
    public List<AudioData> data;
    public AudioData GetAudioDataByType(SFXType sfxType) 
    {
        return data.FirstOrDefault(x => x.sfxType == sfxType);
    }
}
[Serializable]
public class AudioData
{
    public SFXType sfxType;
    public AudioClip audioClip;
    public float volume = 1;
}
public enum SFXType
{
}