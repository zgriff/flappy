using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flappy : MonoBehaviour
{

    public Rigidbody2D rb;

    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(0,5,0);
            animator.SetTrigger("flap");

            Debug.Log("space");
        }
    }
}
