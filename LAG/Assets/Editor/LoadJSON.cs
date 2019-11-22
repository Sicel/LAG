using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LoadJSON : Editor
{
    // TODO: Finish implementation
    [MenuItem("Load All JSON Files", menuItem = "Load Dialogue/All From JSON")]
    public static void LoadAllJSONFiles()
    {
        var jsonFiles = Resources.LoadAll("JSON/");
        DialogueInfo dialogueInfo = new DialogueInfo();
        for (int i = 0; i < jsonFiles.Length; i++)
        {
            JsonUtility.FromJsonOverwrite(jsonFiles[i].ToString(), dialogueInfo);
            Debug.Log(dialogueInfo);
            CreateDialogueAsset(dialogueInfo, jsonFiles[i].name);
        }
    }

    static void CreateDialogueAsset(DialogueInfo dialogueInfo, string name)
    {
        Dialogue newDialogue = CreateInstance<Dialogue>();
        newDialogue.speakers = new List<string>();
        newDialogue.sentences = new List<string>();
        newDialogue.numDialogue = dialogueInfo.lines.Count;
        for (int i = 0; i < dialogueInfo.lines.Count; i++)
        {
            newDialogue.speakers.Add(dialogueInfo.lines[i].speaker);
            newDialogue.sentences.Add(dialogueInfo.lines[i].dialogue);
        }

        Dialogue dialogue = AssetDatabase.LoadAssetAtPath<Dialogue>("Assets/Dialogue/" + name + ".asset");
        if (dialogue)
            dialogue = newDialogue;
        else
            AssetDatabase.CreateAsset(newDialogue, "Assets/Dialogue/" + name + ".asset");
    }
}
