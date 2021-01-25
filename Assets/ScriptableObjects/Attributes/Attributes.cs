
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
}
