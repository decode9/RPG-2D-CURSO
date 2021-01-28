using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Equip
{
    helmet,
    armor,
    weapon,
    shield
}

[CreateAssetMenu(menuName = "ScriptableObjects/Items/Equipment")]
public class Equipment : Item
{
    public Equip equipType;
    public int health;
    public int attack;
    public int velocity;

    public override bool useItem()
    {
        EquipmentPanel equipmentPanel = EquipmentPanel.instance;
        Equipment actualEquipment = equipmentPanel.EquipObject(this);
        if (actualEquipment)
        {
            equipmentPanel.RemoveEquip(actualEquipment);
            Inventory.instance.AddObject(actualEquipment, 1);
        }
        return true;
    }
}
