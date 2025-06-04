using UnityEngine;
using System.Collections;

public class PortalController : MonoBehaviour
{

    private GameController gameController;
    private bool portalActivated;

    [SerializeField]
    private GameObject locked = null;

    [SerializeField]
    private GameObject closedDoor = null;

    [SerializeField]
    private GameObject openDoor = null;

    private bool displayedHelperMessage;
    
    void Start()
    {
        gameController = GameController.GetGameControllerInScene();
        locked.SetActive(true);
        closedDoor.SetActive(true);
        openDoor.SetActive(false);
    }

    public void ActivatePortal()
    {
        portalActivated = true;
        locked.SetActive(false);
        closedDoor.SetActive(false);
        openDoor.SetActive(true);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (portalActivated)
            {
                if (WhereAmI.instance.levelName == "Level1")
                {
                    NGHelper.instance.unlockMedal(84884);
                }
                if (WhereAmI.instance.levelName == "Level2")
                {
                    NGHelper.instance.unlockMedal(84895);
                }
                gameController.LoadNextLevel();
            }
            else if (!displayedHelperMessage)
            {
                displayedHelperMessage = true;
                gameController.ShowLevelMessage("Find the key to activate the portal!");
            }
        }
    }
}
