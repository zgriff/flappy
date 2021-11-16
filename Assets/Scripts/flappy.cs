using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class Flappy : MonoBehaviour
{

    public int _score = 0;
    private bool _alive;

    [SerializeField]
    private UIController _UI;

    private Rigidbody2D _rb;

    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _UI = GameObject.Find("Canvas").GetComponent<UIController>();
        _alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space) && _alive)
        //{
        //    _rb.velocity = new Vector3(0,5,0);
        //    _animator.SetTrigger("flap");

        //    Debug.Log("space");
        //}
        //if (Input.GetKeyDown(KeyCode.R) && !_alive)
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //}
    }

    void OnJump()
    {
        if (_alive)
        {
            _rb.velocity = new Vector3(0, 5, 0);
            _animator.SetTrigger("flap");
        }
    }

    void OnRestart()
    {
        if (!_alive)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Goal"))
        {
            _score += 1;

            _UI.UpdateScore(_score);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Pipe"))
        {
            _alive = false;
        }
    }

    public bool isAlive()
    {
        return _alive;
    }



}
