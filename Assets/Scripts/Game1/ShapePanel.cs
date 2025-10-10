using UnityEngine;
using UnityEngine.UI;

public class ShapePanel : MonoBehaviour
{
    [SerializeField] private Image shapeImage;

    public void UpdateShape(Sprite newShape)
    {
        if (shapeImage != null)
            shapeImage.sprite = newShape;
    }
}
