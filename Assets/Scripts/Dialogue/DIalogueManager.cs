using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialogueParent;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Button option1Button;
    [SerializeField] private Button option2Button;

    [SerializeField] private float typingSpeed = 0.05f;
    [SerializeField] private float turnSpeed = 2f;

    private List<dialogueString> dialogueList;

    /*[Header("Player")]
    [SerializeField] private Polyart.FirstPersonController_Dreamscape firstPerson Controller;
    private Transform playerCamera;
    
    private int currentDialogueIndex = 0
    
    private void Start()
    {
        dialogue.Parent.SetActive(false);
        playerCamera = Camera.main.transform;
    } */
    
    public void DialogueStart(List<dialogueString> textToPrint, Transform NPC)
    {
        dialogueParent.SetActive(true);
        //firstPersonController.enabled = false;

        Cursor.lockstate = CursorLockMode.None;
        Cursor.visible = true;

        //StartCoroutine(TurnCameraTowardsNPC());

        dialogueList = textToPrint;
        currentDialogueIndex = 0;

        DisableButtons();

        StartCoroutine(PrintDialogue());
    }    

    private void DisableButtons()
    {
        option1Button.interactable = false;
        option2Button.interactable = false;

        option1Button.GetComponentInChildren<TMP_Text>().text = "No Option";
        option2Button.GetComponentInChildren<TMP_Text>().text = "No Option";
    }

    /*private IEnumerator TurnCameraTowardsNPC(Transform NPC)
    {
        Quaternian startRotation = playerCamera.rotation;
        Quaternian targetRotation = Quaternian.LookRotation(NPC.position - playerCamera.position);

        float elapsedTime = 0f;
        while(elapsedTime < 1f)
        {
            playerCamera.rotation = Quaternian.Slerp(startRotation, targetRotation, elapsedTime);
            elapsedTime += Time.deltaTime * turnSpeed;
            yield return null;
        }

        playerCamera.rotagtion = targetRotation;
    }*/
    
    private IEnumerator PrintDialogue()
    {
        while (currentDialogueIndex < dialogueList.Count)
        {
            dialogueString line = dialogueList[currentDialogueIndex];

            line.startDialogueEvent?.Invoke();

            if (line.isQuestion)
            {
                yield return StartCoroutine(TypeText(line.text));

                option1Button.interactable = true;
                option2Button.interactable = true;

                option1Button.GetComponentInChildren<TMP_Text>().text = line.answerOption1;
                option2Button.GetComponentInChildren<TMP_Text>().text = line.answerOption2;

                // https://youtu.be/BEaOHWkZhtE?t=1154    S T A R T  H E R E
            }
            else
            {
                yield return StartCoroutine(TypeText(line.text));
            }

            line.endDialogueEvent?.Invoke();
        }
    }
}
