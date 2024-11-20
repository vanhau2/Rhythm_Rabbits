using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;
[Serializable]
public class UpdataScore : MonoBehaviour
{
    public TextMeshProUGUI[] Point;
    public Image[] StarsImages;
    public Sprite[] StarSprites;
    void Start()
    {
        UpdateAllHighScores();
        UpdateHighestStars();
    }

    public void UpdateAllHighScores()
    {
        for (int i = 0; i < Point.Length; i++)
        {
            string highScoreKey = "HighScore_Level_" + i;
            int highScore = PlayerPrefs.GetInt(highScoreKey, 0);

            if (i >= 0 && i < Point.Length)
            {
                Point[i].text = highScore.ToString();
            }
        }
    }

     public void UpdateHighestStars()
    {
        for (int i = 0; i < StarsImages.Length; i++)
        {
            int highestStars = ButtonManager.Instance.GetHighestStarsForLevel(i);
            if (highestStars >= 0 && highestStars <= 3)
            {
                StarsImages[i].sprite = StarSprites[highestStars];
            }
        }
    }
}
