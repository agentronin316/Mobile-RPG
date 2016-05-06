using UnityEngine;
using System.Collections;

public class MessagingClientBroadcast : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D other)
    {
        MessagingManager.Instance.Broadcast();
	}
}
