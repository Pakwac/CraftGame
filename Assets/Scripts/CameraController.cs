using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public PlayerController player;

	private Vector3 offset;
	private Vector3 point;
	Vector3 playerPos;
	Vector3 newPlayerPos;

	//private Camera camera;

	private bool isAlive;
	Vector2 posX;

	private void Start()
	{
		posX = transform.position;
		offset = transform.position - player.transform.position;
		point = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);


	}

	private void LateUpdate()
	{
		





		if (player != null)
		{
			isAlive = player.isAlive;
			if (isAlive)
			{

				playerPos.x = Camera.main.WorldToViewportPoint(player.transform.position).x;
				playerPos.y = Camera.main.WorldToViewportPoint(player.transform.position).y;
				playerPos.z = Camera.main.WorldToViewportPoint(player.transform.position).z;

				newPlayerPos.x = Camera.main.ViewportToWorldPoint(playerPos).x + offset.x;
				newPlayerPos.y = Camera.main.ViewportToWorldPoint(playerPos).y + offset.y;
				newPlayerPos.z = Camera.main.ViewportToWorldPoint(playerPos).z + offset.z;

				newPlayerPos.x = Mathf.Lerp(transform.position.x, newPlayerPos.x, Time.deltaTime);

				if (Mathf.Abs(transform.position.x - playerPos.x ) > 2)
				{
					//newPlayerPos.x = Mathf.Lerp(transform.position.x, playerPos.x, Time.deltaTime);
				}
				//else newPlayerPos.x = transform.position.x;

				
				transform.position = newPlayerPos;

				Debug.Log(playerPos.x);
				//Debug.Log(Camera.main.WorldToViewportPoint(transform.position).x + "  qwerqwer");
			}
			
			

		}
	}
}




//if ((transform.position.x - player.transform.position.x) > 10)
//{
//	posX = player.transform.position.x + offset.x;
//	var newTransform = new Vector3(posX, player.transform.position.y + offset.y, player.transform.position.z + offset.z);
//	transform.position = (Vector3.Lerp(transform.position, newTransform, Time.deltaTime));
//}
//else
//{
//	posX = transform.position.x;


//	transform.position = (new Vector3(transform.position.x , player.transform.position.y
//		+ offset.y, player.transform.position.z + offset.z));


//}