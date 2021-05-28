using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
    {
    public class Panel : MonoBehaviour
    {
        [SerializeField] GameObject pauseMenu;
        bool isPaused;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (isPaused)
            {
                OnPauseEnbaled();
            }

            else
            {
                OnPauseDisabled();
            }
        }

        void OnPauseEnbaled()
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }

        void OnPauseDisabled()
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
