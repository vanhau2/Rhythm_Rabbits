using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;

public class DisplayGamename : MonoBehaviour{
     public TextMeshProUGUI[] gameNameTexts; // Mảng chứa các Text UI cho mỗi game

    void Start()
    {
    
        if (ButtonManager.Instance != null && ButtonManager.Instance.listSong.Count > 0)
        {
            DisplayGameNames(); 
        }
        else
        {
            Debug.LogWarning("ButtonManager hoặc danh sách bài hát trống.");
        }
    }
    public void DisplayGameNames()
    {
        int count = Mathf.Min(gameNameTexts.Length, ButtonManager.Instance.listSong.Count);

        for (int i = 0; i < count; i++)
        {
            gameNameTexts[i].text = ButtonManager.Instance.listSong[i].Name;
        }
    }
}
