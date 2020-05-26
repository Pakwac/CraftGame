using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
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
        isAlive = UpdateIsAlive();
        if (isAlive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                moveVector = moveVector == Vector3.forward ? Vector3.left : Vector3.forward;
            }
        }
        else
        {
            Destroy(gameObject, 2f);
        }
    }

    private bool UpdateIsAlive()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        return Physics.Raycast(ray, 1f);
       
    }

    private void FixedUpdate()
	{
		transform.Translate(moveVector * speed * Time.fixedDeltaTime);
	}
}

