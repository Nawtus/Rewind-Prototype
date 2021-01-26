using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [Header("Movement")]
    private Rigidbody2D rig;
    [SerializeField] float horizontal;
    [SerializeField] float vertical;
    [SerializeField] bool isLookLeft;
    [SerializeField] float speed;
    public float Speed { get => speed; set => speed = value; }

    void Start()
    {
        //Movement
        rig = GetComponent<Rigidbody2D>();
        Speed = 5f;
    }



    void FixedUpdate()
    {
        Movement();
    }



    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        //vertical = Input.GetAxisRaw("Vertical");

        if (horizontal > 0 && isLookLeft == true)
        {
            Flip();
        }
        else if (horizontal < 0 && isLookLeft == false)
        {
            Flip();
        }
    }



    void Movement()
    {
        if (horizontal != 0 /*&& vertical != 0*/)
        {
            horizontal *= 0.75f;
            //vertical *= 0.75f;
        }

        rig.velocity = new Vector2(horizontal * Speed, rig.velocity.y);

        /*if (horizontal != 0 || vertical != 0)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }*/
    }



    void Flip()
    {
        if (isLookLeft == true)
        {
            isLookLeft = !isLookLeft;
            transform.Rotate(0, 180, 0);
        }
        else if (isLookLeft == false)
        {
            isLookLeft = !isLookLeft;
            transform.Rotate(0, 180, 0);
        }
    }
}
