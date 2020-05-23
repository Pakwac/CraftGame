using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartManager : MonoBehaviour
{
	public GameObject restartText;

	public GameObject player;

	private void Start()
	{
		restartText.SetActive(false);
	}

	private void Update()
	{
		if (player == null)
		{
			restartText.SetActive(true);
			if (Input.GetMouseButtonDown(0))
			{
				SceneManager.LoadScene("CraftGameTest");
			}
		}
	}
}
