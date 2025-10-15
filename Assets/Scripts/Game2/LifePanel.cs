using TMPro;
using UnityEngine;

public class LifePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text LifeText;

    private void OnEnable()
    {
        GameManager.OnLifeUpdate += OnLifeUpdate;
    }

    private void OnDisable()
    {
        GameManager.OnLifeUpdate -= OnLifeUpdate;
    }

    private void Start()
    {
        LifeText.text = GameManager.Instance.playerLife.ToString();
    }

    private void OnLifeUpdate(int newLife)
    {
        if (LifeText != null)
        {
            LifeText.text = newLife.ToString();
        }
    }
}
