using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe : MonoBehaviour
{

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("here");
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(-transform.right * 100.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
