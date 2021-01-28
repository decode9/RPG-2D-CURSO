using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentPanel : MonoBehaviour
{
    public static EquipmentPanel instance;
    public Attributes attributes;
    public EquipmentSpace[] equipmentSpaces;
    public List<Equipment> equipments = new List<Equipment>();

    private void Awake()
    {
        if (!instance) instance = this;
        equipmentSpaces = GetComponentsInChildren<EquipmentSpace>();
    }

    public Equipment EquipObject(Equipment equipment)
    {
        foreach (EquipmentSpace equipmentSpace in equipmentSpaces)
        {
            if (equipment.equipType == equipmentSpace.equipType)
            {
                if (!equipmentSpace.saveItem)
                {
                    AddEquip(equipment, equipmentSpace);
                    return null;
                }
                Equipment equipObject = equipmentSpace.saveItem as Equipment;
                AddEquip(equipment, equipmentSpace);
                return equipObject;
            }
        }
        return null;
    }

    private void AddEquip(Equipment equipment, EquipmentSpace equipmentSpace)
    {
        equipmentSpace.AddObject(equipment, 1);
        equipments.Add(equipment);
        Debug.Log(equipments);
        attributes.UpdateEquipment(equipments);
    }

    public void RemoveEquip(Equipment equipment)
    {
        equipments.Remove(equipment);
        attributes.UpdateEquipment(equipments);
    }
}
