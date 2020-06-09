using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Diamond : MonoBehaviour
{
    public GameObject paricleBurst;
    private GameBehavior gameBehavior;

    public void Start()
    {
        gameBehavior = FindObjectOfType<GameBehavior>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            gameBehavior.score++;
            GameObject obj = Instantiate(paricleBurst, gameObject.transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            Destroy(obj, 2f);
        }
    }
}