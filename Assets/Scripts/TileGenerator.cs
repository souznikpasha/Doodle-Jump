using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private List<GameObject> activeTiles = new List<GameObject>();
    private float spawnPos = 0;
    private float tileLength = 3;
    public float levelWidth = 4.35f+4.57f;
    public float minY = .2f;
    public float maxY = 1.5f;
    //Границы экрана -4.35 4.57

    [SerializeField] private Transform player;
    private int startTiles = 6;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < startTiles; i++)
        {
            SpawnTile(Random.Range(0,tilePrefabs.Length));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.y - 8> spawnPos - (startTiles * tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }

        if (player.position.x > 4.35)
        {
            Debug.Log("я возле границы справа");
        }
        if (player.position.x < -4.35)
        {
            Debug.Log("я возле границы слева");
        }
        //Debug.Log(player.position.y);
        //Debug.Log(spawnPos);
    }

    private void SpawnTile(int tileIndex)
    {
        GameObject nextTile = Instantiate(tilePrefabs[tileIndex], transform.up * spawnPos, transform.rotation);
        activeTiles.Add(nextTile);
        spawnPos += tileLength;
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}