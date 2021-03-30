using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class attached to game object that contains attacks.
/// </summary>
public class AttackManager : MonoBehaviour
{
    [SerializeField]
    private UnitType unitType=UnitType.player;

    private enum UnitType { player, enemy };
    private List<Attack> attackList=new List<Attack>();

    private void Start()
    {
        switch (unitType)
        {
            case UnitType.player:
                {
                    attackList.Add(new BasicAttack());
                    return;
                }
        }
        //attackList.Add(new BasicAttack());
    }

    public Attack GetAttack()
    {
        return attackList[0];
    }
}
