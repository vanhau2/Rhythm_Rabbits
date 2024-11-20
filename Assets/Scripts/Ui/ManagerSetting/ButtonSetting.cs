using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.Experimental.GlobalIllumination;


public class ButtonSetting : MonoBehaviour
{
    // Start is called before the first frame update
    public Button buttonSetting;
    public Button buttonQuit;
    public Image PanelSetting;
    public Image Table;


    void Start()
    {
        Table.gameObject.transform.localScale = Vector2.zero;
        PanelSetting.gameObject.SetActive(false);
        buttonSetting.onClick.AddListener(OpenPanel);
        buttonQuit.onClick.AddListener(ClosePanel);
    }
    void OpenPanel()
    {

        if (!PanelSetting.gameObject.activeSelf)
        {
            PanelSetting.gameObject.SetActive(true);
            // Sử dụng DoTween để tăng alpha lên 1
            PanelSetting.DOFade(120f / 255f, 0.5f);
            
                RectTransform rectTransform = Table.GetComponent<RectTransform>();
                rectTransform.DOScale(Vector2.one, 0.5f).SetEase(Ease.OutBounce);
            
            // PanelSetting.transform.localScale=Vector3.zero;

            // LeanTween.scale(PanelSetting,Vector3.one,0.5f).setEaseInCubic();
        }
    }
    void ClosePanel()
    {
        RectTransform rectTransform = Table.GetComponent<RectTransform>();
        rectTransform.DOScale(Vector2.zero, 0.5f).SetEase(Ease.InBounce);
        
            PanelSetting.DOFade(0f, 0.5f).OnComplete(() =>
            {
                PanelSetting.gameObject.SetActive(false);
            });
        

        // LeanTween.scale(PanelSetting,Vector3.zero,0.2f).setEaseInOutCubic().setOnComplete(()=>
        // {
        //     PanelSetting.SetActive(false);
        // });

    }

    // Update is called once per frame
    void Update()
    {

    }
}
