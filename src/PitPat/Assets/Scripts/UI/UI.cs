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
    [SerializeField]
    private Image sword;
    [SerializeField]
    private Image spear;
    [SerializeField]
    private Image axe;
    [SerializeField]
    private Image bow;

    private static GameObject staticSword;
    private static GameObject staticSpear;
    private static GameObject staticAxe;
    private static GameObject staticBow;

    public enum Weapons { Sword,Spear,Axe,Bow };
    public static Weapons currentWeapon = Weapons.Sword;

    private void Start()
    {
        staticSword = sword.gameObject;
        staticSpear = spear.gameObject;
        staticAxe = axe.gameObject;
        staticBow = bow.gameObject;
    }

    private void Update()
    {
        healthText.text = "Health: " + player.GetComponent<UnitProfile>().GetHealth().ToString();
        killTracker.text = "Total Kills: " + EnemyManager.enemiesKilled.ToString();
        highScore.text = "High Score: " + EnemyManager.highScore.ToString();
    }

    public static void SwitchWeapon()
    {
        staticSword.gameObject.SetActive(false);
        staticSpear.gameObject.SetActive(false);
        staticAxe.gameObject.SetActive(false);
        staticBow.gameObject.SetActive(false);
        switch (currentWeapon)
        {
            case Weapons.Sword:
                staticSword.gameObject.SetActive(true);
                break;
            case Weapons.Spear:
                staticSpear.gameObject.SetActive(true);
                break;
            case Weapons.Axe:
                staticAxe.gameObject.SetActive(true);
                break;
            case Weapons.Bow:
                staticBow.gameObject.SetActive(true);
                break;
        }
    }
}
