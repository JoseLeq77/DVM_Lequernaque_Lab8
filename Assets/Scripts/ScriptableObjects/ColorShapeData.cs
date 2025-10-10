using UnityEngine;

[CreateAssetMenu(fileName = "Color Shape Data", menuName = "Scriptable Objects/Game 1/ColorShapeData")]
public class ColorShapeData : ScriptableObject
{
    #region Variables

    [Header("Data")]
    [SerializeField] private Color color;
    [SerializeField] private Sprite sprite;

    #endregion

    #region Getters
    public Color Color => color;
    public Sprite Sprite => sprite;

    #endregion

    #region Setters
    public void SetColor(Color newColor)
    {
        color = newColor;
    }

    public void SetSprite(Sprite newSprite)
    {
        sprite = newSprite;
    }

    #endregion
}
