using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    Text healthText;
    PlayerCollision player;
    private void Awake()
    {
        healthText = GetComponent<Text>();
        player = FindObjectOfType<PlayerCollision>();
    }

    void Update()
    {
        healthText.text = player.GetHealth().ToString();
    }
}
