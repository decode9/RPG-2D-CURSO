using UnityEngine;

public class Attack : MonoBehaviour
{
    public Health myHealth {get; private set;}
    private Rigidbody2D myRigid;

    private void Start() {
        myHealth = GetComponent<Health>();
        myRigid = GetComponent<Rigidbody2D>();
    }

    public void ReceiveAttack(){
        myHealth.healthProperty -= 1;
    }

    public void ReceiveAttack(int damage, Vector2 attackDirection){
        myHealth.modifyHealth(-damage);
        myRigid.AddForce(attackDirection * damage * 50);
    }
}
