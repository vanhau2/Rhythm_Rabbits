using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
public class ButtonManager : MonoBehaviour
{

    private const string AudioStateKey = "isAudio";
    private const string ActiveButtonKey = "ActiveButton";
    private const string HighScoreKey = "HighScore";
    private const string StarsKeyPrefix = "Stars_Level_";
    private const string CoinKey = "payerCoin";
    private const string SelectedSpriteKey = "SelectedSprite";
    public static ButtonManager Instance { get; private set; }
    public List<SongData> listSong;
    public List<ListFruit> listFruits;
    public int CurrentIndex { get; private set; } = -1;
    public int NumberHeart { get; private set; } = 0;
    public string JsonFilePath { get; private set; } = "Assets/StreamingAssets/.json";

    public string AudioClipPath { get; private set; } = "Assets/Audio/defaultClip";

    public int Score { get; private set; } = 0;
    public int Stars { get; private set; } = 0;
    private int Coins = 0;
    


    private void Awake()
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
        // PlayerPrefs.DeleteKey(CoinKey);
        // PlayerPrefs.Save();
        Coins = PlayerPrefs.GetInt(CoinKey, 0);
        Application.targetFrameRate = 60;

    }
    // lưu lại cấy trái rơt khi thay đổi
    public void SaveSelectedSprite(int index)
    {
        PlayerPrefs.SetInt(SelectedSpriteKey, index);
        PlayerPrefs.Save();
    }

    public int LoadSelectedSprite()
    {
        return PlayerPrefs.GetInt(SelectedSpriteKey, -1);
    }
    // lấy số sao user đạt được
    public void SetStars(int heart)
    {
        Stars = heart;
    }
    public int GetStars()
    {
        return Stars;
    }
    public void SaveHighestStarsForLevel(int stars)
    {
        int levelIndex = GetCurrentIndex();
        string starsKey = StarsKeyPrefix + levelIndex;

        int currentHighestStars = PlayerPrefs.GetInt(starsKey, 0);
        if (stars > currentHighestStars) // Chỉ lưu nếu sao hiện tại cao hơn sao đã lưu
        {
            PlayerPrefs.SetInt(starsKey, stars);
            PlayerPrefs.Save(); // Lưu lại số sao
        }
    }

    // Lấy số sao cao nhất đạt được cho một màn chơi cụ thể
    public int GetHighestStarsForLevel(int levelIndex)
    {
        string starsKey = StarsKeyPrefix + levelIndex;
        return PlayerPrefs.GetInt(starsKey, 0); // Mặc định là 0 nếu chưa có sao nào
    }
    // lấy điểm trong game play 
    public void SetScore(int point)
    {
        Score = point;
        SaveHighScore(point);
    }

    public void SaveHighScore(int score)
    {
        int levelIndex = GetCurrentIndex(); // Lấy chỉ số màn chơi hiện tại
        string highScoreKey = "HighScore_Level_" + levelIndex;

        int currentHighScore = PlayerPrefs.GetInt(highScoreKey, 0);
        if (score > currentHighScore)
        {
            PlayerPrefs.SetInt(highScoreKey, score);
            PlayerPrefs.Save(); // Lưu lại điểm số
        }
    }
    public int GetHighScoreForLevel(int levelIndex)
    {
        string highScoreKey = "HighScore_Level_" + levelIndex; // (HighScore_Level_+ levelIndex) key riêng của mỗi list game
        return PlayerPrefs.GetInt(highScoreKey, 0);
    }
    public int GetHighScore()
    {
        int levelIndex = GetCurrentIndex();
        string highScoreKey = "HighScore_Level_" + levelIndex;
        return PlayerPrefs.GetInt(highScoreKey, 0);
    }
    public int GetScore()
    {
        return Score;
    }
    // nhận và xử lý coin
    public void SetCoins(int point)
    {
        int earnedCoins = Mathf.FloorToInt(point * 0.1f);
        Debug.Log("Earned Coins: " + earnedCoins);
        AddCoins(earnedCoins);
    }

    // Thêm coin vào tổng số coin hiện tại
    public void AddCoins(int amount)
    {
        Coins += amount;
        SaveCoins();
    }

    // Lưu số coin hiện tại vào PlayerPrefs
    private void SaveCoins()
    {
        PlayerPrefs.SetInt(CoinKey, Coins);
        PlayerPrefs.Save();
    }

    // Lấy số coin hiện tại từ biến Coins (nếu cần lấy từ PlayerPrefs, gọi hàm LoadCoins())
    public int GetCoins()
    {
        return Coins;
    }

    // lấy chỉ số thứ tự của khi button được nhấn 
    public void SetCurrentIndex(int index)
    {
        CurrentIndex = index;
    }
    public int GetCurrentIndex()
    {
        return CurrentIndex;
    }
    public void IncrementIndex()
    {
        if (listSong.Count == 0) return;

        CurrentIndex = (CurrentIndex + 1) % listSong.Count;
        Debug.Log("Current index is now: " + CurrentIndex);
    }

    //lấy đường dẫn file midi
    public void SetJsonFilePath(string newPath)
    {
        JsonFilePath = newPath;
    }


    public void SetAudioClipPath(string newSong)
    {
        AudioClipPath = newSong;
    }
    public void SetActiveButton(string buttonName)
    {
        PlayerPrefs.SetString(ActiveButtonKey, buttonName);
        PlayerPrefs.Save();
    }

    public string GetActiveButton()
    {
        return PlayerPrefs.GetString(ActiveButtonKey, "homeButton");
    }
    public void SetAudioState(bool isAudioOn)
    {
        Debug.Log($"Setting audio state: {isAudioOn}");
        PlayerPrefs.SetInt(AudioStateKey, isAudioOn ? 1 : 0);
        PlayerPrefs.Save();
    }
    public bool IsAudioOn => PlayerPrefs.GetInt(AudioStateKey, 1) == 1;
    private void OnApplicationQuit()
    {

        ClearButtonState();
    }


    private void OnDestroy()
    {
        ClearButtonState();
    }

    public void ClearButtonState()
    {
        PlayerPrefs.DeleteKey(ActiveButtonKey);
        PlayerPrefs.Save();
    }
}
