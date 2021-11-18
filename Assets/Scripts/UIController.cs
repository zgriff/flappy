using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreText;

    [SerializeField]
    private TextMeshProUGUI _gameOverText;

    [SerializeField]
    private GameObject flappy;

    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score: " + 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!flappy.GetComponent<Flappy>().isAlive())
        {
            _gameOverText.gameObject.SetActive(true);
        }
    }

    public void UpdateScore(int score)
    {
        _scoreText.text = "Score: " + score.ToString();
    }
}
