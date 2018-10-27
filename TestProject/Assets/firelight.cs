using UnityEngine;
using System.Collections;

public class firelight : MonoBehaviour {

    private Light myLight;
	
	void Start () {
        myLight = GetComponent<Light>();
	}
	
	
	void Update () {
	    if (Random.Range(1f,2f) > 1.5f)
        {
            myLight.intensity = Random.Range(2f, 8f);
        }
	}
}
