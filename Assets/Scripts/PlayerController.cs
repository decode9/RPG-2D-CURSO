using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Projectile projectile;
    private InputController InputPlayer;
    public AbilityScriptable ability1;
    private Transform transformada;
    private float[] movimiento = new float[2];
    private Rigidbody2D myRigid;
    private Animator animator;
    private SpriteRenderer mySprite;
    private PolygonCollider2D myCollider;
    public Attributes playerAttributes;
    private Health health;
    private Ability ability;
    private ExperienceLevel experienceLevel;
    int runHash;
    int xHash;
    int yHash;
    int attackHash;
    private Attacker attacker;
    public LayerMask layerInteraction;

    private TrailRenderer trailRenderer;
    private float dashColdown=0;
    private bool usingDash;
    private Foot foot;
    // Start is called before the first frame update

    void Start()
    {
        foot = GetComponentInChildren<Foot>();
        InputPlayer = GetComponent<InputController>();
        transformada = GetComponent<Transform>();
        myRigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        mySprite = GetComponent<SpriteRenderer>();
        attacker = GetComponent<Attacker>();
        health = GetComponent<Health>();
        myCollider = GetComponent<PolygonCollider2D>();
        experienceLevel = GetComponent<ExperienceLevel>();
        trailRenderer = GetComponent<TrailRenderer>();
        ability = GetComponent<Ability>();
        runHash = Animator.StringToHash("correr");
        xHash = Animator.StringToHash("x");
        yHash = Animator.StringToHash("y");
        attackHash = Animator.StringToHash("attack");
        AttributePanel.instance.UpdateTextAttributes(playerAttributes, health, experienceLevel);
    }

    private void Update()
    {
        Attack();
        CheckInventory();
        UpdateDashColdDown();
    }

    public void Walk(){
        foot.playSound();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movePlayer();
        UseAbility();
    }

    private void Attack()
    {
        bool attack = InputPlayer.atacar;

        if (attack)
        {
            animator.SetBool(attackHash, attack);
            animator.SetFloat(xHash, InputPlayer.lookDirection.x);
            animator.SetFloat(yHash, InputPlayer.lookDirection.y);
        };
    }

    private void CheckInventory()
    {
        if (InputPlayer.inventario) MenuPanel.instance.OpenClosePanels();
    }

    private void UpdateDashColdDown(){
        if(usingDash){
            dashColdown += Time.deltaTime;
            if(dashColdown>trailRenderer.time){
                SwitchTrailRenderer();
                dashColdown = 0;
                usingDash = false;
            }
        }
    }

    private void SwitchTrailRenderer(){
        trailRenderer.enabled = (!trailRenderer.enabled);
    }

    void Animation(float[] movimiento)
    {
        bool run = (movimiento[1] != 0 || movimiento[0] != 0);

        animator.SetBool(runHash, run);
        if (run)
        {
            animator.SetFloat(xHash, movimiento[0]);
            animator.SetFloat(yHash, movimiento[1]);
        };
    }

    private void UseAbility(){
        if(InputPlayer.habilidad1) {
            usingDash = ability.Dash(InputPlayer.lookDirection, myRigid);
            SwitchTrailRenderer();
        }
        if(InputPlayer.habilidad2) ability.ShotProjectile(projectile, 5f, InputPlayer.lookDirection, playerAttributes.magic, "Enemy");
    }

    void movePlayer()
    {
        movimiento = InputPlayer.vector;

        Animation(movimiento);
        // ---- Movimiento de Cuerpo Rigido ---- //
        Vector2 velocityVector = new Vector2(movimiento[0], movimiento[1]) * playerAttributes.velocity;
        if (animator.GetBool(attackHash)) velocityVector = Vector2.zero;

        //myRigid.AddForce(velocityVector);
        myRigid.velocity = velocityVector;

    }

    void AttackController()
    {
        attacker.Attack(InputPlayer.lookDirection, playerAttributes.ataque);
        animator.SetBool(attackHash, false);
    }

    public RaycastHit2D[] Interaction()
    {
        RaycastHit2D[] circleCast = Physics2D.CircleCastAll(transform.position, myCollider.pathCount, InputPlayer.lookDirection.normalized, 2f, layerInteraction);
        if (circleCast != null) return circleCast;
        return null;
    }
}

