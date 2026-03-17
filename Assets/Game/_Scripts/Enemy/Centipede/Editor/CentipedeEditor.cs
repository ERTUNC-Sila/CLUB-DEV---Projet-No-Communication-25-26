using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Centipede))]
public class CentipedeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Centipede centipede  = target as Centipede;
        
        base.OnInspectorGUI();
        
        EditorGUILayout.Space();

        if (GUILayout.Button("Create Centipede"))
        {
            centipede.CreateCentipede();
        }
    }
}