using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue normalDialogue;
    public Dialogue questFinishedDialogue;
    public DialogueManager dialogueManager;

    public void TriggerDialogue()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (!SwampLevelManager.fungiQuestCompleted)
            {
                dialogueManager.StartDialogue(normalDialogue);
            }
            else
            {
                if (SwampLevelManager.canRepeatDialogue)
                {
                    dialogueManager.StartDialogue(normalDialogue);
                }
                else
                {
                    dialogueManager.StartDialogue(questFinishedDialogue);
                }
            }
        } else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (!CaveLevelManager.minerQuestCompleted)
            {
                dialogueManager.StartDialogue(normalDialogue);
            }
            else
            {
                if (CaveLevelManager.canRepeatDialogue)
                {
                    dialogueManager.StartDialogue(normalDialogue);
                }
                else
                {
                    dialogueManager.StartDialogue(questFinishedDialogue);
                }
            }
        } else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (!HeavenLevelManager.valkyQuestCompleted)
            {
                dialogueManager.StartDialogue(normalDialogue);
            }
            else
            {
                if (HeavenLevelManager.canRepeatDialogue)
                {
                    dialogueManager.StartDialogue(normalDialogue);
                }
                else
                {
                    dialogueManager.StartDialogue(questFinishedDialogue);
                }
            }
        }
    }
}