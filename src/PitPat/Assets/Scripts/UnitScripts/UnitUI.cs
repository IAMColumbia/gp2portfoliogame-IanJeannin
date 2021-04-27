using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitUI : MonoBehaviour
{
    [SerializeField]
    private GameObject greenHealth;
    [SerializeField]
    private GameObject redHealth;


    public void ChangeHealthBar(float maxHealth,float currentHealth)
    {
        Vector3 greenHealthScale = greenHealth.transform.localScale;
        greenHealthScale.x = (float)currentHealth / maxHealth;
        greenHealth.transform.localScale = greenHealthScale;
    }
}
