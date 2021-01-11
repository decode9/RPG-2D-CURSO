using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputController InputPlayer;
    private Transform transformada;
    public float velocidad;
    private float[] movimiento = new float[2];
    private Rigidbody2D myRigid;
    private Animator animator;
    private SpriteRenderer mySprite; 
    int runHash;
    int xHash;
    int yHash;
    // Start is called before the first frame update
    void Start()
    {
        InputPlayer = GetComponent<InputController>();
        transformada = GetComponent<Transform>();
        myRigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        mySprite = GetComponent<SpriteRenderer>();
        runHash = Animator.StringToHash("correr");
        xHash = Animator.StringToHash("x");
        yHash = Animator.StringToHash("y");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movePlayer();
    }

    void Animation(float[] movimiento){
        bool run = (movimiento[1] != 0 || movimiento[0] != 0);

        animator.SetBool(runHash, run);
        mySprite.flipX = (movimiento[0] < 0 && Mathf.Abs(movimiento[1]) < Mathf.Abs(movimiento[0]));

        if (run){
            animator.SetFloat(xHash, movimiento[0]);
            animator.SetFloat(yHash, movimiento[1]);
        };
    }

    void movePlayer()
    {
        movimiento = InputPlayer.vector;
        
        Animation(movimiento);

        // ---- Movimiento de Cuerpo Rigido ---- //
        Vector2 velocityVector = new Vector2(movimiento[0], movimiento[1]) * velocidad;
        //myRigid.AddForce(velocityVector);
        myRigid.velocity = velocityVector;

    }
}

