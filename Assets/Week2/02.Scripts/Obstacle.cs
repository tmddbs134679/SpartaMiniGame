using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float DestoryLine;

    // Start is called before the first frame update
    void Start()
    {
        InitValue();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.y <= DestoryLine)
        {
            Destroy(this.gameObject);
        }
          
    }
    private void InitValue()
    {
        DestoryLine = -5.6f;


        float x = Random.Range(-1.7f, 1.7f);
        int y = Random.Range(2, 5);
        float size = Random.Range(0.5f, 1.5f);


        transform.position = new Vector3(x, y, 0);

        transform.localScale = new Vector2(size, size);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            GameMananger.Instance.GameOver();
        }

    }

}
