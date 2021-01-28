using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName= "ScriptableObjects/Items/Potions")]
public class Potion : Item
{
    public int cure;

    public override bool useItem()
    {
        Health healthplayer = GameManager.instance.player.GetComponent<Health>();
        
        if(healthplayer.myHealth <= healthplayer.healthProperty) return false;

        healthplayer.modifyHealth(cure);
        return true;

    }
}
