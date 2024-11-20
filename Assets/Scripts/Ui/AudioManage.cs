using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManage : MonoBehaviour
{
    [HideInInspector]public AudioSource audioSource;
    public AudioClip audioClip;
    public static AudioManage Instance { get; private set; }
    void Awake()
    {
         if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
     void Start()
     {
        audioSource = gameObject.AddComponent<AudioSource>();
     }
    public void AudidoClick(){
        audioSource.PlayOneShot(audioClip);
    }
    public void AudioShowPanel(){
        AudioClip clip=Resources.Load<AudioClip>("Audio/AudioShow");
        audioSource.PlayOneShot(clip);
    }
    public void AudioClosePanel(){
        AudioClip clip=Resources.Load<AudioClip>("Audio/AudioClose");
        audioSource.PlayOneShot(clip);
    }
    public void OffAudio(){
        audioSource.volume=0;
    }
}
