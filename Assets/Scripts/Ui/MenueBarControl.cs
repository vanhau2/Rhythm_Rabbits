using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenueBarControl : MonoBehaviour
{
    public Button ButtonLevel;
    public Button ButtonHome;
    private Color ColorActive = Color.white;
    private Color ColorInactive = new Color(128f / 255f, 109f / 255f, 0f);
    private float SizeActive = 250f;
    private float SizeInactive = 200f;

    void Start()
    {
        ButtonLevel.onClick.AddListener(() => OnClickButton(ButtonLevel, "LevelScene"));
        ButtonHome.onClick.AddListener(() => OnClickButton(ButtonHome, "MainGame"));
        
      SetActiveButton();
    }
    private void SetActiveButton()
{
    string activeButton = ButtonManager.Instance.GetActiveButton();

    if (ButtonLevel.name == activeButton)
    {
        SetButtonActive(ButtonLevel);
    }
    else if (ButtonHome.name == activeButton)
    {
        SetButtonActive(ButtonHome);
    }
    else
    {
        SetButtonActive(ButtonHome);
        ButtonManager.Instance.SetActiveButton(ButtonHome.name); 
    }
}


    void OnClickButton(Button buttonClick, string nameScene)
    {
        SetButtonInactive(ButtonLevel);
        SetButtonInactive(ButtonHome);
        
       
        SetButtonActive(buttonClick);
        ButtonManager.Instance.SetActiveButton(buttonClick.name); 
        
        SceneManager.LoadScene(nameScene);
         
    }

    private void SetButtonActive(Button button)
    {
        button.GetComponent<Image>().color = ColorActive;
        RectTransform rt = button.GetComponent<RectTransform>();
        LeanTween.size(rt, new Vector2(SizeActive, SizeActive), 0.2f).setEase(LeanTweenType.easeInOutCubic);
    }

    private void SetButtonInactive(Button button)
    {
        button.GetComponent<Image>().color = ColorInactive;
        RectTransform rt = button.GetComponent<RectTransform>();
        LeanTween.size(rt, new Vector2(SizeInactive, SizeInactive), 0.2f).setEase(LeanTweenType.easeInOutCubic);
    }
}
