using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject _pipePrefab;
    [SerializeField]
    private GameObject _pipeContainer;

    private Vector2 _screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(SpawnCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(3f);
        while (true)
        {
            float topPos = Random.Range(1.0f,4.0f) + _pipePrefab.GetComponent<SpriteRenderer>().bounds.extents.y;
            Vector3 spawnPosTop = new Vector3(_screenBounds.x, topPos, 0.0f);

            GameObject topPipe = Instantiate(_pipePrefab, spawnPosTop, Quaternion.identity);

            float botPos = topPos - Random.Range(3.5f, 5.0f) - _pipePrefab.GetComponent<SpriteRenderer>().bounds.size.y;
            Vector3 spawnPosBot = new Vector3(_screenBounds.x, botPos, 0.0f);

            GameObject botPipe = Instantiate(_pipePrefab, spawnPosBot, Quaternion.identity);

            topPipe.transform.parent = _pipeContainer.transform;
            botPipe.transform.parent = _pipeContainer.transform;

            yield return new WaitForSeconds(2f);
        }
    }

}
