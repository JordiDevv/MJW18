using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class CreateDefaultFolders : EditorWindow {

    /// <summary>
    /// Creates an instance of the CreateFolders window, sets its position and size, and shows it as a popup.
    /// </summary>
    [MenuItem("Assets/Create Default Folders")]
    private static void SetUpFolders(){
        CreateDefaultFolders window = GetWindow<CreateDefaultFolders>();
        window.position = new Rect(Screen.width / 2, Screen.height / 2, 400, 150);
        window.ShowPopup();
    }

    /// <summary>
    /// Creates a set of predefined folders in the Unity project's Assets directory.
    /// </summary>
    private static void CreateAllFolders(){
        List<string> folders = new List<string>{
            "Art/Animations",
            "Art/Audio",
            "Editor",
            "Art/Materials",
            "Prefabs",
            "Scripts",
            "Scenes",
            "ScriptableObjects",
            "UI"
        };
        
        foreach(string folder in folders){
            if (!Directory.Exists("Assets/" + folder)){
                Directory.CreateDirectory("Assets/" + folder);
                // Create a file .txt in the folder
                System.IO.File.WriteAllText(path: ("Assets/" + folder + "/DeleteMe.txt"), "Delete this file to keep the folder");
            }
        }
        
        AssetDatabase.Refresh();
    }

    /// <summary>
    /// Handles the GUI events for the CreateFolders window.
    /// </summary>
    void OnGUI(){
        CreateAllFolders();
        this.Close();
    }
}