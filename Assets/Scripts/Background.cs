using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    private SpriteRenderer sr;

    private RectTransform rt;

    float scrollSpeed = -5f;
    Vector2 startPos;
    
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rt = GetComponent<RectTransform>();

        ResizeToScreen();

        //set position after resizing
        startPos = transform.position;
        Debug.Log("start" + startPos.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, rt.rect.width * rt.localScale.x );
        transform.position = startPos + Vector2.right * newPos;

    }

    void ResizeToScreen()
    {
        transform.localScale = new Vector3(1, 1, 1);

        float w = sr.sprite.bounds.size.x;
        float h = sr.sprite.bounds.size.y;

        Debug.Log(w);
        Debug.Log(h);

        float worldHeight = (float)(Camera.main.orthographicSize * 2.0);
        float worldWidth = worldHeight / Screen.height * Screen.width;

        Debug.Log(worldHeight);
        Debug.Log(-rt.rect.width);

        gameObject.transform.localScale = new Vector3(worldWidth / w, worldHeight / h, 1);
        gameObject.transform.GetChild(0).transform.localScale = new Vector3(1, 1, 1);
        gameObject.transform.GetChild(0).transform.position = new Vector3(-rt.rect.width*rt.localScale.x,0);

    }
}
