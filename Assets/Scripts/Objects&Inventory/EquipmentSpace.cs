using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSpace : Space
{

    public Equip equipType;

    protected override void useObject()
    {
        UnequipObject();
    }

    private void UnequipObject()
    {
        Inventory inventory = Inventory.instance;
        if (inventory.inventoryFull) return;
        if (inventory.AddObject(saveItem, 1)) RemoveObject();
    }

    public override void RemoveObject()
    {
        EquipmentPanel.instance.RemoveEquip((Equipment)saveItem);
        ResetSpace();
    }
}
