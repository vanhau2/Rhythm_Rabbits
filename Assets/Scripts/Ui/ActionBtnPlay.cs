using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ActionBtnPlay : MonoBehaviour
{
    public Button[] BtnPlay;
    void Start()
    {
        for(int i=0;i<BtnPlay.Length;i++ )
        {
            int index=i;
            BtnPlay[index].onClick.AddListener(()=>ChangeScene(index));
        }
    }
    void ChangeScene(int index)
    {
        ButtonFunctions.PlayGameOnClick(index);
    }
}
