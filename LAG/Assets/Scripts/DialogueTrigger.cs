using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameEventListener))]
public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private GameEvent gameEvent = null;
    [SerializeField] private bool triggerOnce = false;
    [SerializeField] private bool canTrigger = false;
    [SerializeField] private DialogueTrigger nextTrigger;

    public void OnEnable()
    {
        gameObject.GetComponent<GameEventListener>().enabled = true;
        gameEvent.Raise();
        gameObject.GetComponent<GameEventListener>().enabled = false;
        enabled = false;

        canTrigger = false;
        nextTrigger.canTrigger = true;

        if (triggerOnce)
            gameObject.GetComponent<Collider>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!canTrigger)
            return;

        if (other.tag != "Player")
            return;

        enabled = true;
    }
}
