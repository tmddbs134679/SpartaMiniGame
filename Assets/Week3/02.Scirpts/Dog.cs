using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public GameObject food;
    public AudioClip Ac;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.PlayLoop(SoundType.Player, Ac);

        InvokeRepeating("MakeFood", 0f, 0.15f);
    }

    
    // Update is called once per frame
    void Update()
    {
        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

       
        float x = mousepos.x;

        if(x < -8.5f)
        {
            x = -8.5f;
        }
        
        if(x > 8.5f)
        {
            x = 8.5f;
        }

        transform.position = new Vector2(x, transform.position.y);
    }

    void MakeFood()
    {
        float x = transform.position.x;
        float y = transform.position.y + 2;

        Instantiate(food,new Vector2(x,y), Quaternion.identity);

    }
}
