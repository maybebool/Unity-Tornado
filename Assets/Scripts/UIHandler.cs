using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private Button deleteButton;
    [SerializeField] private AudioSource deleteSound;
    private SpawnField _spawnField;
    
    private void OnEnable() {
        Utils.UIBindParamsAction(deleteButton, DeleteSound, DeleteObjects);
    }

    private void DeleteObjects() {
        _spawnField.DeleteAll();
    }
    
    private void DeleteSound() {
        deleteSound.Play();
    }
}
