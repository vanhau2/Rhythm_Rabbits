using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UiTweenLose : MonoBehaviour
{
    public Button ButtonRestart;
    public Button ButtonOther;
    public TMP_Text Number;

    
    // Start is called before the first frame update
    [SerializeField]
    GameObject Container,Restart,Other;
    void Start()
    {
       
        LeanTween.moveLocal(Container,new Vector3(-3f,-39f,0f),.7f).setEase(LeanTweenType.easeInOutCubic).setOnComplete(ButtonMotive);
        ButtonRestart.onClick.AddListener(()=> OnButtonClick("ButtonRestart"));
        ButtonOther.onClick.AddListener(()=> OnButtonClick("ButtonOther"));
       
    }

    void ButtonMotive(){
        LeanTween.scale(Restart,new Vector3(1f,1f,1f),2f).setDelay(.3f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Other,new Vector3(1f,1f,1f),2f).setDelay(.4f).setEase(LeanTweenType.easeOutElastic);
        Number.text=ButtonManager.Instance.GetScore().ToString();
    }
    void  OnButtonClick(string namebutton){
        switch(namebutton)
        {
            case "ButtonRestart":
            LeanTween.moveLocal(Container,new Vector3(900f,-51f,0f),.4f).setEase(LeanTweenType.easeInCubic)
            .setOnComplete(()=>{
                ButtonFunctions.ButtonRestart();
            });
            break;

            case "ButtonOther":
                SceneManager.LoadScene("LevelScene");
            break;
        }
    }
}
