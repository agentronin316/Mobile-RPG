using UnityEngine;
using System.Collections;

public class MessagingClientReceiver : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        MessagingManager.Instance.Subscribe(ThePlayerIsTryingToLeave);
	}
	
    void ThePlayerIsTryingToLeave()
    {
        Debug.Log("Oi! Don't leave me!! - " + tag.ToString());

        ConversationComponent dialog = GetComponent<ConversationComponent>();
        if (dialog != null)
        {
            if (dialog.Conversations != null && dialog.Conversations.Length > 0)
            {
                Conversation conversation = dialog.Conversations[0];
                if(conversation != null)
                {
                    ConversationManager2.Instance.StartConversation(conversation);
                }
            }
        }
    }
}
