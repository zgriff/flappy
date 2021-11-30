using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    [SerializeField]
    private GameObject _pipePrefab;
    [SerializeField]
    private GameObject _pipeContainer;
    [SerializeField]
    private GameObject _goalPrefab;
    [SerializeField]
    private GameObject _player;


    private Vector2 _screenBounds;

    private bool spawning;

    // Start is called before the first frame update
    void Start()
    {
        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(SpawnCoroutine());
    }

    // Update is called once per frame
    void Update() 
    {
        if (!_player.GetComponent<Flappy>().isAlive() && spawning)
        {
            Debug.Log("dead");
            spawning = false;
            StopCoroutine(SpawnCoroutine());
        }
    }


    IEnumerator SpawnCoroutine()
    {
        spawning = true;

        yield return new WaitForSeconds(3f);

        while (spawning)
        {
            float topPos = Random.Range(1.0f,4.0f) + _pipePrefab.GetComponent<SpriteRenderer>().bounds.extents.y;
            Vector3 spawnPosTop = new Vector3(_screenBounds.x + _pipePrefab.GetComponent<SpriteRenderer>().bounds.extents.x, topPos, 0.0f);

            GameObject topPipe = Instantiate(_pipePrefab, spawnPosTop, Quaternion.identity);

            float botPos = topPos - Random.Range(3.5f, 5.0f) - _pipePrefab.GetComponent<SpriteRenderer>().bounds.size.y;
            Vector3 spawnPosBot = new Vector3(_screenBounds.x + _pipePrefab.GetComponent<SpriteRenderer>().bounds.extents.x, botPos, 0.0f);

            GameObject botPipe = Instantiate(_pipePrefab, spawnPosBot, Quaternion.identity);

            topPipe.transform.parent = _pipeContainer.transform;
            botPipe.transform.parent = _pipeContainer.transform;

            topPipe.GetComponent<SpriteRenderer>().sortingLayerName = "Foreground";
            botPipe.GetComponent<SpriteRenderer>().sortingLayerName = "Foreground"; 

            GameObject goal = Instantiate(_goalPrefab, new Vector3(_screenBounds.x, (topPos + botPos) / 2f, 0f), Quaternion.identity);

            goal.transform.parent = _pipeContainer.transform;

            Vector3 goalSize = new Vector3(_pipePrefab.GetComponent<SpriteRenderer>().bounds.extents.x, Vector3.Distance(spawnPosBot, spawnPosTop) - _pipePrefab.GetComponent<SpriteRenderer>().bounds.size.y,1);
            goal.transform.localScale = goalSize;

            yield return new WaitForSeconds(1.25f);
        }

    }

}
