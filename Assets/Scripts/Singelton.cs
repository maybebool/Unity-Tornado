using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component {
    private static T _instance;
        
    public Singleton() {
        _instance = this as T;
    }

    public static T Instance {
        get {
            if (_instance == null) {
                var objs = FindObjectsOfType<T>();

                if (objs.Length > 0) {
                    T instance = objs[0];
                    _instance = instance;
                }
                else {
                    var go = new GameObject();
                    go.name = typeof(T).Name;
                    _instance = go.AddComponent<T>();
                    DontDestroyOnLoad(go);
                }
            }

            return _instance;
        }
    }

    public static void Instantiate() {
        _instance = Instance;
    }
}