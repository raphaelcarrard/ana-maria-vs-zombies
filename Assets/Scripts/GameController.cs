using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    private int coinScore;
    private int points;
    public Text PointsText;
    public Text CoinScoreText;
    public Text LevelMessageText;
    public string LevelNameToLoad;
    public Image LevelTimer;
    public int LevelLengthInSeconds = 30;
    public PortalController PortalControllerFromCrypt;

    public void PlayerDied()
    {
        ShowLevelMessage("You Died! Restarting...");
        StartCoroutine(ReloadLevel());
    }

    IEnumerator ReloadLevel()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    void Start()
    {
        StartCoroutine(CoLevelTimer());
        Timer.instance.StartTimer();
    }

    private IEnumerator CoLevelTimer()
    {
        float decrementAmount = 1f / LevelLengthInSeconds;
        decrementAmount = decrementAmount / 10;
        while (LevelTimer.fillAmount > 0)
        {
            LevelTimer.fillAmount -= decrementAmount;
            if (LevelTimer.fillAmount < .15f)
            {
                LevelTimer.color = Color.red;
            }
            yield return new WaitForSeconds(.1f);
        }
        ShowLevelMessage("Time's Up! Restarting...");
        StartCoroutine(ReloadLevel());
    }

    public void EnableExitPortal()
    {
        PortalControllerFromCrypt.ActivatePortal();
    }

    internal static GameController GetGameControllerInScene()
    {
        var gc = GameObject.FindGameObjectWithTag("GameController");
        if (gc == null)
        {
            return null;
        }
        return gc.GetComponent<GameController>();
    }

    internal void LoadNextLevel()
    {
        SceneManager.LoadScene(LevelNameToLoad);
    }

    public void incrementCoinScore(int amount)
    {
        coinScore += amount;
        CoinScoreText.text = coinScore.ToString();
    }

    public void incrementPoints(int amount)
    {
        points += amount;
        PointsText.text = points.ToString() + " PTS";
    }

    public void ShowLevelMessage(string message)
    {
        LevelMessageText.text = message;
        LevelMessageText.transform.gameObject.SetActive(true);
        var color = LevelMessageText.color;
        color.a = 1;
        LevelMessageText.color = color;
        LevelMessageText.CrossFadeAlpha(0, 5f, false);
    }
}
