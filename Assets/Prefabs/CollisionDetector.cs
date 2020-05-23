using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
	private GameObject spawnManager;

	private Animator animatior;

	private void Awake()
	{
		spawnManager = GameObject.Find("TileSpawnManager");
		animatior = GetComponent<Animator>();
		animatior.SetFloat("Animation Speed", 1f);
		animatior.Play("FadeIn");
	}

	private void OnCollisionEnter(Collision player)
	{
		if (player.gameObject.name == "Player")
		{
			spawnManager.GetComponent<TileSpawnManager>().SpawnTile();
		}
	}

	private void OnCollisionExit(Collision player)
	{
		if (player.gameObject.name == "Player")
		{
			animatior.Play("FadeOut");
			Destroy(transform.parent.gameObject, animatior.GetCurrentAnimatorStateInfo(0).length);
		}
	}
}

