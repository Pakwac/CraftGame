using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
public class GameBehavior : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public DiContainer container;


    [Inject]
    void Init(DiContainer container)
    {
        this.container = container;
    }

    public void Update()
    {
        scoreText.text = score.ToString();
    }
}
