using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollisionDetector : MonoBehaviour
{
	public TileSpawnManager spawnManager;

	private Animator anim;

	private void Awake()
	{
		spawnManager = FindObjectOfType<TileSpawnManager>();
		anim = GetComponent<Animator>();
		
	}

	private void OnEnable()
	{
		anim.Play("FadeIn");
	}


	private void OnCollisionEnter(Collision player)
	{		
		spawnManager.SpawnTile();	
	}

	private void OnCollisionExit(Collision player)
	{
		anim.Play("FadeOut");
		//Destroy(transform.parent.gameObject, anim.GetCurrentAnimatorStateInfo(0).length);	
		StartCoroutine("Off");
	}

	private IEnumerator Off()
	{
		yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
		gameObject.GetComponentInParent<Tile>().gameObject.SetActive(false);
	}
}

