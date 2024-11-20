using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class AutoGridLayout : MonoBehaviour
{
    public int rows = 3; // Số hàng mong muốn
    public int columns = 2; // Số cột mong muốn

    private GridLayoutGroup gridLayout;
    private RectTransform rectTransform;

    void Start()
    {
        gridLayout = GetComponent<GridLayoutGroup>();
        rectTransform = GetComponent<RectTransform>();

        UpdateCellSize();
    }

    void UpdateCellSize()
    {
        // Tính toán kích thước của từng cell dựa trên kích thước của RectTransform
        float width = rectTransform.rect.width / columns - gridLayout.spacing.x * (columns - 1) / columns;
        float height = rectTransform.rect.height / rows - gridLayout.spacing.y * (rows - 1) / rows;

        gridLayout.cellSize = new Vector2(width, height);
    }

    void OnRectTransformDimensionsChange()
    {
        UpdateCellSize();
    }
}
