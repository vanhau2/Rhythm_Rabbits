using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TweenButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float timeTween = 0.2f; // Thời gian tween, có thể điều chỉnh trong Inspector
    private LTDescr tween;
    [SerializeField] private Button Play; // Nút cần hiệu ứng
    [SerializeField] private LeanTweenType leanTween; // Kiểu easing của LeanTween

    // void Start()
    // {
    //     ScalingEffect();
    // }
    public void OnPointerDown(PointerEventData eventData)
    {
        // Khi nhấn giữ, nút nhỏ lại
        LeanTween.scale(Play.gameObject, new Vector3(0.6f, 0.6f, 1f), timeTween).setEase(leanTween);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Khi thả ra, nút quay về kích thước ban đầu
        LeanTween.scale(Play.gameObject, new Vector3(1f, 1f, 1f), timeTween).setEase(leanTween);
    }

    // void ScalingEffect()
    // {
       
    //     if (tween != null)
    //     {
    //         LeanTween.cancel(tween.id);
    //     }
    //     tween = LeanTween.scale(Play.gameObject, new Vector3(0.8f, 0.8f, 0.8f), 0.75f)
    //         .setLoopPingPong()
    //         .setEase(LeanTweenType.easeInOutSine);
    // }
}
