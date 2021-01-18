﻿using System.Collections;
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

  public void ShotProjectile(Projectile projectile, float initialVelocity, Vector2 direction, int damage, string tagObjective)
  {
    Projectile myProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
    myProjectile.gameObject.transform.SetParent(transform);
    myProjectile.initialVelocity = initialVelocity;
    myProjectile.initialDirection = direction;
    myProjectile.damage = damage;
    myProjectile.objectiveTag = tagObjective;
  }
}
