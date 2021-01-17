
using UnityEngine;

public class Wizard : EnemyIA
{
    
    public Projectile fireBole;
    // Start is called before the first frame update
    void Start()
    {
        enemyInput = GetComponent<EnemyInput>();
        animator = GetComponent<Animator>();
        mySprite = GetComponent<SpriteRenderer>();
        attacker = GetComponent<Attacker>();
        ability = GetComponent<Ability>();
        runHash = Animator.StringToHash("run");
        xHash = Animator.StringToHash("x");
        yHash = Animator.StringToHash("y");
        attackHash = Animator.StringToHash("attack");
        dieHash = Animator.StringToHash("die");
    }

    // Update is called once per frame
    void Update()
    {   
        Animation();
        Behaviour();
    }

    protected override void AttackEnemy()
    {
        ability.ShotProjectile(fireBole, fireBole.initialVelocity, enemyInput.playerDirection, attributes.ataque);
    }



    protected override void MoveToPlayer(){
        mySprite.flipX = (enemyInput.playerDirection.x > 0);
        transform.position += (Vector3) enemyInput.playerDirection * attributes.velocity * Time.deltaTime;
        animator.SetBool(runHash, true);
    }
}
