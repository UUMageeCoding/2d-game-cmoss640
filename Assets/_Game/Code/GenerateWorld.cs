using UnityEngine;

public class GenerateWorld : MonoBehaviour
{
    [SerializeField] GameObject MapChunk;
    private Vector2 ChunkSpawnLocation = new Vector2(55, 0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(MapChunk, ChunkSpawnLocation, Quaternion.Euler(0f, 0f, 0f));
            ChunkSpawnLocation += new Vector2(12, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
