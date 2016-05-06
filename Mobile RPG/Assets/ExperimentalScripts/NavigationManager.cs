using UnityEngine.SceneManagement;
using System.Collections.Generic;


public struct Route
{
    public string routeDescription;
    public bool canTravel;
}

public static class NavigationManager{

    //List of all the places in the game
    public static Dictionary<string, Route> RouteInformation = new Dictionary<string, Route>()
    {
        {"World",  new Route { routeDescription = "the big bad world", canTravel = true } },
        {"Cave", new Route { routeDescription = "the deep dark cave", canTravel = false } },
        {"Home Town", new Route { routeDescription = "your hometown", canTravel = true } }
    };

    /// <summary>
    /// Interrogate the destination list
    /// </summary>
    /// <param name="destination">The target destination</param>
    /// <returns>Returns the text to display in the prompt</returns>
    public static string GetRouteInformation(string destination)
    {
        return RouteInformation.ContainsKey(destination) ? RouteInformation[destination].routeDescription : null;
    }

    //Will complete later
    /// <summary>
    /// Limits the player's travel based on their current destination
    /// </summary>
    /// <param name="destination">The target destination</param>
    /// <returns>Returns if the player is able to travel to a destination</returns>
    public static bool CanNavigate(string destination)
    {
        return RouteInformation.ContainsKey(destination) ? RouteInformation[destination].canTravel : false;
    }

    /// <summary>
    /// Instigates navigation. Controls the exact things that happen when the player travels.
    /// </summary>
    /// <param name="destination">The destination that the player will navigate to</param>
    public static void NavigateTo(string destination)
    {
        //Fill this in later
        SceneManager.LoadScene(destination);
    }
}
