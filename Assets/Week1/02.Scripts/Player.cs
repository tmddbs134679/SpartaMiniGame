using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float direction;
    SpriteRenderer spriteRenderer;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            direction *= -1;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        if(transform.position.x <= -1.7f)
        {
            spriteRenderer.flipX = false;
            direction = 5f;

        }

        if (transform.position.x >= 1.7f)
        {
            spriteRenderer.flipX = true;
            direction = -5f;
        }

        transform.position += Vector3.right * direction * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Rain"))
        {
            SoundManager.instance.PlayOneShot(SoundType.Player, clip);
        }
    }
}
