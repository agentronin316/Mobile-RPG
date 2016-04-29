using UnityEngine;
using System.Collections;

public class Destination : MonoBehaviour {

    public static Destination newestInstance;
    public string loadDestination;


	// Use this for initialization
	void Start ()
    {
        newestInstance = this;
	}
	
}
