using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameFunction : MonoBehaviour {

    [SerializeField]
    private Text EndGameLbl;
    [SerializeField]
    private Image EndScreen;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(EndGame());
        }

    }

    IEnumerator EndGame()
    {
        EndGameLbl.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        EndScreen.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
        yield return null;
    }
}
