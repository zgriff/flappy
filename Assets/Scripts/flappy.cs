using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Flappy : MonoBehaviour
{

    public Rigidbody2D rb;

    Animator animator;

    public int score = 0;

    [SerializeField]
    private UIController _UI;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        _UI = GameObject.Find("Canvas").GetComponent<UIController>();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Goal"))
        {
            score += 1;

            _UI.UpdateScore(score);
        }
    }
}
