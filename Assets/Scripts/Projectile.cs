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
    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        myRigid.velocity = initialDirection.normalized * initialVelocity;
    }
}
