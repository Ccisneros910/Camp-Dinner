using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuElement : MonoBehaviour
{
    [SerializeField] private int sceneToGoTo;

    public void GoToScene()
    {
        SceneManager.LoadScene(sceneToGoTo);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
