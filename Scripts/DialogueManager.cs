using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    private Queue<string> sentences;

    public Dialogue dialogue;
    //public Button continueButton;
    //public GameObject skipImage;
    //public GameObject continueImage;


    void Awake()
    {
        sentences = new Queue<string>();
        StartDialogue(dialogue);
    }
    public void StartDialogue(Dialogue dialogue)
    {

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void Update()
    {
        if(sentences.Count == 0)
        {
            //continueButton.interactable = false;
        }
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            return;
        }

        
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence (string sentence)
    {
        yield return new WaitForSeconds(0.25f);
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }

    public void SkipDialogue()
    {

    }
}
