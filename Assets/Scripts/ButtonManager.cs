using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    private AsyncOperation async;

    [SerializeField]
    private Image healthBarStatus = null;

    [SerializeField]
    private GameObject healthBarRoot = null;

    public void LoadLevel1()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        healthBarRoot.SetActive(true);
        async = SceneManager.LoadSceneAsync("Level1");
        while (!async.isDone) {
            healthBarStatus.fillAmount = async.progress;
            yield return null;
        }
    }
}
