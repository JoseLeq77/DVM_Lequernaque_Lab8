using UnityEngine;

public class PlayerColorShapeController : MonoBehaviour
{
    [SerializeField] private ColorShapeData playerData;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [Header("References UI")]
    [SerializeField] private ColorPanel colorPanel;
    [SerializeField] private ShapePanel shapePanel;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        playerData.SetColor(spriteRenderer.color);
        playerData.SetSprite(spriteRenderer.sprite);
        SetUp();
    }

    private void OnEnable()
    {
        ColorObject.OnChangeColor += OnColorChanged;
        ShapeObject.OnChangeShape += OnShapeChanged;
    }

    private void OnDisable()
    {
        ColorObject.OnChangeColor -= OnColorChanged;
        ShapeObject.OnChangeShape -= OnShapeChanged;
    }

    private void SetUp()
    {
        spriteRenderer.color = playerData.Color;
        spriteRenderer.sprite = playerData.Sprite;
        colorPanel.UpdateColor(playerData.Color);
        shapePanel.UpdateShape(playerData.Sprite);
    }

    private void OnColorChanged(Color newColor)
    {
        playerData.SetColor(newColor);
        spriteRenderer.color = newColor;
        colorPanel?.UpdateColor(newColor);
    }

    private void OnShapeChanged(Sprite newSprite)
    {
        playerData.SetSprite(newSprite);
        spriteRenderer.sprite = newSprite;
        shapePanel?.UpdateShape(newSprite);
    }
}
