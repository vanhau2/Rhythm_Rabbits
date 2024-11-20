using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class OnOffbuton : MonoBehaviour
{

    public UnityEngine.UI.Button MusicOn;
    public UnityEngine.UI.Button AudioOn;
    
    public UnityEngine.UI.Button MusicOff;
    public UnityEngine.UI.Button AudioOff;

   public Amthanh GetAmthanh;
    
    private bool isMusicOn ;
    private bool isAudioOn ;

    void Start()
    {
        // isAudioOn = PlayerPrefs.GetInt("isAudioOn", 1) == 1;
        isAudioOn=ButtonManager.Instance.IsAudioOn;
        MusicOn.onClick.AddListener(()=>ToggleMusic(false));
        MusicOff.onClick.AddListener(()=>ToggleMusic(true));
        AudioOn.onClick.AddListener(()=>ToggleAudio(false));
        AudioOff.onClick.AddListener(()=>ToggleAudio(true));
        if(GetAmthanh==null){
            GetAmthanh=FindObjectOfType<Amthanh>();
        }
        ApplyAudioState();
    }
    private void  ApplyAudioState(){
        if(isAudioOn){
            AudioOn.gameObject.SetActive(true);
            AudioOff.gameObject.SetActive(false);
            if(GetAmthanh.audioSource!=null){
                GetAmthanh.audioSource.volume=1f;
                
            } 
            AudioManage.Instance.audioSource.volume=1f;
           
        }
        else{
            AudioOn.gameObject.SetActive(false);
            AudioOff.gameObject.SetActive(true);
            if(GetAmthanh.audioSource!=null){
                GetAmthanh.audioSource.volume=0f;
            }  
            AudioManage.Instance.OffAudio();
        }
    }

    private void ToggleMusic(bool turnOn)
    {
        isMusicOn=turnOn;
        if(isMusicOn){
            MusicOn.gameObject.SetActive(true);
            MusicOff.gameObject.SetActive(false);
            
            
        }
        else{
             MusicOn.gameObject.SetActive(false);
            MusicOff.gameObject.SetActive(true);
            
           
        }
    }   
    private void ToggleAudio(bool turnOn)
    {
        isAudioOn=turnOn;
       ApplyAudioState(); 
       ButtonManager.Instance.SetAudioState(isAudioOn);
      
        
        
    }   
    
}