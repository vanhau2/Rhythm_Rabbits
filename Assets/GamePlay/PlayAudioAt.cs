using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioAt : MonoBehaviour
{

    public AudioSource audioSource; // AudioSource của bài hát
    public float startTime = 0f; // Thời gian bắt đầu phát nhạc (tính bằng giây)

    void Start()
    {
        // Đặt thời điểm phát nhạc
        audioSource.time = startTime;

        // Bắt đầu phát nhạc
        audioSource.Play();
    }
}
