using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public int score;

	public Text scoreText;

	[SerializeField]
	private float speed = 5f;

	private Vector3 moveVector;

	public bool isAlive;

	private void Start()
	{
		isAlive = true;
		moveVector = Vector3.zero;
	}

	private void Update()
	{
		Ray ray = new Ray(transform.position, Vector3.down);
		if (!Physics.Raycast(ray, 1f))
		{
			isAlive = false;
		}
		else
		{
			isAlive = true;
		}
		if (isAlive)
		{
			if (Input.GetMouseButtonDown(0))
			{
				if (moveVector == Vector3.forward)
				{
					moveVector = Vector3.left;
				}
				else
				{
					moveVector = Vector3.forward;
				}
			}
		}
		else
		{
			Destroy(gameObject, 2f);
		}
		scoreText.text = score.ToString();
	}

	private void FixedUpdate()
	{
		transform.Translate(moveVector * speed * Time.fixedDeltaTime);
	}
}

