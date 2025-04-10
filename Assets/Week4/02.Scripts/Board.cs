using System;
using System.Linq;
using UnityEngine;


public class Board : MonoBehaviour
{
    [Header("Setting")]
    public GameObject card;
    public Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };

        arr = arr.OrderBy(x => Guid.NewGuid()).ToArray();

        for (int i = 0; i < 16; i++)
        {
            GameObject go = Instantiate(card, this.transform);

            float x = (i % 4) * 1.4f - offset.x;
            float y = (i / 4) * 1.4f - offset.y;

            go.transform.position = new Vector2(x, y);
            go.GetComponent<Card>().Setting(arr[i]);

        }
        CARD.GameManager.instance.cardCount = arr.Length;
    }
}
