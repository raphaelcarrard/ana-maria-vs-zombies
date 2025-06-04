using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class WhereAmI : MonoBehaviour
{

    public static WhereAmI instance;
    public string levelName;
    public int levelNumber = -1;
    
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
        SceneManager.sceneLoaded += VerifyLevel;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            #if UNITY_EDITOR
            if (WhereAmI.instance.levelName == "Level1" || WhereAmI.instance.levelName == "Level2")
            {
                Time.timeScale = 1f;
                Timer.instance.StopTimer();
                Timer.instance.currentTime = 0;
                SceneManager.LoadScene("MainMenu");
            }
            if (WhereAmI.instance.levelName == "MainMenu")
            {
                EditorApplication.isPlaying = false;
            }
            #elif UNITY_WEBGL
            if(WhereAmI.instance.levelName == "Level1" || WhereAmI.instance.levelName == "Level2")
            {
                Time.timeScale = 1f;
                Timer.instance.StopTimer();
                Timer.instance.currentTime = 0;
                SceneManager.LoadScene("MainMenu");
            }
            #else
            if (WhereAmI.instance.levelName == "Level1" || WhereAmI.instance.levelName == "Level2")
            {
                Time.timeScale = 1f;
                Timer.instance.StopTimer();
                Timer.instance.currentTime = 0;
                SceneManager.LoadScene("MainMenu");
            }
            if (WhereAmI.instance.levelName == "MainMenu")
            {
                Application.Quit();
            }
            #endif
        }
    }

    
    void VerifyLevel(Scene cena, LoadSceneMode mode)
    {
        levelNumber = SceneManager.GetActiveScene().buildIndex;
        levelName = SceneManager.GetActiveScene().name;
    }
}
