using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class Interactive : MonoBehaviour, IPointerDownHandler
{
    protected BoxCollider2D myCollider;
    public UnityEvent onInteraction;
    protected PlayerController player;

    private void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
        player = GameManager.instance.player.GetComponent<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        onInteraction?.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Interaction();
    }

    protected  void Interaction()
    {

        foreach (RaycastHit2D interactive in player.Interaction())
        {
            if(interactive.collider.gameObject == gameObject) Interact();
        }
    }

    public virtual void Interact(){
        Debug.Log("Tu mama fue mia");
    }
}
