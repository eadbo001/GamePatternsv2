using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
   [SerializeField] private string startupScene = "startScene";
   [SerializeField] private string gameScene = "gameScene";
   
   public static void StartGame()
    {
        Instance.LoadScene(Instance.gameScene);
    }

    public static void ReturnToMainMenu()
    {
        Instance.LoadScene(Instance.startupScene);
    }
    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void Update()
    {
        if (Keyboard.current != null &&
            Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (SceneManager.GetActiveScene().name != startupScene)
            {
                ReturnToMainMenu();
            }
        }
    }
}
