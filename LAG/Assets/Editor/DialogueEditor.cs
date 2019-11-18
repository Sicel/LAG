using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Dialogue))]
public class DialogueEditor : Editor
{
    SerializedProperty numDialogue;
    SerializedProperty names;
    SerializedProperty dialogues;
    SerializedProperty audioClip;

    SerializedProperty usePrevName;

    private void OnEnable()
    {
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
        EditorGUILayout.PropertyField(numDialogue);
        names.arraySize = numDialogue.intValue;
        dialogues.arraySize = numDialogue.intValue;
        usePrevName.arraySize = numDialogue.intValue;

        EditorGUI.indentLevel++;
        for (int i = 0; i < numDialogue.intValue; i++)
        {
            bool showingDialogue = names.GetArrayElementAtIndex(i).isExpanded;

            EditorGUILayout.BeginHorizontal();
            showingDialogue = EditorGUILayout.Foldout(showingDialogue, new GUIContent("Speaker"));

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(names.GetArrayElementAtIndex(i), GUIContent.none);
            if (i != 0)
            {
                EditorGUILayout.PropertyField(usePrevName.GetArrayElementAtIndex(i), GUIContent.none);
                if (usePrevName.GetArrayElementAtIndex(i).boolValue)
                {
                    names.GetArrayElementAtIndex(i).stringValue = names.GetArrayElementAtIndex(i - 1).stringValue;
                }
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.EndHorizontal();

            if (showingDialogue)
            {
                EditorGUILayout.PropertyField(dialogues.GetArrayElementAtIndex(i), new GUIContent("Dialogue"));
                EditorGUILayout.PropertyField(audioClip, new GUIContent("Audio"));
                EditorGUILayout.Space();
            }

            names.GetArrayElementAtIndex(i).isExpanded = showingDialogue;

        }
        EditorGUI.indentLevel--;

        serializedObject.ApplyModifiedProperties();
    }
}
