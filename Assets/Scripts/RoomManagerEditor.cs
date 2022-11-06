using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(RoomManager))]
public class RoomManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        EditorGUILayout.HelpBox("This script is used to create and join rooms", MessageType.Info);

        RoomManager roomManager = (RoomManager)target;
        if (GUILayout.Button("Create Room"))
        {
            roomManager.JoinRandomRoom();
        }
    }
}

