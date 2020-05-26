using UnityEngine;

public interface ITileSpawnManager
{
    void SpawnTile();
    Vector3 SelectPosition(Tile currentTile);
}