using UnityEngine.Events;
using Button = UnityEngine.UI.Button;

public static class Utils 
{
    public static void UIBindParamsAction(Button button, params UnityAction[] unityActions) {
        foreach (var action in unityActions) {
            button.onClick.AddListener(action);
        }
    }
    
}
