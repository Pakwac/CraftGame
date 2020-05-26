using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Diamond : MonoBehaviour
{
    public GameObject paricleBurst;
    private GameBehavior gameBehavior;

    public void Start()
    {
        gameBehavior = FindObjectOfType<GameBehavior>();
    }
    void Init(GameBehavior gameBehavior)
    {
        this.gameBehavior = gameBehavior;
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