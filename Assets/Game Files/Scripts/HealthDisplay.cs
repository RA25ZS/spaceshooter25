using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    Text healthText;
    PlayerMovement player;
    private void Awake()
    {
        healthText = GetComponent<Text>();
        player = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        healthText.text = player.GetHealth().ToString();
    }
}
