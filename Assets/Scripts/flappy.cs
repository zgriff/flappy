using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class Flappy : MonoBehaviour
{

    public int _score = 0;

    [SerializeField]
    private bool _alive;

    [SerializeField]
    private UIController _UI;

    private Rigidbody2D _rb;

    private Animator _animator;

    private PlayerInput _input;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _input = GetComponent<PlayerInput>();
        _UI = GameObject.Find("Canvas").GetComponent<UIController>();
        _alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
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
            _input.SwitchCurrentActionMap("Player");
            SceneManager.LoadScene("GameScene");
        }
    }

    void OnQuit()
    {
        if (!_alive)
        {
            SceneManager.LoadScene("MenuScene");
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
            _input.SwitchCurrentActionMap("GameOver");
        }
    }

    public bool isAlive()
    {
        return _alive;
    }



}
