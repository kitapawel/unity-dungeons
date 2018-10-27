using UnityEngine;
using System.Collections;

public class LootDrop : MonoBehaviour {

    [SerializeField]
    private GameObject coin;
    [SerializeField]
    private GameObject dropLocation;

    
    IEnumerator DropCoins()
    {
        float coinsToDrop = Random.Range(10f, 17f);
        for (var f = coinsToDrop; f >= 0; f -= 1)
        {
            GameObject coinGenerated = Instantiate(coin, dropLocation.transform.position, Quaternion.identity) as GameObject;
            coinGenerated.GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(-1f,1f), Random.Range(4f,8f), 0);
            yield return new WaitForSeconds(.2f);
        }
        
    }

}
