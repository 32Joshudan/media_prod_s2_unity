using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class DIalogueManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        [SerializeField] private gameObject dialogueParent;
        [SerializeField] private TMP_Text dialogueText;
        [SerializeField] private Button option1Button;
        [SerializeField] private Button option2Button;

        [SerializeField] private float typingSpeed = 0.05f;
        [SerializeField] private float turnSpeed = 2f;

       private List<dialogueString> dialogueList;

    /* HANDLES CAMERA
   [Header("Player")]
   [SerializeField] private Polyart.FirstController_Dreamscape firstPersonController; //change camera
   private Transform playerCamera;

   private int currentDialogueIndex = 0;

   private void Start(){
    dialogueParent.SetActive(false);
    playerCamera = Camera.main.transform;
   }

   public void DialogueStart(List<dialogueString> textToPrint, Transform NPC){
    dialogueParent.SetActive(true);
    firstPersonController.enabled = false;

    Cursor.lockstate = CursorLockMode.None;
    Curspr.visible = true;

    StartCoroutine(TurnCameraTowardsNPC());
   } */

}

    private void DisableButtons()
    {
        option1Button.interactable = false;
        option2Button.interactable = false;

        option1Button.GetComponentInChildren<TMP_Text>().text = "No Option";
        option2Button.GetComponentInChildren<TMP_Text>().text = "No Option";
    }

    private IEnumerator TurnCameraTowardsNPC(Transform NPC){
        Quaternian startRotation = playerCamera.rotation;
        Quaternian targetRotation = Quaternian.LookRotation(NPC.position - playerCamera.position);


    }
    
}

// https://youtu.be/BEaOHWkZhtE?t=1039
