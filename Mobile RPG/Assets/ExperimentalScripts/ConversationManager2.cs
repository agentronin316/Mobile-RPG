using System;
using System.Collections;
using UnityEngine;

public class ConversationManager2 : MonoBehaviour
{
    //static singelton property
    public static ConversationManager2 Instance { get; set; }

    bool talking = false;
    ConversationEntry currentConversationLine;
    int fontSpacing = 7;
    int conversationTextWidth;
    int dialogHeight = 70;

    void Awake()
    {
        //check if any other instances are conflicting
        if (Instance != null && Instance != this)
            Destroy(gameObject);

        //Save current instances
        Instance = this;
    }

    public void StartConversation(Conversation conversation)
    {
        if (!talking)
            StartCoroutine(DisplayConversation(conversation));
    }

    IEnumerator DisplayConversation(Conversation conversation)
    {
        talking = true;
        foreach (ConversationEntry conversationLine in conversation.conversationLines)
        {
            currentConversationLine = conversationLine;
            conversationTextWidth = currentConversationLine.conversationText.Length * fontSpacing;
            Debug.Log(currentConversationLine.speakingCharacterName + " " + currentConversationLine.conversationText + " " + currentConversationLine.displayPicture);

            yield return new WaitForSeconds(3);
        }

        talking = false;
    }
}
