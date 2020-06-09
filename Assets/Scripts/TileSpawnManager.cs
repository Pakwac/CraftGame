using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public enum SpawnPoint
{
    leftPos,
    straightPos
} 

public class TileSpawnManager : MonoBehaviour, ITileSpawnManager
{
    public GameObject tile;
    public GameObject currentTile;
    public DiContainer container;

    public List<GameObject> tiles = new List<GameObject>();
    
    private void Start()
    {
        StartCoroutine("CreatePool");
        StartCoroutine("SpawnCoroutine");
       
    }

    private IEnumerator CreatePool()
    {
        for (int i = 0; i < 20; i++)
        {
            var go = Instantiate(tile, transform.position, Quaternion.identity);
            go.SetActive(false);
            tiles.Add(go);
        }
        yield return null;
    }
    private IEnumerator SpawnCoroutine()
    {
        for (int i = 0; i < 10; i++)
        {
            SpawnTile();
            yield return new WaitForSeconds(0.5f);
        }
    }

    //public void CreateTile()
    //{

       
    //    tile.SetActive(false);
    //    currentTile = tile;
    //    tiles.Add(tile);
      

    //    
    //    
    //}

    public GameObject GetPoolTile()
    {
        for (int i = 0; i < tiles.Count; i++)
        {
            if (!tiles[i].activeSelf)
            {
                return tiles[i];
            }
        }
        
        return null;
    }

    public void SpawnTile()
    {
        var go = GetPoolTile();
        go.transform.position = SelectPosition(currentTile);
        go.SetActive(true);
        currentTile = go;

        var isDiamondActive = Random.Range(0, 5) == 0;
        if (go.GetComponent<Tile>().Diamond != null) currentTile.GetComponent<Tile>().Diamond.SetActive(isDiamondActive);
    }

    


   
    public Vector3 SelectPosition(GameObject currentTile)
    {
        var point = (SpawnPoint)Random.Range(0, 2);
        switch (point)
        {
            case SpawnPoint.leftPos:
                return currentTile.GetComponent<Tile>().LeftPos.position;
                
            case SpawnPoint.straightPos:
                return currentTile.GetComponent<Tile>().StraightPos.position;
        }
        
        return currentTile.GetComponent<Tile>().LeftPos.position;
    }
}
