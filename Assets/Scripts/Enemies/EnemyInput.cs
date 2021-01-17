using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInput : MonoBehaviour
{
    private Transform player;
    public float vertical { get {return playerDirection.y; } private set{}} 
    public float horizontal { get {return playerDirection.x; } private set{}}
    public float playerDistance {get {return playerDirection.magnitude; } private set{}}
    public Vector2 playerDirection { get; private set;}
    void Start()
    {
        player = GameManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        playerDirection = player.position - transform.transform.position;
    }
}
