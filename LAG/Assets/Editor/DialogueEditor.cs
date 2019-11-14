using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Dialogue))]
public class DialogueEditor : Editor
{
    SerializedProperty id;
    SerializedProperty numDialogue;
    SerializedProperty names;
    SerializedProperty dialogues;
    SerializedProperty audioClip;

    SerializedProperty usePrevName;

    private void OnEnable()
    {
        id = serializedObject.FindProperty("id");
        numDialogue = serializedObject.FindProperty("numDialogue");
        names = serializedObject.FindProperty("speakers");
        dialogues = serializedObject.FindProperty("sentences");
        audioClip = serializedObject.FindProperty("audio");
        usePrevName = serializedObject.FindProperty("usePrevSpeaker");

        serializedObject.Update();
    }

    // TODO: Fix Formatting
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        EditorGUILayout.LabelField("ID " + id.intValue.ToString());
        EditorGUILayout.PropertyField(numDialogue);
        names.arraySize = numDialogue.intValue;
        dialogues.arraySize = numDialogue.intValue;
        usePrevName.arraySize = numDialogue.intValue;

        EditorGUI.indentLevel++;
        for (int i = 0; i < numDialogue.intValue; i++)
        {
            EditorGUILayout.BeginHorizontal();

            //EditorGUILayout.PrefixLabel("Speaker");
            EditorGUILayout.BeginHorizontal();
            //names.GetArrayElementAtIndex(i).stringValue = EditorGUILayout.TextField(names.GetArrayElementAtIndex(i).stringValue, GUILayout.ExpandWidth(true));
            EditorGUILayout.PropertyField(names.GetArrayElementAtIndex(i), new GUIContent("Speaker"), GUILayout.ExpandWidth(true));
            if (i != 0)
            {
                //usePrevName.GetArrayElementAtIndex(i).boolValue = EditorGUILayout.ToggleLeft("Same Speaker", usePrevName.GetArrayElementAtIndex(i).boolValue);
                EditorGUILayout.PropertyField(usePrevName.GetArrayElementAtIndex(i), GUIContent.none);
                if (usePrevName.GetArrayElementAtIndex(i).boolValue)
                {
                    names.GetArrayElementAtIndex(i).stringValue = names.GetArrayElementAtIndex(i - 1).stringValue;
                }
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.PropertyField(dialogues.GetArrayElementAtIndex(i), new GUIContent("Dialogue"));

            EditorGUILayout.PropertyField(audioClip, new GUIContent("Audio"));
            EditorGUILayout.Space();
        }
        EditorGUI.indentLevel--;

        serializedObject.ApplyModifiedProperties();
    }
}
