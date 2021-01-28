using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Attribute
{
    velocity,
    ataque,
    health,
    magic
}
[CreateAssetMenu(menuName = "ScriptableObjects/Attributes")]
public class Attributes : ScriptableObject
{

    [Tooltip("Movement Velocity")]
    [SerializeField]
    private int velocityBase;

    [Tooltip("Attack Power")]
    [SerializeField]
    private int attackBase;
    [Tooltip("Magic Points")]
    [SerializeField]
    private int magicBase;
    private int velocityModificator;
    private int attackModificator;
    private int magicModificator;

    public int velocity { get { return velocityBase + velocityModificator; } }
    public int ataque { get { return attackBase + attackModificator; } }


    public int magic { get { return magicBase + magicModificator; } }

    public void AugmentBaseVelocity(int amount)
    {
        velocityBase += amount;
    }

    public void AugmentBaseAttack(int amount)
    {
        attackBase += amount;
    }

    public void AugmentBaseMagic(int amount)
    {
        magicBase += amount;
    }

    public void ModifyAttribute(Attribute attribute, int amount)
    {
        switch (attribute)
        {
            case Attribute.velocity:
                velocityModificator += amount;
                break;
            case Attribute.ataque:
                attackModificator += amount;
                break;
            case Attribute.health:
                break;
            case Attribute.magic:
                magicModificator += amount;
                break;
        }
    }

    public void ModifyHealth(Health health, int amount)
    {
        health.healthModificator += amount;
    }

    public void UpdateEquipment(List<Equipment> equipments){
        GameObject player = GameManager.instance.player;
        Health health = player.GetComponent<Health>();
        ExperienceLevel experience = player.GetComponent<ExperienceLevel>();
        ResetModificator();
        foreach (Equipment equipment in equipments)
        {
            velocityModificator += equipment.velocity;
            attackModificator += equipment.attack;
            health.healthModificator += equipment.health;
        }
        health.UpdateHealthBar();
        AttributePanel.instance.UpdateTextAttributes(this, health, experience);
    }

    public void ResetModificator(){
        velocityModificator = 0;
        attackModificator = 0;
        GameManager.instance.player.GetComponent<Health>().healthModificator = 0;
    }
}
