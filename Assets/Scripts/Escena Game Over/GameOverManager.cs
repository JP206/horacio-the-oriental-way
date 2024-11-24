using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    // Método para cargar una escena específica (como Dojo)
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Método para salir del juego
    public void ExitGame()
    {
        // Sale del juego (esto funciona solo en la build, no en el editor)
        Application.Quit();
    }
}
