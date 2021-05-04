using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    Text healthText;
    PlayerController player;
    private void Awake()
    {
        healthText = GetComponent<Text>();
        player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        healthText.text = player.GetHealth().ToString();
    }
}
