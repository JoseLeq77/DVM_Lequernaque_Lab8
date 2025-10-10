using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string[] Scenes;
    [SerializeField] private Button[] Buttons;

    public void Start()
    {
        AsignChangeScene();
    }

    public void AsignChangeScene()
    {
        for (int i = 0; i < Buttons.Length; i++)
        {
            if (Scenes[i] != null && Buttons[i] != null)
            {
                Buttons[i].onClick.AddListener(ChangeScene);
            }
        }
    }

    public void ChangeScene()
    {
        for (int i = 0; i < Scenes.Length; i++)
        {
            if (Scenes[i] != null && Buttons[i] != null)
            {
                SceneManager.LoadScene(Scenes[i]);
            }
        }
    }

    public void ExitGame()
    {
        Debug.Log("Saliendo del juego");
        Application.Quit();
    }
}
