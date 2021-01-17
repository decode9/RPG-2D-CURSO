using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Health))]
public class EnemyIA : Enemy
{

    protected int runHash;
    protected int attackHash;
    protected SpriteRenderer mySprite;
    protected bool dead = false;
    protected bool attack = false;
    protected bool combat = false;
    protected Vector2 attackDirection;
    [SerializeField] protected float detectionDistance;
    [SerializeField] protected float attackDistance;
    protected Attacker attacker;
    protected Ability ability;

    protected void Behaviour(){
        if(!dead) AliveBehaviour();
    }

    protected void AliveBehaviour(){
        animator.SetBool(runHash, false);
        int attackProbability = Random.Range(0, 95);
        if(!attack && enemyInput.playerDistance < attackDistance) if(attackProbability > 90) AttackBehaviour();
        if(!attack && (!combat && enemyInput.playerDistance < detectionDistance)) MoveToPlayer();
        if(enemyInput.playerDistance > attackDistance) combat = false;
    }

    protected void AttackBehaviour(){
        combat = true;
        attack = true;
        attackDirection = enemyInput.playerDirection;
        animator.SetTrigger(attackHash);
        animator.SetBool(runHash, false);
    }

    protected virtual void AttackEnemy(){
        attacker.Attack(attackDirection, attributes.ataque);
    }

    protected virtual void MoveToPlayer(){
        mySprite.flipX = (enemyInput.playerDirection.x < 0);
        transform.position += (Vector3) enemyInput.playerDirection * attributes.velocity * Time.deltaTime;
        animator.SetBool(runHash, true);
        
    }

    protected void SetAttackFalse(){
        attack = false;
    }
}
