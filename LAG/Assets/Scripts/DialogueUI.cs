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
    private int index = -1;
    private float timer = 0.0f;
    private bool timerStarted;
    //public static DialogueManager self;

    private void Start()
    {
        speakers = new List<string>();
        textToDisplay = new List<string>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (timerStarted)
        {
            timer += Time.deltaTime;

            if (timer >= timeBeforeNextSentence)
                DisplayNextSentence();
        }

        if (Input.GetKeyDown(KeyCode.Space))
            DisplayNextSentence();
    }


    public void StartDialogue(Dialogue dialogue)
    {
        speakers.Clear();
        textToDisplay.Clear();
        index = 0;
        speaker.gameObject.SetActive(true);
        this.dialogue.gameObject.SetActive(true);
        audioSource.clip = dialogue.audio;

        for (int i = 0; i < dialogue.numDialogue; i++)
        {
            speakers.Add(dialogue.speakers[i]);
            textToDisplay.Add(dialogue.sentences[i]);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        timer = 0;
        timerStarted = false;
        if (index == textToDisplay.Count)   
        {
            EndDialogue();
            return;
        }

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
        index++;
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogue.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogue.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
        timerStarted = true;
    }

    private void EndDialogue()
    {
        speaker.gameObject.SetActive(false);
        dialogue.gameObject.SetActive(false);
    }
}
