using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Amthanh : MonoBehaviour
{
    public Button[] GetButton;
    public AudioClip audioClip;
    [HideInInspector] public AudioSource audioSource;




    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        for (int i = 0; i < GetButton.Length; i++)
        {
            int index = i;
            GetButton[i].onClick.AddListener(() => OnClickAudio(index));
        }

    }

    public void OnClickAudio(int btnindex)
    {
        if (audioSource != null && audioClip != null && ButtonManager.Instance.IsAudioOn)
        {
            audioSource.PlayOneShot(audioClip);
        }
        else
        {
            Debug.LogWarning("không thể chạy audio");
        }


    }

}
