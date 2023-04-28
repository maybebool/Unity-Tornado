using UnityEngine;


public class SpawnField : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int width = 10;
    [SerializeField] private int length = 10;
    [SerializeField] private int height = 10;
    [SerializeField] private float threshold = 0.2f;

    void Start()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                for (int z = 0; z < length; z++)
                {
                    var pos = new Vector3(x, y, z) * threshold;
                    Instantiate(prefab, pos, Quaternion.identity);
                }
            }
        }
    }
}