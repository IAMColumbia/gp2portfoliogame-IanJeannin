using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitProfile : MonoBehaviour
{
    private float maxHealth;
    private float currentHealth;

    public void Initialize(int startingHealth)
    {
        maxHealth = startingHealth;
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
