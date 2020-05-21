using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// Create folders by going to top menu bar and selecting NewFolders and then Folder Creater
public class FolderCreator : EditorWindow
{
    string folderName = "FolderName";
    string createFoldersButton = "CreateFolders";
    string createProjFolderButton = "ProjectFolder";

    public static List<string> folders = new List<string>() { "__Scripts", "_Scenes", "Animations", "Art", "Audio", "Materials/Textures", "Prefabs" };

    [MenuItem("NewFolders/Folder Creator")]

    //Editor Window to create folders
    static void Init()
    {
        FolderCreator window =
            (FolderCreator)EditorWindow.GetWindow(typeof(FolderCreator));
    }

    void OnGUI()
    {
        //Name of Project Folder
        folderName = EditorGUILayout.TextField("Folder Name:", folderName);

        //Create Project folder for the other folders to be child of
        if (GUILayout.Button(createProjFolderButton))
        {
            string guid = AssetDatabase.CreateFolder("Assets", folderName);
            string newFolderPath = AssetDatabase.GUIDToAssetPath(guid);
            foreach (string folder in folders)
            {
                string guid2 = AssetDatabase.CreateFolder(folderName, folder);
                string newFolderPath2 = AssetDatabase.GUIDToAssetPath(guid);
            }
        }

        if (GUILayout.Button(createFoldersButton))
        {
            CreateFolder();
        }
    }

    //Create folders from list of folders
    static void CreateFolder()
    {
        foreach (string folder in folders)
        {
            string guid = AssetDatabase.CreateFolder("Assets", folder);
            string newFolderPath = AssetDatabase.GUIDToAssetPath(guid);
        }
    }
}
