using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public float initialVelocity;
    public Vector2 initialDirection;
    public int damage;
    private Rigidbody2D myRigid;
    public string objectiveTag;
    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        myRigid.velocity = initialDirection.normalized * initialVelocity;
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag(objectiveTag)){ 
            collision.gameObject.GetComponent<Attack>().ReceiveAttack(damage, initialDirection);
            Destroy(gameObject);
        }
    }
}
