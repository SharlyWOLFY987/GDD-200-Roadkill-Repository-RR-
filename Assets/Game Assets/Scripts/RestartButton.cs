using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
   
    public void restartGameFromTimeOutScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void restartGameFromDamagedScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }

    public void restartGameFromCredibilityScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    
    public void restartGameFromVictoryScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
    }

}
