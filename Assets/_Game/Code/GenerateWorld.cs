using UnityEngine;

public class GenerateWorld : MonoBehaviour
{
    [SerializeField] GameObject MapChunk;
    private Vector2 ChunkSpawnLocation = new Vector2(55, 0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 50; i++) // Generates 50 world tiles
        {
            Instantiate(MapChunk, ChunkSpawnLocation, Quaternion.Euler(0f, 0f, 0f));
            ChunkSpawnLocation += new Vector2(12, 0); // Modifies the spawn location each loop iteration
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
