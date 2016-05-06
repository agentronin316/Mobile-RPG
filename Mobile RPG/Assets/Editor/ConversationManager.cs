using UnityEngine;
using UnityEditor;

public class ConversationManager : Editor
{
    //define menu option
    [MenuItem("Assets/Create/ConversationManager ")]
    public static void CreateAsset()
    {
        Conversation conversationManager = ScriptableObject.CreateInstance<Conversation>();

        //Create a .asset file for new object and save it
        AssetDatabase.CreateAsset(conversationManager, "Assets/new ConversationManager.asset");
        AssetDatabase.SaveAssets();

        //Switch inspector to new object
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = conversationManager;

    }
}