using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    [SerializeField]
    private bool followPlayer = true;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float followAhead = 2;
    [SerializeField]
    private float smoothing = 2;

    private Vector3 playerPosition;

    void Update()
    {
        if (player == null)
        {
           player = GameObject.FindGameObjectWithTag("Player");
        }
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (followPlayer)
        {
            //Get position of the player and put it in the playerPosition variable
            playerPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

            //calculate player's position and orientation including the followAhead value
            if (player.transform.localScale.x > 0f)
            {
                playerPosition = new Vector3(playerPosition.x + followAhead, transform.position.y, transform.position.z);
            }
            else
            {
                playerPosition = new Vector3(playerPosition.x - followAhead, transform.position.y, transform.position.z);
            }

            // move the camera to the player's position with a LERP smoothing
            transform.position = Vector3.Lerp(transform.position, playerPosition, smoothing * Time.deltaTime);
        }
    }
}
