using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using JetBrains.Annotations;
using UnityEngine.UI;

public class TextHyperlinkHandler : MonoBehaviour
{
   [SerializeField] private string url="";
   public Button Privacy;
   public Button Service;
   public  void Start()
   {
        Privacy.onClick.AddListener(() => OpenLink("privacy"));
        Service.onClick.AddListener(() => OpenLink("service"));
   }
    public void OpenLink(string name){
        switch (name)
        {
            case "privacy":
            url="https://www.king.com/vi/privacyPolicy";
            Application.OpenURL(url);
            break;

            case "service":
            url="https://www.king.com/vi/termsAndConditions";
            Application.OpenURL(url);
            break;
            default:
                Debug.LogError("Không có loại name phù hợp: " + name);
            break;
        }
        
    }
}
