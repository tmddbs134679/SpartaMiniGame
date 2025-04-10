using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CatType
{
    normal = 1,
    full = 2,
    pirate = 3,
}
public class Cat : MonoBehaviour
{
    [Header("Cat Settings")]
    public CatType type = CatType.normal;

    public GameObject hungrycat;
    public GameObject fullCat;

    public RectTransform front;

    float full = 5.0f;
    float ennergy = 0.0f;
    bool isFull;

    [SerializeField]private AudioClip Ac;

    float speed;
    // Start is called before the first frame update
    void Start()
    {
        InitPos();
        InitType();
    }

    private void InitPos()
    {
        float x = Random.Range(-9, 9);
        float y = 30f;
        transform.position = new Vector2(x, y);

    }

    private void InitType()
    {
        switch(type)
        {
            case CatType.normal:
                speed = 3.2f;
                full = 5f;
                break;
            case CatType.full:
                speed = 2.5f;
                full = 10f;
                break;
            case CatType.pirate:
                speed = 2f;
                full = 10f;
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(ennergy < full)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            if(transform.position.y < -16f)
            {
                cat.GameManager.instance.Gameover();

            }
        }
    
        else
        {
            if(transform.position.x > 0)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            else
            {
                transform.position += Vector3.left * speed * Time.deltaTime; ;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Food"))
        {
            if (ennergy < full)
            {
                ennergy += 1.0f;
                front.localScale = new Vector3(ennergy / full, 1f, 1f);

                Destroy(collision.gameObject);

                if(ennergy == full)
                {
                    if(!isFull)
                    {
                        SoundManager.instance.PlayOneShot(SoundType.ETC, Ac);
                        isFull = true;
                        hungrycat.SetActive(false);
                        fullCat.SetActive(true);
                        Destroy(gameObject, 3f);
                        cat.GameManager.instance.AddScore();
                    }
                }
            }
        }
    }
}
