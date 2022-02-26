using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gosma3 : MonoBehaviour
{

    private Rigidbody2D rig;
    public float Speed;
    private Vector2 direction;

    public Transform enemyGreen;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 2f);
        if (EnemyGreen3.instance.isRight == true)
        {
            rig.velocity = Vector2.right * Speed;
        }
        if (EnemyGreen3.instance.isRight == false)
        {
            rig.velocity = Vector2.left * Speed;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        //rig.velocity = Vector2.right * Speed;
    }
}