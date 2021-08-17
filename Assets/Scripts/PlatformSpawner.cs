using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject platform, firstPlatform;
    [SerializeField] private float space;
    private float currentSpace;
    void Start()
    {
        currentSpace = space;
    }
    public void SpawnPlatform()
    {
        Vector3 pos = new Vector3(3.9f, firstPlatform.transform.position.y + currentSpace, 0f);
        Instantiate(platform, pos, Quaternion.identity);
        currentSpace += space;
    }
}
