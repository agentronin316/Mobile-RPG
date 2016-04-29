using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NavigationPrompt : MonoBehaviour {

    public GameObject travelContainer;
    
	
	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (NavigationManager.CanNavigate(gameObject.tag))
            {
                travelContainer.SetActive(true);
                Destination.newestInstance.loadDestination = gameObject.tag;
                travelContainer.GetComponentInChildren<Text>().text = 
                    "Do you want to travel to " + NavigationManager.GetRouteInformation(gameObject.tag) + "?";
            }
        }
	}

    void OnCollisionExit2D (Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            travelContainer.SetActive(false);
        }
    }
}
