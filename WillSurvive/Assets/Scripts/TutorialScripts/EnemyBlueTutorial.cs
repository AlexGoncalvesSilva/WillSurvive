using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlueTutorial : MonoBehaviour
{

    private Rigidbody2D rig;
    public float Speed;

    private float timeWalkAtual;
    public int timeWalk;

    private float timeFrozedAtual;
    public int timeFrozed;
    public bool isFrozed;

    private bool isRight;

    public Animator anim;
    public static EnemyBlueTutorial instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        timeFrozedAtual = 5;
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isFrozed == true)
        {
            rig.velocity = new Vector2(0, rig.velocity.y);
            timeFrozedAtual += Time.deltaTime;
            if (timeFrozedAtual >= timeFrozed)
            {
                timeFrozedAtual = 0;
                isFrozed = false;
                anim.SetBool("Iced", false);

            }
        }

        if (!isFrozed)
        {
            timeWalkAtual += Time.deltaTime;
            rig.velocity = new Vector2(Speed, rig.velocity.y);

            if (timeWalkAtual >= timeWalk)
            {
                timeWalkAtual = 0;
                Speed = -Speed;

                if (transform.eulerAngles.y == 0)
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
            }
        }
        //else {
        //    rig.velocity = new Vector2(0, rig.velocity.y);
        //}

    }

    void OnHit()
    {
        isFrozed = true;
        anim.SetBool("Iced", true);
        AudioControllerTutorial.current.PlayMusic(AudioControllerTutorial.current.frizedSlime);
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