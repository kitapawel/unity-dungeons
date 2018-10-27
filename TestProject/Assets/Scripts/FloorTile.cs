using UnityEngine;
using System.Collections;

public class FloorTile : MonoBehaviour {
    [SerializeField]
    private Sprite[] floorTiles;

    private SpriteRenderer mySpriteRenderer;

    // Use this for initialization

    void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        mySpriteRenderer.sprite = floorTiles[Random.Range(0, floorTiles.Length)];
    }

    // Update is called once per frame
    void Update()
    {

    }
}