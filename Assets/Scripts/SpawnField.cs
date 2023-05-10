using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


public class SpawnField : Singleton<SpawnField>
{
    private List<GameObject> AssetPrefabs { get; set; }
    private List<GameObject> PrefabList { get; set; }
    [SerializeField] private AssetReferenceGameObject assetPrefab;
    [SerializeField] private int width = 10;
    [SerializeField] private int length = 10;
    [SerializeField] private int height = 10;
    [SerializeField] private float threshold = 0.2f;
    [SerializeField] private Vector3 center;
    [SerializeField] private AudioSource sound;

    public List<AssetLabelReference> assetLabelReferences = new();

    private AsyncOperationHandle<IList<GameObject>> _loadHandle;

    private GameObject Prefab { get; set; }
    //private Dictionary<AssetReferenceGameObject, List<GameObject>> PrefabDictionary { get; set; }

    [SerializeField] private string label;
    private List<GameObject> Assets { get; } = new();

    private void Awake()
    {
        AssetPrefabs = new List<GameObject>();
    }

    // TODO releasing multiple Objects is still a problem
    private void DoVoxelGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                for (int z = 0; z < length; z++)
                {
                    var pos = center + new Vector3(x, y, z) * threshold;
                    //Addressables.LoadAsset<AssetReferenceGameObject>(assetLabelReferences);
                    assetPrefab.LoadAssetAsync().Completed +=
                        (asyncOperation) => Prefab = asyncOperation.Result;
                    AssetPrefabs.Add(Prefab);

                    // _loadHandle = Addressables.LoadAssetsAsync<GameObject>(assetLabelReferences, addressable => {
                    //     Instantiate(addressable, pos, Quaternion.identity);
                    //     _assetPrefab.Add(addressable);
                    // }, Addressables.MergeMode.Union, true);
                }
            }
        }
    }
    // var gridPrefab =  Instantiate(prefab, pos, Quaternion.identity);
    //PrefabList.Add(Prefab);

    private void OnMouseDown()
    {
        DoVoxelGrid();
        sound.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A was pressed");
            DeleteAll();
        }
    }


    public void DeleteAll()
    {
        // foreach (var p in PrefabList) {
        //     Debug.Log("List is " +PrefabList + "long");
        //     p.ReleaseInstance(Prefab);
        //
        // }
        //assetPrefab.ReleaseInstance(Prefab);
        // foreach (var p in _assetPrefab) {
        //     Addressables.Release(p);
        // }
        foreach (GameObject t in AssetPrefabs)
        {
            // Destroy(t);
            // assetPrefab.ReleaseInstance();
            //Addressables.ReleaseAsset(t);
        }

        assetPrefab.ReleaseAsset();
        
        //Addressables.ReleaseInstance(_loadHandle);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}