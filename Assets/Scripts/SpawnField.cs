using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;


public class SpawnField : Singleton<SpawnField>
{
    [SerializeField] private AssetReferenceGameObject assetPrefab;
    [SerializeField] private int width = 10;
    [SerializeField] private int length = 10;
    [SerializeField] private int height = 10;
    [SerializeField] private float threshold = 0.2f;
    [SerializeField] private Vector3 center;
    [SerializeField] private AudioSource sound;
    private List<AssetReferenceGameObject> PrefabList { get; set; }
    
    //private Dictionary<AssetReferenceGameObject, List<GameObject>> PrefabDictionary { get; set; }
    private GameObject Prefab { get; set; }

    private void Start() {
        PrefabList = new List<AssetReferenceGameObject>();
    }

    private void DoVoxelGrid() {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                for (int z = 0; z < length; z++) {
                    var pos =  center + new Vector3( x, y, z ) * threshold;
                    assetPrefab.InstantiateAsync(pos,Quaternion.identity).Completed += (asyncOperation) => Prefab = asyncOperation.Result;
                    // var gridPrefab =  Instantiate(prefab, pos, Quaternion.identity);
                    //PrefabList.Add(Prefab);
                    
                }
            }
        }
    }

    private void OnMouseDown() {
        DoVoxelGrid();
        sound.Play();
    }

    public void DeleteAll() {
        // foreach (var p in PrefabList) {
        //     Debug.Log("List is " +PrefabList + "long");
        //     p.ReleaseInstance(Prefab);
        //
        // }
        assetPrefab.ReleaseInstance(Prefab);
    }
}