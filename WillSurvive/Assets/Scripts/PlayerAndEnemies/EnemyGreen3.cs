using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGreen3 : MonoBehaviour
{

    private Rigidbody2D rig;
    private bool isFront;
    private Vector2 direction;


    public Transform behind;
    public Transform point;
    public float maxVision;

    public bool isRight;

    public GameObject gosma;
    public Transform gosmaPoint;

    private float timeToAttack;
    public int recoveryTime;

    private float timeFrozedAtual;
    public int timeFrozed;
    public bool isFrozed;

    public Animator anim;
    public static EnemyGreen3 instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        isRight = false;
        isFrozed = true;
        isFront = false;
        recoveryTime = 2;
        timeFrozedAtual = 5;
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isFrozed == true)
        {
            timeFrozedAtual += Time.deltaTime;
            if (timeFrozedAtual >= timeFrozed)
            {
                timeFrozedAtual = 0;
                isFrozed = false;
                anim.SetBool("Iced", false);

            }
        }
    }

    private void FixedUpdate()
    {
        GetPlayer();
        TurnToPlay();
        Attack();
    }

    void TurnToPlay()
    {
        if (isRight && !isFrozed)
        {
            transform.eulerAngles = new Vector2(0, 180);
            direction = Vector2.right;
        }
        if (!isRight && !isFrozed)
        {
            transform.eulerAngles = new Vector2(0, 0);
            direction = Vector2.left;
        }
    }

    void Attack()
    {

        timeToAttack += Time.deltaTime;
        if (timeToAttack >= recoveryTime)
        {
            if (isFront == true && !isFrozed)
            {
                Instantiate(gosma, gosmaPoint.position, gosmaPoint.rotation);
                timeToAttack = 0;
            }
        }
    }


    void GetPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(point.position, direction, maxVision);

        if (hit.collider != null)
        {
            if (hit.transform.CompareTag("Player"))
            {
                isFront = true;
            }
            else { isFront = false; }
        }

        RaycastHit2D behindHit = Physics2D.Raycast(behind.position, -direction, maxVision);

        if (behindHit.collider != null)
        {
            if (behindHit.transform.CompareTag("Player"))
            {
                isRight = !isRight;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawRay(point.position, direction * maxVision);
    }


    void OnHit()
    {
        isFrozed = true;
        anim.SetBool("Iced", true);
        AudioController.current.PlayMusic(AudioController.current.frizedSlime);
        Debug.Log("Congelado");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            OnHit();
            Destroy(collision.gameObject, 0f);
        }
    }
}