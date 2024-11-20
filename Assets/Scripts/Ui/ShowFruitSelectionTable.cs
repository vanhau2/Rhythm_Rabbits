using System;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UI;

public class ShowFruitSelectionTable : MonoBehaviour
{
    [Serializable]
    public class ListFruit
    {
        public Image imgFruit;
        public Button btnChoose;
        public Button btnDone;
    }

    public Button Selection;
    public Image FruitGame;
    public List<ListFruit> listFruits;
    [SerializeField] private GameObject PanelFruit;

    private readonly Vector2 PositionStart = new Vector2(360f, 1421f);
    private readonly Vector2 PositionLast = new Vector2(360f, 905f);

    void Start()
    {
       
        // Debug.Log("vị trí hiện tại"+PanelFruit.transform.position);

        if (ButtonManager.Instance != null && ButtonManager.Instance.listFruits.Count > 0)
        {
            DisplayImage();
        }
        else
        {
            Debug.LogWarning("ButtonManager hoặc danh sách bài hát trống.");
        }

        Selection.onClick.AddListener(ShowTableFruit);
        for (int i = 0; i < listFruits.Count; i++)
        {
            int index = i;
            listFruits[index].btnChoose.onClick.AddListener(() => SelectionFruit(index));
        }
        LoadSelectedFruit();
         Debug.Log("Saved Sprite: " + ButtonManager.Instance.LoadSelectedSprite());
    }

   private void LoadSelectedFruit()
{
    // Lấy index đã lưu trong PlayerPrefs (mặc định -1 nếu chưa có)
    int selectedIndex = ButtonManager.Instance.LoadSelectedSprite();

    if (selectedIndex == -1 || selectedIndex >= listFruits.Count)
    {
        // Nếu không có index lưu trữ hoặc index không hợp lệ => dùng ảnh mặc định
        Debug.Log("No saved index found or index invalid. Using default.");
        if (listFruits.Count > 0)
        {
            FruitGame.sprite = listFruits[0].imgFruit.sprite;
            listFruits[0].btnDone.gameObject.SetActive(true);
            listFruits[0].btnChoose.gameObject.SetActive(false);
        }
        return;
    }

    // Hiển thị ảnh từ danh sách dựa trên index đã lưu
    ResetButtons();
    FruitGame.sprite = listFruits[selectedIndex].imgFruit.sprite;
    listFruits[selectedIndex].btnDone.gameObject.SetActive(true);
    listFruits[selectedIndex].btnChoose.gameObject.SetActive(false);
    Debug.Log("Loaded SelectedFruitIndex: " + selectedIndex);
}

    private void SelectionFruit(int index)
    {
        ResetButtons();

        FruitGame.sprite = listFruits[index].imgFruit.sprite;
        listFruits[index].btnDone.gameObject.SetActive(true);
        listFruits[index].btnChoose.gameObject.SetActive(false);

        // Lưu lại index đã chọn vào PlayerPrefs
        ButtonManager.Instance.SaveSelectedSprite(index);

        Debug.Log("Saved SelectedFruitIndex: " + index);

        RectTransform rectTransform=PanelFruit.GetComponent<RectTransform>();
        rectTransform.DOAnchorPosY(200f,0.5f).SetEase(Ease.InBounce);
        AudioManage.Instance.AudioClosePanel();

    }
    private void ResetButtons()
    {
        foreach (var fruit in listFruits)
        {
            fruit.btnChoose.gameObject.SetActive(true);
            fruit.btnDone.gameObject.SetActive(false);
        }
    }

    private void DisplayImage()
    {
        int count = Mathf.Min(listFruits.Count, ButtonManager.Instance.listFruits.Count);
        for (int i = 0; i < count; i++)
        {
            listFruits[i].imgFruit.sprite = ButtonManager.Instance.listFruits[i].imgFruit;
        }
    }

    public void ShowTableFruit()
    {
        //LeanTween.movean(PanelFruit, PositionLast, 0.7f).setEase(LeanTweenType.easeOutBounce);
        RectTransform rectTransform = PanelFruit.GetComponent<RectTransform>();
        rectTransform.DOAnchorPosY(-450f,0.5f).SetEase(Ease.OutBounce);
        AudioManage.Instance.AudioShowPanel();
    }
}
