using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class PlayAudioGameLevel : MonoBehaviour
{
    [System.Serializable]
    public class PlaySong
    {
        public GameObject listGame;
        public Button Play;
        public Button Pause;
    }

    public PlaySong[] playSongs;
    private AudioSource audioSource;
    private LTDescr tween;
    private int currentPlayingIndex = -1;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        for (int i = 0; i < playSongs.Length; i++)
        {
            int currentIndex = i;
            playSongs[currentIndex].Play.onClick.AddListener(() => PlayAudioGame(currentIndex));
            playSongs[currentIndex].Pause.onClick.AddListener(PauseAudioGame);
        }
    }

    private void PlayAudioGame(int index)
    {
        if (currentPlayingIndex != -1 && currentPlayingIndex != index)
        {
            PauseAudioGame();
        }
        currentPlayingIndex = index;
        SongData song = ButtonManager.Instance.listSong[index];
        string pathAudio = song.PathAudio;
        AudioClip clip = Resources.Load<AudioClip>(pathAudio);
        if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }

        playSongs[index].Play.gameObject.SetActive(false);
        playSongs[index].Pause.gameObject.SetActive(true);
        StartScalingEffect(playSongs[index].listGame);
    }

    private void StartScalingEffect(GameObject listGame)
    {
        // Dừng hiệu ứng cũ nếu có
        if (tween != null)
        {
            LeanTween.cancel(tween.id);
        }
        tween = LeanTween.scale(listGame, new Vector3(0.95f, 0.95f, 0.95f), 0.8f)
            .setLoopPingPong()    
            .setEase(LeanTweenType.easeInOutSine);  
    }
    private void PauseAudioGame()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
        StopScalingEffect();
        foreach (var playSong in playSongs)
        {
            playSong.Play.gameObject.SetActive(true);
            playSong.Pause.gameObject.SetActive(false);
        }
        currentPlayingIndex=-1;
    }

    private void StopScalingEffect()
    {
        if (tween != null)
        {
            LeanTween.cancel(tween.id); 
            tween = null;
        }
        foreach (var playSong in playSongs)
        {
            playSong.listGame.transform.localScale = Vector3.one;
        }
    }

    void Update()
    {
        if (!audioSource.isPlaying && currentPlayingIndex != -1)
    {
        StopScalingEffect();
        playSongs[currentPlayingIndex].Play.gameObject.SetActive(true);
        playSongs[currentPlayingIndex].Pause.gameObject.SetActive(false);
        currentPlayingIndex = -1;
    }
    }
}
