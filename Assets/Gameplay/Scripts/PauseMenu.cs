using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private bool gamePaused = false;
    [SerializeField] private GameObject pausePanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (!gamePaused)
        {
            Time.timeScale = 0;
            gamePaused = true;
            pausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            gamePaused = false;
            pausePanel.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
