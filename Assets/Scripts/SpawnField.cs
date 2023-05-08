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
    private List<GameObject> PrefabList { get; set; }

    private void Start() {
        PrefabList = new List<GameObject>();
    }

    private void DoVoxelGrid()
    {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                for (int z = 0; z < length; z++) {
                    
                    var pos =  center + new Vector3( x, y, z ) * threshold;
                    var gridPrefab =  Instantiate(prefab, pos, Quaternion.identity);
                    PrefabList.Add(gridPrefab);
                }
            }
        }
    }

    private void OnMouseDown() {
        DoVoxelGrid();
        sound.Play();
        Debug.Log(sound + "Was played");
    }

    public void DeleteAll() {
        foreach (var p in PrefabList) {
            Destroy(p);
        }
    }
}