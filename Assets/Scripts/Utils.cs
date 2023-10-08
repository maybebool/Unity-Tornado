using UnityEngine.Events;
using Button = UnityEngine.UI.Button;

public static class Utils {
    public static void UIBindParamsAction(Button button, params UnityAction[] unityActions) {
        foreach (var action in unityActions) {
            button.onClick.AddListener(action);
        }
    }
    
    public static Button.ButtonClickedEvent UIBindAction(Button button, UnityAction unityAction) {
        var evt = new Button.ButtonClickedEvent();
        evt.AddListener(unityAction);
        button.onClick = evt;
        return evt;
    }
}
