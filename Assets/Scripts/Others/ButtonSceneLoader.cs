using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonSceneLoader : MonoBehaviour
{
    [SerializeField] private string[] Scenes;
    [SerializeField] private Button[] Buttons;

    public void Start()
    {
        AsignChangeScene();
    }

    public void AsignChangeScene()
    {
        if (Buttons.Length != Scenes.Length)
        {
            Debug.LogWarning("El numero de botones y escenas no coincide");
        }

        for (int i = 0; i < Buttons.Length; i++)
        {
            int index = i; 

            if (Buttons[i] != null && Scenes[i] != null)
            {
                Buttons[index].onClick.AddListener(() => ChangeScene(Scenes[index]));
            }
        }
    }
   
    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ExitGame()
    {
        Debug.Log("Saliendo del juego");
        Application.Quit();
    }
}
