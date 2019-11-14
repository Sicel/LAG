using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void OnEnable()
    {
        Debug.Log("Hi");
    }

    private void OnTriggerEnter(Collider other)
    {
        this.enabled = true;
    }
}
