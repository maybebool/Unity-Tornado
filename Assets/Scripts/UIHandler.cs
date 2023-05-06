using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class UIHandler : MonoBehaviour
    {
        private SpawnField spawn;
        [SerializeField] private Button deleteButton;
        [SerializeField] private AudioSource sound;


        private void OnEnable()
        {
            Utils.UIBindParamsAction(deleteButton,DeleteAll, PlaySound);
        }


        private void OnDisable()
        {
            deleteButton.onClick.RemoveAllListeners();
        }


        private void DeleteAll() {
            foreach (var prefabs in spawn.prefabList) {
                Destroy(prefabs);
            }
        }

        private void PlaySound() {
            sound.Play();
        }

    }
}