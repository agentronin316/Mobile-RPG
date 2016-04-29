using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonLoad : MonoBehaviour
{
    
    public void _LoadScene()
    {
        NavigationManager.NavigateTo(Destination.newestInstance.loadDestination);
    }

}
