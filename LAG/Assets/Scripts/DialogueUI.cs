using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI speaker = null;
    [SerializeField] private TextMeshProUGUI dialogue = null;
    [SerializeField] private bool typeSentence = true;
    [SerializeField, Range(0, 0.2f)] private float typeSpeed = 0.02f;
    [SerializeField] private float timeBeforeNextSentence = 0.5f;

    private AudioSource audioSource;
    private List<string> speakers;
    private List<string> textToDisplay;
    private int index = 0;
    private float timer = 0.0f;
    private bool timerStarted;
    private bool dialogueStarted = false;
    //public static DialogueManager self;

    private void Start()
    {
        speakers = new List<string>();
        textToDisplay = new List<string>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!dialogueStarted)
            return;

        if (dialogue.text == textToDisplay[index])
            timerStarted = true;

        if (timerStarted)
        {
            timer += Time.deltaTime;

            if (timer >= timeBeforeNextSentence)
                DisplayNextSentence();
        }
    }


    public void StartDialogue(Dialogue dialogue)
    {
        speakers.Clear();
        textToDisplay.Clear();
        index = -1;
        speaker.gameObject.SetActive(true);
        this.dialogue.gameObject.SetActive(true);
        audioSource.clip = dialogue.audio;
        dialogueStarted = true;

        for (int i = 0; i < dialogue.numDialogue; i++)
        {
            speakers.Add(dialogue.speakers[i]);
            textToDisplay.Add(dialogue.sentences[i]);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (index < textToDisplay.Count - 1)
        {
            index++;
        }
        else
        {
            EndDialogue();
            return;
        }

        timer = 0;
        timerStarted = false;
        dialogue.text = "";

        if (audioSource.clip)
            audioSource.Play();

        if (speakers[index] == "")
            speaker.gameObject.SetActive(false);
        else
        {
            if (!speaker.gameObject.activeInHierarchy)
                speaker.gameObject.SetActive(true);

            speaker.text = speakers[index];
        }

        string sentence = textToDisplay[index];

        if (sentence == "")
            sentence = "...";

        StopAllCoroutines();

        if (typeSentence)
        {
            StartCoroutine(TypeSentence(sentence));
        }
        else
        {
            dialogue.text = sentence;
            timerStarted = true;
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        foreach (char letter in sentence.ToCharArray())
        {
            dialogue.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    private void EndDialogue()
    {
        speaker.gameObject.SetActive(false);
        dialogue.gameObject.SetActive(false);
        dialogueStarted = false;
    }
}
