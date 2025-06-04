using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NGHelper : MonoBehaviour
{

    public io.newgrounds.core ngio_core;

    public static NGHelper instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void onLoggedIn()
    {
        io.newgrounds.objects.user player = ngio_core.current_user;
    }

    void onLoginFailed()
    {
        io.newgrounds.objects.error error = ngio_core.login_error;
    }

    void onLoginCancelled()
    {
        Debug.Log("Login Cancelled");
    }

    void requestLogin()
    {
        ngio_core.requestLogin(onLoggedIn, onLoginFailed, onLoginCancelled);
    }

    void Start()
    {
        ngio_core.onReady(() =>
        {
            ngio_core.checkLogin((bool logged_in) =>
            {
                if (logged_in)
                {
                    onLoggedIn();
                }
                else
                {
                    requestLogin();
                }
            });
        });
    }

    public void unlockMedal(int medal_id)
    {
        io.newgrounds.components.Medal.unlock medal_unlock = new io.newgrounds.components.Medal.unlock();
        medal_unlock.id = medal_id;
        medal_unlock.callWith(ngio_core);
        Debug.Log("Medal Unlocked!");
    }

    public void submitScore(int score_id, int score)
    {
        io.newgrounds.components.ScoreBoard.postScore submit_score = new io.newgrounds.components.ScoreBoard.postScore();
        submit_score.id = score_id;
        submit_score.value = score;
        submit_score.callWith(ngio_core);
        Debug.Log("Score Added!");
    }
}
