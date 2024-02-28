using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSoundEffectManager : MonoBehaviour
{
    public AudioData_SO audioData;
    public List<AudioSource> currentPlayingAudioSource;
    public GameObjectPool audioPool;
    public void PlayEffect(SFXType playSFXType) 
    {
        var audioSource = audioPool.GetObject<AudioSource>();
        PlaySound(audioData.GetAudioDataByType(playSFXType), audioSource);
    }
    public void PlaySound(AudioData clipToPlay, AudioSource audioSource)
    {
        audioSource.clip = clipToPlay.audioClip;
        audioSource.volume = clipToPlay.volume;
        audioSource.Play();
        StartCoroutine(DoActivePool(audioSource.gameObject, audioSource.clip.length));
    }
    public IEnumerator DoActivePool(GameObject audioSourceObject, float length) 
    {
        yield return new WaitForSeconds(length);
        audioPool.DeActivateObject(audioSourceObject);
    }
}
