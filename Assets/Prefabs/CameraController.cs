using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public GameObject player;

	private Vector3 offset;

	private bool isAlive;

	private void Start()
	{
		offset = transform.position - player.transform.position;
	}

	private void LateUpdate()
	{
		if (player != null)
		{
			isAlive = player.GetComponent<PlayerController>().isAlive;
			if (isAlive)
			{
				transform.position = player.transform.position + offset;
			}
		}
	}
}
