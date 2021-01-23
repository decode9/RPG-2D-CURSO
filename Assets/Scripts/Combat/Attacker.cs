using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{

    public float desfase = 1.5f;
    public Vector2 hitBox = new Vector2(1.5f, 1.5f);
    private Vector2 attackVector;
    private Vector2 puntoA, puntoB;
    public LayerMask attackLayer;
    private Collider2D[] attackCollider = new Collider2D[12];
    private ContactFilter2D attackFilter;
    public GameObject shock;
    private TextHitGeneration textHitGeneration;

    void Start()
    {
        attackFilter.layerMask = attackLayer;
        attackFilter.useLayerMask = true;
        textHitGeneration = GetComponent<TextHitGeneration>();
    }

    public void Attack(Vector2 attackDirection, int damage)
    {

        CreateHitBox(attackDirection);
        GameObject attackedObject;
        int numColliders = Physics2D.OverlapArea(puntoA, puntoB, attackFilter, attackCollider);

        for (int i = 0; i < numColliders; i++)
        {

            attackedObject = attackCollider[i].gameObject;
            Attack attack = attackedObject.GetComponent<Attack>();
            if (attack)
            {
                Debug.Log(attack.myHealth);
                attack.ReceiveAttack(damage, attackDirection);
                if (shock && attack.myHealth.healthProperty != 0) Instantiate(shock, attackedObject.transform);
                if (textHitGeneration && attack.myHealth.healthProperty != 0) textHitGeneration.CreateTextHit(textHitGeneration.localTextHit, damage, attackedObject.transform, 0.25f, Color.white, 2);
            }

        }
    }

    private void CreateHitBox(Vector2 attackDirection)
    {
        Vector2 scale = transform.lossyScale;
        Vector2 scaleHitBox = Vector2.Scale(hitBox, scale);

        attackVector = Vector2.Scale(attackDirection.normalized * desfase, scale);
        puntoA = ((Vector2)transform.position + attackVector) - scaleHitBox * 0.5f;
        puntoB = puntoA + scaleHitBox;
        Debug.DrawLine(transform.position, (Vector2)transform.position + attackVector, Color.blue);
        Debug.DrawLine(puntoA, puntoB, Color.yellow);
    }

}
