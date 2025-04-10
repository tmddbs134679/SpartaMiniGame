using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [Header("UI Setting")]
    public SpriteRenderer frontImg;
    [Header("Anim Setting")]
    public Animator anim;

    [Header("Audio Setting")]
    public AudioClip clip;
    AudioSource audioSource;

    [Header("Card Setting")]
    public int idx = 0;
    public GameObject front;
    public GameObject back;
    public bool isOpen = false;

    

    [Header("Delay Settings")]
    [SerializeField] private float openDelay = 0.3f;
    [SerializeField] private float destroyDelay = 0.5f;
    [SerializeField] private float closeDelay = 0.8f;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();  
    }


    public void Setting(int num)
    {
        idx = num;
        frontImg.sprite = Resources.Load<Sprite>($"rtan{idx}");
    }

    public void OpenCard()
    {
        if (isOpen)
            return;

        isOpen = true;

        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }

        if (anim != null)
        {
            anim.SetBool("IsOpen", true);
        }

        StartCoroutine(OpenCardRoutine());

        var manger = CARD.GameManager.instance;

        if (manger.firstcard == null)
        {
            manger.firstcard = this;
        }
        else
        {
            manger.secondcard = this;
            manger.Matched();
        }
    }

    private IEnumerator OpenCardRoutine()
    {
        yield return new WaitForSeconds(openDelay);
        front.SetActive(true);
        back.SetActive(false);
    }
    public void DestoryCard()
    {
        StartCoroutine(DestroyCardRoutine());
    }

    private IEnumerator DestroyCardRoutine()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }

    public void CloseCard()
    {
        StartCoroutine(CloseCardRoutine());
    }

    private IEnumerator CloseCardRoutine()
    {
        yield return new WaitForSeconds(closeDelay);

        if (anim != null)
        {
            anim.SetBool("IsOpen", false);
        }

        front.SetActive(false);
        back.SetActive(true);
    }
}
