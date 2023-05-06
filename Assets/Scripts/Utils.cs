using UnityEngine.Events;
using UnityEngine.UI;

public static class Utils 
{
    public static void BindParamsAction(Button button, params UnityAction[] unityActions) {
        foreach (var action in unityActions) {
            button.onClick.AddListener(action);
        }
    }
}
