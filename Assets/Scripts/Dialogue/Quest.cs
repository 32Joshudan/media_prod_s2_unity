using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quest : MonoBehaviour
{

    public Image questItem; //Image questItem;
    public Color completedColor;
    public Color activeColor;

    //public QuestArrow;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FinishQuest();
            Debug.Log("Quest Completed");
        }
    }

    void FinishQuest()
    {
        //questItem.Color = completedColor;
        Debug.Log("Quest Completed");
    }
}
