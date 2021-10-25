using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    [SerializeField]
    private float speed = 5f;

    public float height;
    public float width;

    private BoxCollider2D bc;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector3(-speed, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
