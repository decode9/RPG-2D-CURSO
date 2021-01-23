
using UnityEngine;

public class Knight : EnemyIA
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        enemyInput = GetComponent<EnemyInput>();
        animator = GetComponent<Animator>();
        mySprite = GetComponent<SpriteRenderer>();
        attacker = GetComponent<Attacker>();
        runHash = Animator.StringToHash("run");
        xHash = Animator.StringToHash("x");
        yHash = Animator.StringToHash("y");
        attackHash = Animator.StringToHash("attack");
        dieHash = Animator.StringToHash("die");
        Instantiate(puff, transform);
    }

    // Update is called once per frame
    void Update()
    {   
        Animation();
        Behaviour();
    }
}
