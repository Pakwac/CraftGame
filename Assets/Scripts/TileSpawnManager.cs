using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawnManager : MonoBehaviour
{
	public GameObject tile;

	public GameObject currentTile;

	private void Start()
	{
		StartCoroutine("SpawnCoroutine");
	}

	private IEnumerator SpawnCoroutine()
	{
		for (int i = 0; i < 10; i++)
		{
			SpawnTile();
			yield return new WaitForSeconds(0.5f);
		}
	}

	private void Update()
	{
	}

	public void SpawnTile()
	{
		currentTile = Instantiate(tile, currentTile.transform.GetChild(0).transform.GetChild(Random.Range(0, 2)).position, Quaternion.identity);
		if (Random.Range(0, 5) == 0)
		{
			currentTile.transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);
		}
		else
		{
			currentTile.transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);
		}
	}
}
