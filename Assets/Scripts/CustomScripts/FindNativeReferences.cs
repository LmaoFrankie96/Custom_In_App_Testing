using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class FindNativeReferences : ScriptableWizard
{
    public enum ReferenceType
    {
        mesh,
        sprite,
        material
    }


    public Dictionary<ReferenceType, List<string>> reference_type_names = new Dictionary<ReferenceType, List<string>>() {

        { ReferenceType.mesh, new List<string>() { "cube", "capsule", "cylinder", "plane", "sphere", "quad" } } ,
        { ReferenceType.sprite, new List<string>() { "uisprite", "background", "inputfieldbackground","knob","uimask" } },
        { ReferenceType.material, new List<string>() { "default-material", "default-diffuse", "default-line", "default-particle", "default-particlesystem", "default-skybox", "default-terrain-diffuse","sprites-default","sprites-mask" } }
    };

    public ReferenceType SelectedReferenceType;



    public GameObject[] SceneObjects;


    string GetComponentType()
    {
        string returnval = "";
        switch (SelectedReferenceType)
        {
            case ReferenceType.mesh:
                returnval = "MeshFilter";
                break;
            case ReferenceType.sprite:
                returnval = "Image";
                break;
            case ReferenceType.material:
                returnval = "MeshRenderer";
                break;
            default:
                returnval = "none";
                break;
        }
        return returnval;
    }
    [MenuItem("Custom Tools/Find Native References %Q")]
    static void CreateWindow()
    {
        ScriptableWizard.DisplayWizard("Place existing object references in SceneObjects array",
            typeof(FindNativeReferences), "Finish", "Find References");
    }
    private void OnWizardCreate()
    {
        Debug.Log("Onwizardcreate called");
    }

    public GameObject SceneObjectToCopy;



    public GameObject[] SceneObjectsToCopy;

    string ObjectName = "";

    List<GameObject> foundComponentList = new List<GameObject>();
    void OnWizardOtherButton()
    {

       // ObjectName = SceneObjectToCopy.name.Split('_')[0];


//        foreach (GameObject go in SceneObjects)
//        {

//            if (go.name.ToLower() == ObjectName.ToLower()) {
//GameObject _child_obj=                Instantiate(SceneObjectToCopy, go.transform);

//                _child_obj.name = SceneObjectToCopy.name;
//            }
//        }

        for (int i = 0; i < SceneObjectsToCopy.Length; i++)
        {
            ObjectName = SceneObjectsToCopy[i].name.Split('_')[0];

            GameObject _currentSceneObjectToCopy = SceneObjectsToCopy[i];

            foreach (GameObject go in SceneObjects)
            {

                if (go.name.ToLower() == ObjectName.ToLower())
                {
                    GameObject _child_obj = Instantiate(_currentSceneObjectToCopy, go.transform);

                    _child_obj.name = _currentSceneObjectToCopy.name;
                }
            }
        }

    }
}