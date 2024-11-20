using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGamePlay : MonoBehaviour
{
    public Button Pause;
    public Button Continue;
    public Button Quit;
    public GameObject table;
    public GameObject PanelPause;
    public Button Restart;
    public Button Other;
    [SerializeField] private Image panel;
    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        Pause.onClick.AddListener(HidiPause);
        Continue.onClick.AddListener(ClosePanelPause);
        Quit.onClick.AddListener(ClosePanelPause);
        Restart.onClick.AddListener(() => ChangeScene("Restart"));
        Other.onClick.AddListener(() => ChangeScene("Other"));
        if (audioSource == null)
        {
            audioSource = GameObject.Find("Song").GetComponent<AudioSource>();
        }
    }

    void ChangeScene(string button)
    {   Time.timeScale=1f;
        if (button == "Restart")
        {
            ButtonFunctions.ButtonRestart();
        }
        else
        {
            SceneManager.LoadScene("LevelScene");
        }
    }

    // mở menu pause
    public void HidiPause()
    {
        PanelPause.SetActive(true);
        Time.timeScale = 0f;
        Color startColor = panel.color;
        startColor.a = 0f;
        panel.color = startColor;

        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
        LeanTween.value(0f, 100f / 255f, 0.2f).setOnUpdate((float alpha) =>
        {
            Color color = panel.color;
            color.a = alpha;
            panel.color = color;
        }).setIgnoreTimeScale(true);


        table.transform.localScale = Vector3.zero;
        LeanTween.scale(table, Vector3.one, 0.2f).setEase(LeanTweenType.easeInExpo).setIgnoreTimeScale(true);

        // Ẩn nút Pause và hiển thị nút Continue
        Pause.gameObject.SetActive(false);
        Continue.gameObject.SetActive(true);
    }

    // đóng menu pause
    public void ClosePanelPause()
    {
        LeanTween.scale(table, Vector3.zero, 0.2f).setEase(LeanTweenType.easeOutExpo).setIgnoreTimeScale(true);

        LeanTween.value(100f / 255f, 0f, 0.2f).setOnUpdate((float alpha) =>
        {
            Color color = panel.color;
            color.a = alpha;
            panel.color = color;
        }).setIgnoreTimeScale(true).setOnComplete(() =>
        {
            // Đặt lại trạng thái của các nút và menu
            PanelPause.SetActive(false);
            Continue.gameObject.SetActive(false);
            Pause.gameObject.SetActive(true);
            Time.timeScale = 1f;
            if (!audioSource.isPlaying)
            {
                audioSource.UnPause();
            }
        });
    }
}
