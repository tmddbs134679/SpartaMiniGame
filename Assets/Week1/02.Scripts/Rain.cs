using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    private float size = 1f;
    private int score = 1;
    private SpriteRenderer spriteRenderer;

    private enum RainType
    {
        Red = 1,
        Yellow = 2,
        Black = 3
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        InitPosition();
        InitType();
    }

    private void InitPosition()
    {
        float x = Random.Range(-1.8f, 1.8f);
        float y = Random.Range(3f, 5f);
        transform.position = new Vector3(x, y, 0);
    }

    private void InitType()
    {
        RainType type = (RainType)Random.Range(1, 4);

        switch (type)
        {
            case RainType.Red:
                SetRain(0.5f, -5, Color.red);
                break;

            case RainType.Yellow:
                SetRain(1f, 2, Color.yellow);
                break;

            case RainType.Black:
                SetRain(1.2f, 3, Color.black);
                break;
        }

        transform.localScale = Vector3.one * size;
    }

    private void SetRain(float size, int score, Color color)
    {
        this.size = size;
        this.score = score;
        spriteRenderer.color = color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                GameManager.Instance.AddScore(score);
            }

            Destroy(gameObject);
        }
    }
}
