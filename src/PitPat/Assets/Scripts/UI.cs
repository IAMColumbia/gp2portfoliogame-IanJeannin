using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text healthText;
    [SerializeField]
    private TMP_Text killTracker;
    [SerializeField]
    private TMP_Text highScore;
    [SerializeField]
    private GameObject player;

    private void Update()
    {
        healthText.text = "Health: " + player.GetComponent<UnitProfile>().GetHealth().ToString();
        killTracker.text = "Total Kills: " + EnemyManager.enemiesKilled.ToString();
        highScore.text = "High Score: " + EnemyManager.highScore.ToString();
    }
}
