using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(EnemyInput))]
public class Enemy : MonoBehaviour
{
    
    public Attributes attributes;
    protected EnemyInput enemyInput;
    public string name;
    protected Animator animator;
    public int exp;
    protected int xHash;
    protected int yHash;
    protected int dieHash;

    protected void Animation(){
        
        bool run = (enemyInput.playerDirection.y != 0 ||enemyInput.playerDirection.x != 0);
        
        if (run){
            animator.SetFloat(xHash, enemyInput.playerDirection.x);
            animator.SetFloat(yHash, enemyInput.playerDirection.y);
        };
    }

    public void Die(){
        animator.SetBool(dieHash, true);
    }
    
}
