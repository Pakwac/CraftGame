using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondManager : MonoBehaviour
{
	public GameObject paricleBurst;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Player")
		{
			other.gameObject.GetComponent<PlayerController>().score++;
			GameObject obj = Instantiate(paricleBurst, gameObject.transform.position, Quaternion.identity);
			gameObject.SetActive(false);
			Destroy(obj, 2f);
		}
	}
}
