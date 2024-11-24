using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    // M�todo para cargar una escena espec�fica (como Dojo)
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // M�todo para salir del juego
    public void ExitGame()
    {
        // Sale del juego (esto funciona solo en la build, no en el editor)
        Application.Quit();
    }
}
