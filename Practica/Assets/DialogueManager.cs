using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public Text nameText;
    public Text dialogueText;
    public GameObject dialogueBox;
    public Inventory playerInventory;
    private int counter;

    public KarmaData karma;

    private void Awake()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        counter = sentences.Count;
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        if (SceneManager.GetActiveScene().buildIndex == 0) {

            if (!SwampLevelManager.fungiQuestCompleted) {
                if (counter > 1) {
                    string sentence = sentences.Dequeue();
                    counter--;
                    StopAllCoroutines();
                    StartCoroutine(TypeSentence(sentence));
                } else
                {
                    counter--;
                    EndDialogue();
                    return;
                }
            } else
            {
                string sentence = sentences.Dequeue();
                counter--;
                StopAllCoroutines();
                StartCoroutine(TypeSentence(sentence));

                if (counter == 0)
                {
                    if (SwampLevelManager.canRepeatDialogue)
                    {
                        playerInventory.IncreaseGold(50);
                        karma.PlayerGoodKarma += 0.2f;
                    }
                    SwampLevelManager.canRepeatDialogue = false;
                }
            }
        } else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (!CaveLevelManager.minerQuestCompleted) {
                if (counter > 1) {
                    string sentence = sentences.Dequeue();
                    counter--;
                    StopAllCoroutines();
                    StartCoroutine(TypeSentence(sentence));
                } else
                {
                    counter--;
                    EndDialogue();
                    return;
                }
            } else
            {
                string sentence = sentences.Dequeue();
                counter--;
                StopAllCoroutines();
                StartCoroutine(TypeSentence(sentence));

                if (counter == 0)
                {
                    if (CaveLevelManager.canRepeatDialogue)
                    {
                        playerInventory = FindObjectOfType<Inventory>();
                        playerInventory.AddConsumiblePotions(3);
                        karma.PlayerGoodKarma += 0.2f;
                    }
                    CaveLevelManager.canRepeatDialogue = false;
                }
            }
        } else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (!HeavenLevelManager.valkyQuestCompleted) {
                if (counter > 1) {
                    string sentence = sentences.Dequeue();
                    counter--;
                    StopAllCoroutines();
                    StartCoroutine(TypeSentence(sentence));
                } else
                {
                    counter--;
                    EndDialogue();
                    return;
                }
            } else
            {
                string sentence = sentences.Dequeue();
                counter--;
                StopAllCoroutines();
                StartCoroutine(TypeSentence(sentence));

                if (counter == 0)
                {
                    if (HeavenLevelManager.canRepeatDialogue)
                    {
                        playerInventory.SetRevive();
                    }
                    HeavenLevelManager.canRepeatDialogue = false;
                }
            }
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        dialogueBox.SetActive(false);
    }
}
