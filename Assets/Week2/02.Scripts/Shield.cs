using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public AudioClip[] clips;
    public bool toggle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Vector2 mousePos =  Camera.main.ScreenToWorldPoint(Input.mousePosition);

       transform.position = mousePos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Box"))
        {
            if(toggle)
            {
                SoundManager.instance.PlayOneShot(SoundType.Player, clips[0]);
            }
            else
            {
                SoundManager.instance.PlayOneShot(SoundType.Player, clips[1]);
            }

            toggle = !toggle;
        }
    }

}
