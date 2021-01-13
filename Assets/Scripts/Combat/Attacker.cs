using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{

    public float desfase = 1f;
    public Vector2 hitBox = new Vector2(1,1);
    private Vector2 attackVector;
    private Vector2 puntoA, puntoB;

    public void Attack(Vector2 attackDirection, int damage){

        Debug.Log("Te meti el webo");

        attackVector = attackDirection.normalized * desfase;
        puntoA = ((Vector2)transform.position + attackVector) - hitBox * 0.5f;
        puntoB = puntoA + hitBox;

        
        Debug.DrawLine(transform.position, (Vector2)transform.position + attackVector, Color.blue);
        Debug.DrawLine(puntoA, puntoB, Color.yellow);

    }
    void Start()
    {
        
    }
}
