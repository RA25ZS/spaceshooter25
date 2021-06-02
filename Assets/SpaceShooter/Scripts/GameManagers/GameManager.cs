using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceShooter
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] GameObject pausePanel;
        [SerializeField] float delayInSeconds = 2.5f;   

        public void StartGame()
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }

        public void LoadGame()
        {
            SceneManager.LoadScene(1);
            FindObjectOfType<GameSession>().ResetGame();
        }

        public void LoadGameOver()
        {
            StartCoroutine(WaitAndLoad());
        }

        IEnumerator WaitAndLoad()
        {
            yield return new WaitForSeconds(delayInSeconds);
            SceneManager.LoadScene(4);
        }

        public void Quit()
        {
            Application.Quit();
        }

        public void LoadSettingsScreen()
        {
            SceneManager.LoadScene("Settings");
            Time.timeScale = 1;
        }

        public void OnPauseActive()
        {
            
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }

        public void OnPauseInactive()
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
    }
}