using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameEventListener))]
public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private GameEvent gameEvent = null;
    [SerializeField] bool triggerOnce = false;
    [SerializeField] bool canTrigger = false;
    [SerializeField] DialogueTrigger nextTrigger;

    public void OnEnable()
    {
        gameObject.GetComponent<GameEventListener>().enabled = true;
        gameEvent.Raise();
        gameObject.GetComponent<GameEventListener>().enabled = false;
        enabled = false;

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
