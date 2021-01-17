using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShotProjectile(Projectile projectile, float initialVelocity, Vector2 direction, int damage){
        GameObject newProjectile = Instantiate(projectile.gameObject, transform.position, Quaternion.identity);
        Projectile myProjectile = newProjectile.GetComponent<Projectile>();
        myProjectile.initialVelocity = initialVelocity;
        myProjectile.initialDirection = direction;
        myProjectile.damage = damage;
    }
}
