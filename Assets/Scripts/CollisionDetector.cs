using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CollisionDetector : MonoBehaviour
{
	private ITileSpawnManager spawnManager;

	private Animator anim;

	private void Awake()
	{
		anim = GetComponent<Animator>();
		anim.Play("FadeIn");
	}

    [Inject]
    void Init(ITileSpawnManager spawnManager)
    {
		this.spawnManager = spawnManager;
    }

	private void OnCollisionEnter(Collision player)
	{		
		spawnManager.SpawnTile();	
	}

	private void OnCollisionExit(Collision player)
	{
		anim.Play("FadeOut");
		Destroy(transform.parent.gameObject, anim.GetCurrentAnimatorStateInfo(0).length);	
	}
}

