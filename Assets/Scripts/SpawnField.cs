using System.Collections.Generic;
using UnityEngine;


public class SpawnField : Singleton<SpawnField>
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int width = 10;
    [SerializeField] private int length = 10;
    [SerializeField] private int height = 10;
    [SerializeField] private float threshold = 0.2f;
    [SerializeField] private Vector3 center;
    [SerializeField] private AudioSource sound;
    [HideInInspector] public List<GameObject> prefabList = new();

    private void Start() {
        prefabList = new List<GameObject>();
    }

    private void DoVoxelGrid()
    {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                for (int z = 0; z < length; z++) {
                    
                    var pos =  center + new Vector3( x, y, z ) * threshold;
                    var gridPrefab =  Instantiate(prefab, pos, Quaternion.identity);
                    prefabList.Add(gridPrefab);
                }
            }
        }
    }

    private void OnMouseDown() {
        DoVoxelGrid();
        sound.Play();
    }

    public void DeleteAll() {
        foreach (var p in prefabList) {
            Destroy(p);
        }
    }
}