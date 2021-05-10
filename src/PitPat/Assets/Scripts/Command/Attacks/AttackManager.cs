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
    private enum AttackType { basic, spear, bow, hatchets };

    //private AttackType attackType = new AttackType();
    private List<Attack> attackList=new List<Attack>();

    private int currentAttackIndex=0;

    private void Start()
    {
        switch (unitType)
        {
            case UnitType.player:
                {
                    SetAttackList();
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
        return attackList[currentAttackIndex];
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
                            attackList.Add(newAttack);
                            break;
                        }
                    case AttackType.bow:
                        {
                            newAttack = new RangedAttack();
                            attackList.Add(newAttack);
                            break;
                        }
                    case AttackType.spear:
                        {
                            newAttack = new SpearAttack();
                            attackList.Add(newAttack);
                            break;
                        }
                    case AttackType.hatchets:
                        {
                            newAttack = new HatchetsAttack();
                            attackList.Add(newAttack);
                            break;
                        }
                }
            }
        }
        
    }

    public void SwitchAttack(int newAttack)
    {
        if(newAttack>=0&&newAttack<attackList.Count)
        {
            currentAttackIndex = newAttack;
        }
        else if(newAttack<0)
        {
            currentAttackIndex = attackList.Count-1;
        }
        else if(newAttack>attackList.Count-1)
        {
            currentAttackIndex = 0;
        }
        switch (currentAttackIndex)
        {
            case 0:
                UI.currentWeapon = UI.Weapons.Sword;
                break;
            case 1:
                UI.currentWeapon = UI.Weapons.Spear;
                break;
            case 2:
                UI.currentWeapon = UI.Weapons.Axe;
                break;
            case 3:
                UI.currentWeapon = UI.Weapons.Bow;
                break;
        }
        UI.SwitchWeapon();
    }

    public int GetAttackIndex()
    {
        return currentAttackIndex;
    }
}
