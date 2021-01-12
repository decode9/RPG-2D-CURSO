using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Interactive : MonoBehaviour
{
    private Collider2D myCollider;
    public UnityEvent onInteraction;

    private void Start() {
        myCollider = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        onInteraction?.Invoke();
    }
}
