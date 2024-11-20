using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPosition : MonoBehaviour
{
    private AudioSource audioSource; // Kéo thả AudioSource từ Inspector
    public float standardDelay = 3f; // Thời gian delay trước khi phát
    private float newDelay = 0f;
    private bool fastPlay = false;
    private float playAtPosition = 0f; // Vị trí phát mong muốn (giây)
    public float delay0 = 0.5f;
    public float delay1 = 0.5f;
    public float playAt = 0.8f;
    public float delay3 = 1.4f;
    public float delay4 = 0.6f;
    public float delay5 = 0.6f;
    public float delay6 = 0.9f;
    public float delay7 = 0.6f;
    public float delay8 = 0.6f;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on GameObject.");
        }
        else
        {
            StartCoroutine(PlayAudioWithDelay());
        }
    }

    private IEnumerator PlayAudioWithDelay()
    {
        int Index = ButtonManager.Instance.GetCurrentIndex();

        switch (Index)
        {
            case 0:
                newDelay = standardDelay + delay0;
                break;
            case 1:
                newDelay = standardDelay + delay1;
                break;
            case 2:
                fastPlay = true;
                playAtPosition = playAt;
                break;
            case 3:
                newDelay = standardDelay + delay3;
                break;
            case 4:
                newDelay = standardDelay + delay4;
                break;
            case 5:
                newDelay = standardDelay + delay5;
                break;
            case 6:
                newDelay = standardDelay + delay6;
                break;
            case 7:
                newDelay = standardDelay + delay7;
                break;
            case 8:
                newDelay = standardDelay + delay8;
                break;
        }

        if (fastPlay)
        {
            string audioPath = ButtonManager.Instance.AudioClipPath;
            AudioClip clip = Resources.Load<AudioClip>(audioPath);

            if (clip != null)
            {
                audioSource.clip = clip; // Gán clip đã tải vào AudioSource
                audioSource.time = playAtPosition; // Đặt thời điểm phát
                audioSource.Play(); // Bắt đầu phát từ playAtPosition
            }
            else
            {
                Debug.LogError("AudioClip not found at path: " + audioPath);
            }
        }
        else
        {
            yield return new WaitForSeconds(newDelay);
            string audioPath = ButtonManager.Instance.AudioClipPath;
            AudioClip clip = Resources.Load<AudioClip>(audioPath);
if (clip != null)
            {
                audioSource.clip = clip; // Gán clip đã tải vào AudioSource
                audioSource.Play(); // Phát từ đầu
                Debug.LogWarning("Playing AudioClip: " + audioPath);
            }
            else
            {
                Debug.LogError("AudioClip not found at path: " + audioPath);
            }
        }
    }
}