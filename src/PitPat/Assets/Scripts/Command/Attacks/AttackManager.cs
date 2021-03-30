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
    [SerializeField]
    private List<AttackType> attackTypes;

    private enum UnitType { player, enemy };
    private enum AttackType { basic };

    //private AttackType attackType = new AttackType();
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
            case UnitType.enemy:
                {
                    SetAttackList();
                    return;
                }
        }
        //attackList.Add(new BasicAttack());
    }

    public Attack GetAttack()
    {
        return attackList[0];
    }

    public void SetAttackList()
    {
        if(attackTypes!=null)
        {
            for (int x = 0; x < attackTypes.Count; x++)
            {
                Attack newAttack;
                switch (attackTypes[x])
                {
                    case AttackType.basic:
                        {
                            newAttack = new BasicAttack();
                            break;
                        }
                }
            }
        }
        
    }
}
