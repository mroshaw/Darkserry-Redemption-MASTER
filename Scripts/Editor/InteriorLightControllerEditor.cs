using UnityEditor;
using UnityEngine;
using DaftAppleGames.Core.Buildings;

[CustomEditor(typeof(InteriorLightController))]
public class InteriorLightControllerEditor : Editor
{
    override public void OnInspectorGUI()
    {
        DrawDefaultInspector();
        InteriorLightController myScript = target as InteriorLightController;
        if (GUILayout.Button("All Lights On"))
        {
            myScript.TurnOnAllLights();
        }

        if (GUILayout.Button("All Lights Off"))
        {
            myScript.TurnOffAllLights();
        }

        if (GUILayout.Button("All Lights Toggle"))
        {
            myScript.ToggleAllLights();
        }

        if (GUILayout.Button("(Re)Configure"))
        {
            Configure();
        }
    }
    private void Configure()
    {
    }
}