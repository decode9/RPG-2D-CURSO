using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attributes))]
public class PlayerController : MonoBehaviour
{
    private InputController InputPlayer;
    private Transform transformada;
    private float[] movimiento = new float[2];
    private Rigidbody2D myRigid;
    private Animator animator;
    private SpriteRenderer mySprite; 

    private Attributes playerAttributes;
    int runHash;
    int xHash;
    int yHash;
    private Attacker attacker;
    // Start is called before the first frame update
    void Start()
    {
        InputPlayer = GetComponent<InputController>();
        transformada = GetComponent<Transform>();
        myRigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        mySprite = GetComponent<SpriteRenderer>();
        playerAttributes = GetComponent<Attributes>();
        attacker = GetComponent<Attacker>();
        runHash = Animator.StringToHash("correr");
        xHash = Animator.StringToHash("x");
        yHash = Animator.StringToHash("y");
    }

    private void Update() {
        Attack();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movePlayer();
    }

    private void Attack(){
        bool attack = InputPlayer.atacar;
        movimiento = InputPlayer.vector;

        if(attack) attacker.Attack(InputPlayer.lookDirection, playerAttributes.ataque);
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
        Vector2 velocityVector = new Vector2(movimiento[0], movimiento[1]) * playerAttributes.velocity;
        //myRigid.AddForce(velocityVector);
        myRigid.velocity = velocityVector;

    }
}

