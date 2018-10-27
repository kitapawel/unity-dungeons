using UnityEngine;
using System.Collections;

public class WallTop : MonoBehaviour {
    [SerializeField]
    private Sprite[] wallTiles;

    private SpriteRenderer mySpriteRenderer;

    // Use this for initialization

    void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        mySpriteRenderer.sprite = wallTiles[Random.Range(0, wallTiles.Length)];
    }

    // Update is called once per frame
    void Update()
    {

    }
}

