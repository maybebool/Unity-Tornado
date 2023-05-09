using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;


public class SpawnField : Singleton<SpawnField>
{
    private List<AsyncOperationHandle<IList<GameObject>>> _assetPrefab;
    [SerializeField] private int width = 10;
    [SerializeField] private int length = 10;
    [SerializeField] private int height = 10;
    [SerializeField] private float threshold = 0.2f;
    [SerializeField] private Vector3 center;
    [SerializeField] private AudioSource sound;
    private List<AssetReferenceGameObject> PrefabList { get; set; }

    public List<AssetLabelReference> assetLabelReferences = new();

    private AsyncOperationHandle<IList<GameObject>> _loadHandle;
    private GameObject Prefab { get; set; }
    //private Dictionary<AssetReferenceGameObject, List<GameObject>> PrefabDictionary { get; set; }

    private void Start()
    {
        _assetPrefab = new List<AsyncOperationHandle<IList<GameObject>>>();
    }

    // TODO releasing multiple Objects is still a problem
    private void DoVoxelGrid() {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                for (int z = 0; z < length; z++) {
                    var pos =  center + new Vector3( x, y, z ) * threshold;

                    _loadHandle = Addressables.LoadAssetsAsync<GameObject>(assetLabelReferences, addressable => {
                        Instantiate(addressable, pos, Quaternion.identity);
                        _assetPrefab.Add(_loadHandle);
                    }, Addressables.MergeMode.Union, true);
                }
            }
        }
    }
                    //assetPrefab.InstantiateAsync(pos,Quaternion.identity).Completed += (asyncOperation) => Prefab = asyncOperation.Result;
                    // var gridPrefab =  Instantiate(prefab, pos, Quaternion.identity);
                    //PrefabList.Add(Prefab);

    private void OnMouseDown() {
        DoVoxelGrid();
        sound.Play();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.A)) {
            Debug.Log("A was pressed");
            DeleteAll();
        }
    }

    public void DeleteAll() {
        // foreach (var p in PrefabList) {
        //     Debug.Log("List is " +PrefabList + "long");
        //     p.ReleaseInstance(Prefab);
        //
        // }
        //assetPrefab.ReleaseInstance(Prefab);
        foreach (var p in _assetPrefab) {
            Addressables.Release(p);
        }
        //Addressables.ReleaseInstance(_loadHandle);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
}