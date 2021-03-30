using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitProfile : MonoBehaviour
{
    private int maxHealth;
    private int currentHealth;

    public void Initialize(int startingHealth)
    {
        maxHealth = startingHealth;
        currentHealth = maxHealth;
    }

    public void ChangeHealth(int adjustment)
    {
        currentHealth += adjustment;
        if(currentHealth>maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if(currentHealth<=0)
        {
            Destroy(this.gameObject);
        }
    }

    public int GetHealth()
    {
        return currentHealth;
    }

}
