using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    public AudioClip soundEffect, clearsoundEffect, gameoversoundEffect, loselifesoundEffect, oneupSoundEffect;

    public AudioClip statesoundEffect;

    private AudioSource generalAudioSource; // ���ʉ��p��AudioSource
    private AudioSource stateAudioSource;   // �J�n�p��AudioSource

    private void Awake()
    {

        stateAudioSource = gameObject.AddComponent<AudioSource>();
        generalAudioSource = gameObject.AddComponent<AudioSource>();
    }
    void Start()
    {
        
        
    }

    void Update()
    {
        // �������ʂȏ������K�v�Ȃ炱���ɒǉ�
    }

    public void State()
    {
        
        PlaySound(stateAudioSource, statesoundEffect);
    }

    public void Effect()
    {
        PlaySound(generalAudioSource, soundEffect);
    }

    public void ClearSound()
    {
        PlaySound(generalAudioSource, clearsoundEffect);
    }

    public void LostLife()
    {
        PlaySound(generalAudioSource, loselifesoundEffect);
    }

    public void GameOver()
    {
        PlaySound(generalAudioSource, gameoversoundEffect);
    }

    public void Zanki()
    {
        PlaySound(generalAudioSource, oneupSoundEffect);
    }

    private void PlaySound(AudioSource audioSource, AudioClip clip)
    {
        
        audioSource.clip = clip;
        audioSource.Play();
    }
}