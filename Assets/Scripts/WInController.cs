using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WInController : MonoBehaviour
{

    public Text text;
    public bool scorePosted;
    public bool score50Medal;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Timer.instance.currentTime = 0;
            SceneManager.LoadScene("MainMenu");
        }
        Timer.instance.StopTimer();
        TimeSpan time = TimeSpan.FromSeconds(Timer.instance.currentTime);
        text.text = "you beat the game in " + time.Minutes.ToString() + ":" + time.Seconds.ToString() + "s";
        if (!scorePosted)
        {
            NGHelper.instance.submitScore(14983, (int)Timer.instance.currentTime);
            scorePosted = true;
        }
        if (Timer.instance.currentTime < 50 && !score50Medal)
        {
            NGHelper.instance.unlockMedal(84896);
            score50Medal = true;
        }
    }
}
