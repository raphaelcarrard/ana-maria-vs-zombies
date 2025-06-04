using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{
    
    private GameController gameController;

    void Start()
    {
        gameController = GameController.GetGameControllerInScene();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameController.incrementCoinScore(10);
            Destroy(gameObject);
        }
    }
}
