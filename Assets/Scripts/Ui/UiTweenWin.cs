using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class UiTweenWin : MonoBehaviour
{
    public Button ButtonNext;
    public Button Buttonrestart;
    public Button ButtonOther;
    public TextMeshProUGUI Score;
    // private LevelSceneController levelSceneController;

    // Start is called before first frame update
    [SerializeField]
    GameObject Container, StartOne, StartTwo, StartThree, Next, Restart, Other;

    void Start()
    {
        LeanTween.moveLocal(Container, new Vector3(-0.9f, -0.34f, 0f), .7f).setDelay(0.4f).setEase(LeanTweenType.easeOutCubic).setOnComplete(Function);
        ButtonNext.onClick.AddListener(() => OnButtonClick("Next"));
        Buttonrestart.onClick.AddListener(() => OnButtonClick("Restart"));
        ButtonOther.onClick.AddListener(() => OnButtonClick("Other"));
    }

    // Update is called once per frame
    void Function()
    {
        LeanTween.scale(Next, new Vector3(1f, 1f, 1f), 2f).setDelay(0.05f).setEase(LeanTweenType.easeOutElastic).setOnComplete(Starts);
        LeanTween.scale(Restart, new Vector3(1f, 1f, 1f), 2f).setDelay(0.1f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Other, new Vector3(1f, 1f, 1f), 2f).setDelay(0.1f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.delayedCall(0.1f, Starts);
        Score.text = ButtonManager.Instance.GetScore().ToString();
    }
    void OnButtonClick(string buttonType)
    {
        switch (buttonType)
        {
            case "Next":

                LeanTween.moveLocal(Container, new Vector3(8f, -.34f, 0.5f), .7f).setEase(LeanTweenType.easeInCubic)
                .setOnComplete(() =>
                {
                    ButtonFunctions.ButtonNext();
                    // ButtonManager.Instance.IncrementIndex();

                    // if (ButtonManager.Instance.CurrentIndex >= 0 && ButtonManager.Instance.CurrentIndex < ButtonManager.Instance.listSong.Count)
                    // {
                    //     SongData song = ButtonManager.Instance.listSong[ButtonManager.Instance.CurrentIndex];

                    //     string pathMidi = song.PathMidi;
                    //     ButtonManager.Instance.SetJsonFilePath(pathMidi);
                    //     string pathAudio = song.PathAudio;
                    //     ButtonManager.Instance.SetAudioClipPath(pathAudio);
                    // } if (ButtonNext !=null){
                    //     ButtonNext.gameObject.SetActive(ButtonManager.Instance.CurrentIndex < ButtonManager.Instance.listSong.Count - 1);
                    // }
                    SceneManager.LoadScene("GamePlay");
                });
                break;
            case "Restart":
                LeanTween.moveLocal(Container, new Vector3(10f, -.34f, .5f), .7f)
                    .setEase(LeanTweenType.easeInCubic).setOnComplete(() =>
                    {
                        ButtonFunctions.ButtonRestart();
                    });
                break;

            case "Other":
                LeanTween.moveLocal(Container, new Vector3(10f, -.34f, 0.5f), .7f)
                    .setEase(LeanTweenType.easeInCubic)
                    .setOnComplete(() => SceneManager.LoadScene("LevelScene"));
                break;

            default:
                Debug.LogError("Không có loại button phù hợp: " + buttonType);
                break;
        }

    }

    void Starts()
    {
        int star = ButtonManager.Instance.GetStars();
        switch (star)
        {
            case 3:
                LeanTween.scale(StartOne, new Vector3(1f, 1f, 1f), 2f).setDelay(.5f).setEase(LeanTweenType.easeOutCubic);
                LeanTween.scale(StartTwo, new Vector3(1f, 1f, 1f), 2f).setDelay(.7f).setEase(LeanTweenType.easeOutCubic);
                LeanTween.scale(StartThree, new Vector3(1f, 1f, 1f), 2f).setDelay(1f).setEase(LeanTweenType.easeOutCubic);
                break;
            case 2:
                LeanTween.scale(StartOne, new Vector3(1f, 1f, 1f), 2f).setDelay(.5f).setEase(LeanTweenType.easeOutCubic);
                LeanTween.scale(StartTwo, new Vector3(1f, 1f, 1f), 2f).setDelay(.7f).setEase(LeanTweenType.easeOutCubic);
                break;
            case 1:
                LeanTween.scale(StartThree, new Vector3(1f, 1f, 1f), 2f).setDelay(.5f).setEase(LeanTweenType.easeOutCubic);
                break;
        }


    }

    void Update()
    {

    }
}
