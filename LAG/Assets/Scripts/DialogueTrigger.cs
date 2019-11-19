using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameEventListener))]
public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private GameEvent gameEvent = null;

    public void OnEnable()
    {
        gameEvent.Raise();
    }

    private void OnTriggerEnter(Collider other)
    {
        enabled = true;
    }
}
