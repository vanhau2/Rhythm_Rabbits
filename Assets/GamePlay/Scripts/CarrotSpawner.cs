using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Note
{
    public float duration;
    public int durationTicks;
    public int midi;
    public string name;
    public int ticks;
    public float time;
    public float velocity;
}

[System.Serializable]
public class NoteList
{
    public List<Note> notes;
}

public class CarrotSpawner : MonoBehaviour
{
    public GameObject fruitPrefab; // Kéo thả prefab trái cây vào đây trong Inspector
    // public string jsonFilePath = "Assets/StreamingAssets/notes.json"; // Path to the JSON file
    public List<Note> notes; // List of notes loaded from JSON
    public float fixedSpeed = 2f; // Tốc độ rơi cố định cho tất cả các củ cà rốt

    public int point;
    private int heart;
    public TextMeshProUGUI textMeshProUGUI;
    private void Start()
    {
        string jsonFilePath = ButtonManager.Instance.JsonFilePath;
        LoadNotesFromJSON(jsonFilePath); // Load note data from JSON
        StartCoroutine(SpawnFruits()); // Start spawning fruits
    }

    private void LoadNotesFromJSON(string path)
    {
        var textJson = Resources.Load<TextAsset>(path);

        if (textJson != null)
        {
            //string json = File.ReadAllText(path);
            NoteList noteList = JsonUtility.FromJson<NoteList>(textJson.text);
            notes = noteList.notes;
        }
        else
        {
            Debug.LogError("JSON file does not exist at path: " + path);
        }
    }

    private IEnumerator SpawnFruits()
    {
        float previousNoteTime = 0f; // Thời gian của nốt nhạc trước
        foreach (var note in notes)
        {
            float delay = note.time - previousNoteTime; // Tính thời gian chênh lệch giữa các nốt nhạc
            yield return new WaitForSeconds(delay); // Chờ theo thời gian chênh lệch
            previousNoteTime = note.time;

            // Tạo trái cây (cà rốt)
            Vector3 position = GetFruitPosition(note.midi); // Lấy vị trí dựa trên giá trị MIDI
            GameObject fruit = Instantiate(fruitPrefab, position, Quaternion.identity); // Tạo cà rốt
            MoveFruit(fruit); // Di chuyển cà rốt với tốc độ cố định
        }
        yield return new WaitForSeconds(5);
        point = int.Parse(textMeshProUGUI.text);
        ButtonManager.Instance.SetScore(point);
        ButtonManager.Instance.SaveHighScore(point);
        ButtonManager.Instance.SaveHighestStarsForLevel(ButtonManager.Instance.GetStars());
        ButtonManager.Instance.SetCoins(point);
        
        SceneManager.LoadScene("win");
    }
    private Vector3 GetFruitPosition(int midi)
    {
        // Determine X position based on MIDI values
        float x;
        if (midi >= 48 && midi <= 50)
        {
            x = -1.9f + (0.65f * (midi - 48)); // Maps 48 to -1.9, 49 to -1.25, 50 to -0.6
        }
        else if (midi >= 52 && midi <= 54) //54
        {
            x = 0.6f + (0.65f * (midi - 52)); // Maps 52 to 0.6, 53 to 1.25, 54 to 1.9
        }
        else
        {
            return Vector3.zero; // Return zero position for unsupported MIDI values
        }
        return new Vector3(x, 5, 0); // Return position with Y set to 7
    }
    private void MoveFruit(GameObject fruit)
    {
        // Di chuyển cà rốt với tốc độ cố định
        StartCoroutine(MoveFruitCoroutine(fruit));
    }

    private IEnumerator MoveFruitCoroutine(GameObject fruit)
    {
       Vector3 targetPosition = new Vector3(fruit.transform.position.x, -4f, fruit.transform.position.z); // Mục tiêu Y = -4
        float distance = fruit.transform.position.y - targetPosition.y; // Khoảng cách cần di chuyển

        // Di chuyển trái cây xuống dưới với tốc độ cố định
        while (fruit.transform.position.y > targetPosition.y)
        {
            fruit.transform.position = Vector3.MoveTowards(fruit.transform.position, targetPosition, fixedSpeed * Time.deltaTime);
            yield return null;
        }

        fruit.transform.position = targetPosition; // Đảm bảo đạt đúng vị trí cuối

        SpriteRenderer carrotImage = fruit.GetComponent<SpriteRenderer>(); // Lấy SpriteRenderer từ fruit

        // Tween alpha từ 1 đến 0 trong 1 giây
        LeanTween.value(gameObject, 1f, 0f, 1f).setOnUpdate((float val) =>
        {
            if (carrotImage != null)
            {
                carrotImage.color = new Color(carrotImage.color.r, carrotImage.color.g, carrotImage.color.b, val);
            }
        }).setOnComplete(() =>
        {
            Destroy(fruit); // Xóa object khi alpha đạt 0
        });
    }    
}