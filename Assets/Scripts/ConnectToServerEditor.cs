using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(ConnectServer))]
public class ConnectToServerEditor : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        EditorGUILayout.HelpBox("This script is used to connect to the server", MessageType.Info);

        ConnectServer connectServer = (ConnectServer)target;
        if (GUILayout.Button("Connect Anonymously"))
        {
            Debug.Log("Connecting to server...");
            connectServer.ConnectToServer();
        }
    }
}
