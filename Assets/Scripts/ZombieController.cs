using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class ZombieController : MonoBehaviour
{

    [SerializeField]
    private int health = 3;
    private bool isDead;
    private bool isReadyToMove;
    private Animator anim;
    private GameController gameController;
    private SpriteRenderer sprtRnd;
    [SerializeField]
    private GameObject hitPrefab = null;

    private Rigidbody2D rb;
    private DateTime playerSpottedTime;
    private Vector2 lastVelocity;
    public AudioClip hitSound;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Idle", true);
        sprtRnd = GetComponent<SpriteRenderer>();
        gameController = GameController.GetGameControllerInScene();
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(ActivateMe());
    }

    IEnumerator ActivateMe()
    {
        yield return new WaitForSeconds(Random.Range(3, 7));
        isReadyToMove = true;
    }

    public void GotHit()
    {
        if(isDead) return;
        StartCoroutine(FlashZombieRed());
        anim.SetTrigger("GotHit");
        health -= 1;
        Instantiate(hitPrefab, transform.position, Quaternion.identity);
        if (health <= 0)
        {
            KillZombie();
            AnaMariaController.instance.zombiesKilled++;
        }
    }

    IEnumerator FlashZombieRed()
    {
        sprtRnd.material.color = Color.red;
        yield return new WaitForSeconds(.2f);
        sprtRnd.material.color = Color.white;
    }

    public void KillZombie()
    {
        if(isDead) return;
        isDead = true;
        anim.SetBool("Die", true);
        anim.SetBool("Walk", false);
        anim.SetBool("Idle", false);
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().isKinematic = true;
        StartCoroutine(FadeAway());
    }

    IEnumerator FadeAway()
    {
        yield return new WaitForSeconds(1);
        while (sprtRnd.color.a > 0)
        {
            var color = sprtRnd.color;
            color.a -= (.5f * Time.deltaTime);
            sprtRnd.color = color;
            yield return null;
        }
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "rocket")
        {
            GetComponent<AudioSource>().clip = hitSound;
            GetComponent<AudioSource>().PlayOneShot(hitSound);
            gameController.incrementPoints(10);
            Destroy(collision.gameObject);
            GotHit();
        }
    }

    void FixedUpdate()
    {
        bool foundPlayer = false;
        if(isDead) return;
        if (!isReadyToMove) return;
        var hitLeft = Physics2D.Raycast(transform.position, Vector2.left, Mathf.Infinity, (1 << 6));
        if (hitLeft.collider != null)
        {
            if (transform.localScale.x != -1f)
            {
                var scale = transform.localScale;
                scale.x = -1;
                transform.localScale = scale;
            }
            lastVelocity = transform.TransformDirection(-1 * Time.deltaTime * 75, 0, 0);
            rb.linearVelocity = lastVelocity;
            foundPlayer = true;
        }
        else
        {
            var hitRight = Physics2D.Raycast(transform.position, Vector2.right, Mathf.Infinity, (1 << 6));
            if (hitRight.collider != null)
            {
                if (transform.localScale.x != 1f)
                {
                    var scale = transform.localScale;
                    scale.x = 1;
                    transform.localScale = scale;
                }
                lastVelocity = transform.TransformDirection(1 * Time.deltaTime * 75, 0, 0);
                rb.linearVelocity = lastVelocity;
                foundPlayer = true;
            }
        }
        if (foundPlayer)
        {
            playerSpottedTime = DateTime.Now;
        }
        else
        {
            if (playerSpottedTime != DateTime.MinValue && DateTime.Now.Subtract(playerSpottedTime).TotalSeconds < 2)
            {
                foundPlayer = true;
                rb.linearVelocity = lastVelocity;
            }
        }
        if (foundPlayer)
        {
            anim.SetBool("Walk", true);
            anim.SetBool("Idle", false);
        }
        else
        {
            anim.SetBool("Idle", true);
            anim.SetBool("Walk", false);
        }
    }
}
