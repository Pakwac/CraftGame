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
    public Tile currentTile;
    public DiContainer container;
    
    private void Start()
    {
        StartCoroutine("SpawnCoroutine");
    }

    [Inject]
    void Init(DiContainer container)
    {
        this.container = container;
    }

    private IEnumerator SpawnCoroutine()
    {
        for (int i = 0; i < 10; i++)
        {
            SpawnTile();
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void SpawnTile()
    {
        currentTile = container.InstantiatePrefab(tile, SelectPosition(currentTile), Quaternion.identity, null).GetComponent<Tile>();
        var isDiamondActive = Random.Range(0, 5) == 0;
        if (currentTile.Diamond != null)currentTile.Diamond.SetActive(isDiamondActive);
    }

   
    public Vector3 SelectPosition(Tile currentTile)
    {
        var point = (SpawnPoint)Random.Range(0, 2);
        switch (point)
        {
            case SpawnPoint.leftPos:
                return currentTile.LeftPos.position;
                
            case SpawnPoint.straightPos:
                return currentTile.StraightPos.position;
        }
        
        return currentTile.LeftPos.position;
    }
}
