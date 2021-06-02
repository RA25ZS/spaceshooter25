using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class GameSession : MonoBehaviour
    {
        int score = 0;

        private void Awake()
        {
            SetUpSingleton();
        }

        private void SetUpSingleton()
        {
            int numbergameSessions = FindObjectsOfType<GameSession>().Length;
            if (numbergameSessions > 1)
            {
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }
        }

        public int GetScore()
        {
            return score;
        }

        public void AddToScore(int scoreValue)
        {
            score += scoreValue;
        }

        public void ResetGame()
        {
            Destroy(gameObject);
        }
    }
}