using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour
{
    private GameController gameController;

    void Start()
    {
        gameController = GameController.GetGameControllerInScene();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameController.EnableExitPortal();
            Destroy(gameObject);
        }
    }
}
