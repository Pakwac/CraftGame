using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
	private GameObject spawnManager;

	private Animator anim;

	private void Awake()
	{
		spawnManager = GameObject.Find("TileSpawnManager");
		anim = GetComponent<Animator>();
		anim.Play("FadeIn");
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
			anim.Play("FadeOut");
			Destroy(transform.parent.gameObject, anim.GetCurrentAnimatorStateInfo(0).length);
		}
	}
}

