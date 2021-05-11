using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitProfile : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;

    private int defaultHealth = 5;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    //Used by other controller scripts if prefab doesn't have a UnitProfile
    public void Initialize()
    {
        maxHealth = defaultHealth;
        currentHealth = maxHealth;
    }

    public void ChangeHealth(float adjustment)
    {
        currentHealth += adjustment;
        if(this.gameObject.GetComponent<UnitUI>()!=null)
        {
            this.gameObject.GetComponent<UnitUI>().ChangeHealthBar(maxHealth, currentHealth);
        }
        if(currentHealth>maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if(currentHealth<=0)
        {
            if(this.gameObject.GetComponent<PlayerController>())
            {
                GameState.stateOfGame = GameState.StateOfGame.Menu;
                this.currentHealth = maxHealth;
                this.gameObject.GetComponent<UnitUI>().ChangeHealthBar(maxHealth, currentHealth);
                EnemyManager.ClearEnemies();
                this.gameObject.GetComponent<PlayerController>().Reset();
            }
            else if(this.gameObject.GetComponent<EnemyController>())
            {
                EnemyManager.KillEnemy(gameObject);
            }
        }
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

}
