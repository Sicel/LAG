using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueList dialogueList;
    public Dialogue dialogue;

    public void OnEnable()
    {
        dialogueList.CurrentIndex = dialogue.id;
    }

    private void OnTriggerEnter(Collider other)
    {
        this.enabled = true;
    }
}
