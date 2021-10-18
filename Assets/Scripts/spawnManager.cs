using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject _pipePrefab;
    [SerializeField]
    private GameObject _pipeContainer;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(_pipePrefab.GetComponent<SpriteRenderer>().bounds.size.y);
        StartCoroutine(SpawnCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            float topPos = Random.Range(1.0f,4.0f) + _pipePrefab.GetComponent<SpriteRenderer>().bounds.size.y / 2;
            Vector3 spawnPosTop = new Vector3(9.0f, topPos, 0.0f);

            GameObject topPipe = Instantiate(_pipePrefab, spawnPosTop, Quaternion.identity);

            float botPos = topPos - Random.Range(3.5f, 5.0f) - _pipePrefab.GetComponent<SpriteRenderer>().bounds.size.y;
            Vector3 spawnPosBot = new Vector3(9.0f, botPos, 0.0f);

            GameObject botPipe = Instantiate(_pipePrefab, spawnPosBot, Quaternion.identity);

            topPipe.transform.parent = _pipeContainer.transform;
            botPipe.transform.parent = _pipeContainer.transform;

            yield return new WaitForSeconds(5f);
        }
    }

}
