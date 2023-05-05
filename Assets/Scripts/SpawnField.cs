using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnField : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int width = 10;
    [SerializeField] private int length = 10;
    [SerializeField] private int height = 10;
    [SerializeField] private float threshold = 0.2f;
    [SerializeField] private Vector3 center;
    private List<GameObject> _prefabList = new();

    private void Start() {
        _prefabList = new List<GameObject>();
    }

    private void DoVoxelGrid()
    {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                for (int z = 0; z < length; z++) {
                    
                    var pos =  center + new Vector3( x, y, z ) * threshold;
                    var gridPrefab =  Instantiate(prefab, pos, Quaternion.identity);
                    _prefabList.Add(gridPrefab);
                }
            }
        }
    }

    private void OnMouseDown() {
        DoVoxelGrid();
    }


    public void DeleteAll()
    {
        foreach (var prefabs in _prefabList) {
            Destroy(prefabs);
        }
    }
}