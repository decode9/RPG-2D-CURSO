using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public float initialVelocity;
    public Vector2 initialDirection;
    public int damage;
    private Rigidbody2D myRigid;
    public string objectiveTag;
    public GameObject shock;
    private TextHitGeneration textHitGeneration;

    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        myRigid.velocity = initialDirection.normalized * initialVelocity;
        Destroy(gameObject, 5f);
        textHitGeneration = GetComponent<TextHitGeneration>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag(objectiveTag)){ 
            Attack attack = collision.gameObject.GetComponent<Attack>();
            attack.ReceiveAttack(damage, initialDirection);
            if (shock && attack.myHealth.healthProperty != 0) Instantiate(shock, collision.gameObject.transform);
            if (textHitGeneration && attack.myHealth.healthProperty != 0) textHitGeneration.CreateTextHit(textHitGeneration.localTextHit, damage, collision.gameObject.transform, 0.25f, Color.white, 2);
            Destroy(gameObject);
        }
    }
}
