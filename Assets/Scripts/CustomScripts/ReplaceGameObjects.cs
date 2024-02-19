using UnityEditor;
using UnityEngine;

public class ReplaceGameObjects : ScriptableWizard
{
    public GameObject NewType;
    public GameObject[] OldObjects;

    [MenuItem("Custom/Replace GameObjects")]


    static void CreateWizard()
    {
        DisplayWizard("Replace GameObjects", typeof(ReplaceGameObjects), "Replace");
    }

    void OnWizardCreate()
    {
        foreach (GameObject go in OldObjects)
        {
            GameObject newObject;
            newObject = (GameObject)EditorUtility.InstantiatePrefab(NewType);
            newObject.transform.position = go.transform.position;
            newObject.transform.rotation = go.transform.rotation;
            newObject.transform.parent = go.transform.parent;

            DestroyImmediate(go);
        }

    }
}