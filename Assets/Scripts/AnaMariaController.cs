using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class AnaMariaController : MonoBehaviour
{

    public static AnaMariaController instance;

    private Rigidbody2D rb;
    private Animator anim;
    private bool grounded;
    private bool dead;
    private GameController gameController;
    public AudioClip launchSound;
    public AudioClip coinSound;
    public AudioClip keySound;
    public AudioClip deadSound;
    public bool paused;
    public int coinsCollected;
    public int zombiesKilled;
    public bool medalZombie1Lvl1, medalZombie2Lvl1, medalZombie3Lvl1, medalZombie4Lvl1, medalZombie5Lvl1;
    public bool coinCollected1Lvl1, coinCollected2Lvl1, coinCollected3Lvl1;
    public bool medalZombie1Lvl2, medalZombie2Lvl2, medalZombie3Lvl2, medalZombie4Lvl2, medalZombie5Lvl2, medalZombie6Lvl2;
    public bool coinCollected1Lvl2, coinCollected2Lvl2, coinCollected3Lvl2;

    [SerializeField]
    private GameObject batBurst = null;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gameController = GameController.GetGameControllerInScene();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!paused)
            {
                paused = true;
                Time.timeScale = 0f;
            }
            else
            {
                paused = false;
                Time.timeScale = 1f;
            }
        }
        if (Input.GetButtonDown("Jump") && !paused || CrossPlatformInputManager.GetButtonDown("Jump") && !paused)
        {
            if (grounded)
            {
                rb.AddForce(new Vector2(0, 1200));
                anim.SetTrigger("Jump");
                grounded = false;
                anim.SetBool("Grounded", false);
            }
        }
        if (Input.GetButtonDown("Fire1") && !paused || CrossPlatformInputManager.GetButtonDown("Fire1") && !paused)
        {
            anim.SetTrigger("Attack");
            GetComponent<AudioSource>().clip = launchSound;
            GetComponent<AudioSource>().PlayOneShot(launchSound);
        }
        //Newgrounds Achievements
        if(WhereAmI.instance.levelName == "Level1" && zombiesKilled >= 1 && medalZombie1Lvl1 == false)
        {
            medalZombie1Lvl1 = true;
            NGHelper.instance.unlockMedal(84875);
        }
        if (WhereAmI.instance.levelName == "Level1" && zombiesKilled >= 2 && medalZombie2Lvl1 == false)
        {
            medalZombie2Lvl1 = true;
            NGHelper.instance.unlockMedal(84876);
        }
        if (WhereAmI.instance.levelName == "Level1" && zombiesKilled >= 3 && medalZombie3Lvl1 == false)
        {
            medalZombie3Lvl1 = true;
            NGHelper.instance.unlockMedal(84877);
        }
        if (WhereAmI.instance.levelName == "Level1" && zombiesKilled >= 4 && medalZombie4Lvl1 == false)
        {
            medalZombie4Lvl1 = true;
            NGHelper.instance.unlockMedal(84878);
        }
        if (WhereAmI.instance.levelName == "Level1" && zombiesKilled >= 5 && medalZombie5Lvl1 == false)
        {
            medalZombie5Lvl1 = true;
            NGHelper.instance.unlockMedal(84879);
        }
        if (WhereAmI.instance.levelName == "Level1" && coinsCollected >= 1 && coinCollected1Lvl1 == false)
        {
            coinCollected1Lvl1 = true;
            NGHelper.instance.unlockMedal(84880);
        }
        if (WhereAmI.instance.levelName == "Level1" && coinsCollected >= 2 && coinCollected2Lvl1 == false)
        {
            coinCollected2Lvl1 = true;
            NGHelper.instance.unlockMedal(84881);
        }
        if (WhereAmI.instance.levelName == "Level1" && coinsCollected >= 3 && coinCollected3Lvl1 == false)
        {
            coinCollected3Lvl1 = true;
            NGHelper.instance.unlockMedal(84882);
        }
        if (WhereAmI.instance.levelName == "Level2" && zombiesKilled >= 1 && medalZombie1Lvl2 == false)
        {
            medalZombie1Lvl2 = true;
            NGHelper.instance.unlockMedal(84885);
        }
        if (WhereAmI.instance.levelName == "Level2" && zombiesKilled >= 2 && medalZombie2Lvl2 == false)
        {
            medalZombie2Lvl2 = true;
            NGHelper.instance.unlockMedal(84886);
        }
        if (WhereAmI.instance.levelName == "Level2" && zombiesKilled >= 3 && medalZombie3Lvl2 == false)
        {
            medalZombie3Lvl2 = true;
            NGHelper.instance.unlockMedal(84887);
        }
        if (WhereAmI.instance.levelName == "Level2" && zombiesKilled >= 4 && medalZombie4Lvl2 == false)
        {
            medalZombie4Lvl2 = true;
            NGHelper.instance.unlockMedal(84888);
        }
        if (WhereAmI.instance.levelName == "Level2" && zombiesKilled >= 5 && medalZombie5Lvl2 == false)
        {
            medalZombie5Lvl2 = true;
            NGHelper.instance.unlockMedal(84889);
        }
        if (WhereAmI.instance.levelName == "Level2" && zombiesKilled >= 6 && medalZombie6Lvl2 == false)
        {
            medalZombie6Lvl2 = true;
            NGHelper.instance.unlockMedal(84890);
        }
        if (WhereAmI.instance.levelName == "Level2" && coinsCollected >= 1 && coinCollected1Lvl2 == false)
        {
            coinCollected1Lvl2 = true;
            NGHelper.instance.unlockMedal(84891);
        }
        if (WhereAmI.instance.levelName == "Level2" && coinsCollected >= 2 && coinCollected2Lvl2 == false)
        {
            coinCollected2Lvl2 = true;
            NGHelper.instance.unlockMedal(84892);
        }
        if (WhereAmI.instance.levelName == "Level2" && coinsCollected >= 3 && coinCollected3Lvl2 == false)
        {
            coinCollected3Lvl2 = true;
            NGHelper.instance.unlockMedal(84893);
        }
    }

    void FixedUpdate()
    {
        if (dead)
        {
            return;
        }
        var horizontal = Input.GetAxis("Horizontal");
        var horizontalMobile = CrossPlatformInputManager.GetAxis("Horizontal");
        var localScale = transform.localScale;
        if (horizontal < 0 || horizontalMobile < 0)
        {
            localScale.x = 1;
        }
        else if (horizontal > 0f || horizontalMobile > 0f)
        {
            localScale.x = -1;
        }
        transform.localScale = localScale;
        if (horizontal != 0 || horizontalMobile != 0)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
        rb.linearVelocity = new Vector2(horizontal * 20, rb.linearVelocity.y);
        rb.linearVelocity = new Vector2(horizontalMobile * 20, rb.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            grounded = true;
            anim.SetBool("Grounded", true);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "zombie")
        {
            GetComponent<AudioSource>().clip = deadSound;
            GetComponent<AudioSource>().PlayOneShot(deadSound);
            rb.isKinematic = true;
            GetComponent<SpriteRenderer>().enabled = false;
            batBurst.SetActive(true);
            dead = true;
            collision.gameObject.GetComponent<ZombieController>().KillZombie();
            gameController.PlayerDied();
        }
        if (collision.gameObject.name == "Coin")
        {
            coinsCollected++;
            GetComponent<AudioSource>().clip = coinSound;
            GetComponent<AudioSource>().PlayOneShot(coinSound);
        }
        if (collision.gameObject.name == "CryptKey")
        {
            GetComponent<AudioSource>().clip = keySound;
            GetComponent<AudioSource>().PlayOneShot(keySound);
            if (WhereAmI.instance.levelName == "Level1")
            {
                NGHelper.instance.unlockMedal(84883);
            }
            if (WhereAmI.instance.levelName == "Level2")
            {
                NGHelper.instance.unlockMedal(84894);
            }
        }
    }
}
