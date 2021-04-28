using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class TileManger : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private Transform playerTransform;
    private float spawnX = 0.0f;
    private float tilelength = 19.0f;
    private int anmtileonscreen = 7;
    private float safeZone = 15.0f;
    private int lastprefabindex = 0;

    private List<GameObject> activeTiles;
    // Start is called before the first frame update
    void Start()
    {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for(int i = 0; i < anmtileonscreen; i++)
        {
            if (i < 2)
                SpawnTile(0);
            else
            SpawnTile();
        }
    }

    // Update is called once per frame
    void Update() {
        if(playerTransform.position.x - safeZone > (spawnX - anmtileonscreen * tilelength))
        {
            SpawnTile();
            DeleteTile();
        }
        
    }
    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
            go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        else
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.right * spawnX;
        spawnX += tilelength;
        activeTiles.Add(go);
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
    private int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
            return 0;

        int randomIndex = lastprefabindex;
        while(randomIndex == lastprefabindex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }
        lastprefabindex = randomIndex;
        return randomIndex;

    }
}
