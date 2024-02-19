using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.Reflection;
using UnityEngine.Events;
//using Unity.Framework;
using System.Collections.Generic;

public class ButtonListenerCheckerWizard : ScriptableWizard
{
    public string methodNameFilter = "YourMethodNameFilter";

    public List<GameObject> listOfButtons;

    [MenuItem("Tools/Button Listener Checker Wizard")]
    private static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard<ButtonListenerCheckerWizard>("Button Listener Checker", "Finish", "Find Methods");
    }


    private void OnWizardOtherButton()
    {
        listOfButtons.Clear();
        CheckAllButtonsForListeners(methodNameFilter);
    }
    private void OnWizardCreate()
    {

    }

    // Method to get and log listeners of a specific button with a method name filter
    private void GetButtonListeners(Button button, string methodNameFilter)
    {
        UnityEventBase eventBase = button.onClick;
        int eventCount = GetUnityEventPersistentEventCount(eventBase);

        for (int i = 0; i < eventCount; i++)
        {
            UnityEngine.Object targetObject = GetUnityEventPersistentTarget(eventBase, i);
            string methodName = GetUnityEventPersistentMethodName(eventBase, i);

            // Check if the method name matches the filter
            if (methodName.Contains(methodNameFilter))
            {
                Debug.Log("Button: " + button.name + " | Listener " + i + ": " + targetObject + " | " + methodName, button);

                if (!listOfButtons.Contains(button.gameObject))
                    listOfButtons.Add(button.gameObject);
            }
        }
    }

    // Method to check all buttons for listeners with a specific method name filter
    private void CheckAllButtonsForListeners(string methodNameFilter)
    {
        listOfButtons.Clear();

        Button[] allButtons = Resources.FindObjectsOfTypeAll(typeof(Button)) as Button[];
        foreach (Button button in allButtons)
        {
            GetButtonListeners(button, methodNameFilter);
        }
    }

    // Reflection methods to access UnityEvent internals during runtime
    private int GetUnityEventPersistentEventCount(UnityEventBase unityEventBase)
    {
        MethodInfo method = unityEventBase.GetType().GetMethod("GetPersistentEventCount", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        return (int)method.Invoke(unityEventBase, null);
    }

    private UnityEngine.Object GetUnityEventPersistentTarget(UnityEventBase unityEventBase, int index)
    {
        MethodInfo method = unityEventBase.GetType().GetMethod("GetPersistentTarget", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        return (UnityEngine.Object)method.Invoke(unityEventBase, new object[] { index });
    }

    private string GetUnityEventPersistentMethodName(UnityEventBase unityEventBase, int index)
    {
        MethodInfo method = unityEventBase.GetType().GetMethod("GetPersistentMethodName", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        return (string)method.Invoke(unityEventBase, new object[] { index });
    }
}
