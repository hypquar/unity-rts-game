using UnityEngine;

public class TogglePause : MonoBehaviour
{

    public GameObject pauseMenu;
    public bool isPaused = false;


    public void TogglePauseMenu()
    {
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
    }
}
