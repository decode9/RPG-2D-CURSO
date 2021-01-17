using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{

    public float desfase = 1.5f;
    public Vector2 hitBox = new Vector2(1.5f,1.5f);
    private Vector2 attackVector;
    private Vector2 puntoA, puntoB;
    public LayerMask attackLayer;
    private Collider2D[] attackCollider = new Collider2D[12];
    private ContactFilter2D attackFilter;

    void Start()
    {
        attackFilter.layerMask = attackLayer;   
    }

    public void Attack(Vector2 attackDirection, int damage){

        CreateHitBox(attackDirection);
        GameObject attackedObject;
        int numColliders = Physics2D.OverlapArea(puntoA, puntoB, attackFilter, attackCollider);

        for (int i = 0; i < numColliders; i++){
            
            attackedObject = attackCollider[i].gameObject;
            if(attackedObject != gameObject && attackedObject.GetComponent<Attack>()) attackedObject.GetComponent<Attack>().ReceiveAttack(damage, attackDirection);
        }
    }

    private void CreateHitBox(Vector2 attackDirection){
        Vector2 scale = transform.lossyScale;
        Vector2 scaleHitBox = Vector2.Scale(hitBox, scale);

        attackVector = Vector2.Scale(attackDirection.normalized * desfase, scale);
        puntoA = ((Vector2)transform.position + attackVector) - scaleHitBox * 0.5f;
        puntoB = puntoA + scaleHitBox;
        Debug.DrawLine(transform.position, (Vector2)transform.position + attackVector, Color.blue);
        Debug.DrawLine(puntoA, puntoB, Color.yellow);
    }
    
}
