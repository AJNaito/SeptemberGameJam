using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameController gameController;
    private void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Make player drop items (game controller)
            gameController.setFoodCount(gameController.getFoodCount() - 1);
            Debug.Log(gameController.getFoodCount());
        }
    }
}
