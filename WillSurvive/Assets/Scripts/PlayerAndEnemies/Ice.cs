    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{

    private Rigidbody2D rg;
    public float Speed;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3f);
        if (Player.instance.isRight == true)
        {
            rg.velocity = Vector2.right * Speed;
        }
        else
        {
            rg.velocity = Vector2.left * Speed;
        }

        //rig.AddForce(new Vector2(1,0) * Speed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //if (player.rotation.y == 0)
        //{
        //    rg.velocity = Vector2.right * Speed;
        //}

        //if (player.rotation.y == -180)
        //{
        //    rg.velocity = Vector2.left * Speed;
        //}
        
    }

}
