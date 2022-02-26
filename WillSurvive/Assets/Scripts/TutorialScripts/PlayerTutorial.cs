using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTutorial : MonoBehaviour
{
    private Rigidbody2D rig;

    public float Speed;
    public float JumpForce;
    public float DoubleJumpForce;
    public int Life;

    public bool isJumping;
    private bool doubleJump;
    private bool isAttacking;
    public bool isRight;
    public bool isLeft;

    private float timeToAttack;
    public int recoveryTime;

    public LayerMask enemyLayer;
    public Animator anim;

    public GameObject Ice;
    public Transform icePoint;

    public static PlayerTutorial instance;

    //public Transform point;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        isRight = true;
        recoveryTime = 2;
        rig = GetComponent<Rigidbody2D>();
        //AudioController.current.PlayMusic(AudioController.current.door_open);
        //AudioController.current.PlayMusic(AudioController.current.backgroundSound);

    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Attack();
    }

    void FixedUpdate()
    {
        Move();

    }

    public void Move()
    {

        float movement = 0;
        rig.velocity = new Vector2(movement * Speed, rig.velocity.y);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movement = -1;
            rig.velocity = new Vector2(movement * Speed, rig.velocity.y);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            movement = 1;
            rig.velocity = new Vector2(movement * Speed, rig.velocity.y);
        }

        if (movement > 0)
        {
            if (!isJumping)
            {
                anim.SetInteger("Transition", 1);
            }
            transform.eulerAngles = new Vector3(0, 0, 0);
            isRight = true;
        }
        if (movement < 0)
        {
            if (!isJumping)
            {
                anim.SetInteger("Transition", 1);
            }
            transform.eulerAngles = new Vector3(0, 180, 0);
            isRight = false;
        }


        if (movement == 0 && !isJumping && !isAttacking)
        {
            anim.SetInteger("Transition", 0);
        }
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!isJumping)
            {
                anim.SetInteger("Transition", 2);
                rig.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
                isJumping = true;
                doubleJump = true;
            }
            else if (doubleJump)
            {
                anim.SetInteger("Transition", 3);
                rig.AddForce(Vector2.up * DoubleJumpForce, ForceMode2D.Impulse);
                doubleJump = false;
            }
        }
    }

    void Attack()
    {
        timeToAttack += Time.deltaTime;
        if (timeToAttack >= recoveryTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetTrigger("Attack");
                Instantiate(Ice, icePoint.position, icePoint.rotation);
                timeToAttack = 0;


            }
        }
    }

    IEnumerator OnAttack()
    {
        yield return new WaitForSeconds(0.333f);
        isAttacking = false;
    }

    void OnHit()
    {
        anim.SetTrigger("Hit");
        Life--;
        Debug.Log("Hit");
        GameController.instance.Health();

        if (Life <= 0)
        {
            Time.timeScale = 0;
            Debug.Log("GameOver");
            GameController.instance.ShowGameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D colisor)
    {
        //if (colisor.gameObject.layer == 6)
        //{
        //    isJumping = false;
        //}

        if (colisor.gameObject.layer == 10)
        {
            GameControllerGame.instance.ShowGameOver();
        }
        if (colisor.gameObject.layer == 11)
        {
            if (Input.GetKey(KeyCode.F))
            {
                Debug.Log("Tá no spawn");
                AudioControllerTutorial.current.PlayMusic(AudioControllerTutorial.current.door_closed);
                GameControllerGame.instance.WinGame();

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Plant"))
        {
            GameController.instance.GetPlant();
            Destroy(collision.gameObject, 0.25f);
        }

        if (collision.gameObject.layer == 9 && EnemyBlueTutorial.instance.isFrozed == false)
        {
            OnHit();
            Destroy(collision.gameObject, 0f);
            AudioControllerTutorial.current.PlayMusic(AudioControllerTutorial.current.hit_gosma);
        }

        if (collision.gameObject.layer == 7 && EnemyBlueTutorial.instance.isFrozed == false)
        {
            OnHit();
            AudioControllerTutorial.current.PlayMusic(AudioControllerTutorial.current.hit_collision);
        }
    }
}
