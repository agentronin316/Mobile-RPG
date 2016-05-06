using UnityEngine;
using System;
using System.Collections.Generic;

public class MessagingManager : MonoBehaviour {

	public static MessagingManager Instance { get; set; }

    List<Action> subscribers = new List<Action>();

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void Subscribe(Action subscriber)
    {
        subscribers.Add(subscriber);
    }

    public void Unsubscribe(Action subscriber)
    {
        subscribers.Remove(subscriber);
    }

    public void ClearAllSubscribers()
    {
        subscribers.Clear();
    }


    public void Broadcast()
    {
        Debug.Log("Broadcast requested; number of subscribers = " + subscribers.Count);
        foreach(var subscriber in subscribers)
        {
            subscriber();
        }
    }
}
