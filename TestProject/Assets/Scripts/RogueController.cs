using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RogueController : MonoBehaviour {

    //general variables, serialized to get visibility in editor
    [SerializeField]
    private float moveSpeed = 2;
    [SerializeField]
    private Transform attackColliderTransform;
    [SerializeField]
    private Text moneyLbl;
    [SerializeField]
    private Text helpLbl;
   

    //working variables
    private float currentMoveSpeed;
    private bool isAlive = true;
    private bool isWalking = false;

    //loot variables
    private int goldHeld = 0;
    //help tips
    private int helpState = 0;

    

    //sounds
    [SerializeField]
    private AudioClip[] sfxFootSteps;
    [SerializeField]
    private AudioClip sfxDeathFall;
    [SerializeField]
    private AudioClip sfxGetHit;
    [SerializeField]
    private AudioClip sfxSwing;
    [SerializeField]
    private AudioClip sfxBodyHit;
    [SerializeField]
    private AudioClip collectCoin;
    [SerializeField]
    private AudioClip sfxPaper;

    //object references
    private Rigidbody2D myRigidBody;
    private Animator myAnim;
    private SpriteRenderer mySpriteRenderer;
    private AudioSource myAudioSource;
    private GameObject respawnLocation;

    private bool respawnRunning = false;



    void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        currentMoveSpeed = moveSpeed;
        myAudioSource = GetComponent<AudioSource>();
        GoldUpdate();
        InfoUpdate();
        respawnLocation = GameObject.FindGameObjectWithTag("Respawn");

    }
	
	
	void Update () {

        if (isAlive)
        {
            MovePlayer();
            Attack();
        }


        if (!isAlive)
        {
            if (respawnRunning == false)
            StartCoroutine (Respawn());
            
        }


    }

    IEnumerator Respawn()
    {
        respawnRunning = true;
        gameObject.tag = "Corpse";
        myAnim.Play("rogue_death1");
        yield return new WaitForSeconds(3);
        if (goldHeld >= 10)
        {
            SpendCoin();
            transform.position = respawnLocation.transform.position;
            isAlive = true;
            myAnim.Play("rogue_parry1");
            gameObject.tag = "Player";
         }
        respawnRunning = false;
        yield return null;


    }

    private void MovePlayer()
    {
        if (Input.GetKey(KeyCode.D))
        {
            // transform.position = new Vector3(currentMoveSpeed, myRigidBody.velocity.y, 0f);
            myAnim.SetBool("isWalking", true);
            isWalking = (true);
            transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
            transform.Translate(Vector2.right * currentMoveSpeed * Time.deltaTime);
            if (myAudioSource.isPlaying == false)
                myAudioSource.PlayOneShot(sfxFootSteps[Random.Range(0, 4)]);

        } else if (Input.GetKey(KeyCode.A))
        {
            myAnim.SetBool("isWalking", true);
            isWalking = (true);
            transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
            transform.Translate(Vector2.left * currentMoveSpeed * Time.deltaTime);
            if (myAudioSource.isPlaying == false)
                myAudioSource.PlayOneShot(sfxFootSteps[Random.Range(0, sfxFootSteps.Length)]);

        }  else 
        {
            myAnim.SetBool("isWalking", false);
            isWalking = (false);
            
        }

        //if (Input.GetKey(KeyCode.Space))
        //{
        //    isAlive = false;
        //}


    }

    private void Attack()
    {

        if (Input.GetMouseButton(1))
        {   
            myAnim.Play("rogue_attack2");
        }
       
        if (Input.GetMouseButton(0))
        {
            myAnim.Play("rogue_attack1");

        }
    
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            myAnim.Play("rogue_parry1");

        }
    }

    // check for AttackCollider to see if damage is received
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "AttackCollider" || coll.gameObject.layer == 14)
        {
            myAudioSource.PlayOneShot(sfxBodyHit);
            isAlive = false;
        }

        if (coll.gameObject.layer == 15)
        {
            Destroy(coll.gameObject);
            CollectCoin();
        }
        if (coll.gameObject.layer == 16)
        {
            Destroy(coll.gameObject);
            CollectInfo();
        }


    }

    private void CollectCoin()
    {
        
        goldHeld += 1;
        myAudioSource.PlayOneShot(collectCoin);
        GoldUpdate();
    }

    private void SpendCoin()
    {

        goldHeld -= 10;
        myAudioSource.PlayOneShot(collectCoin);
        GoldUpdate();
    }

    private void CollectInfo()
    {
        helpState += 1;
        myAudioSource.PlayOneShot(sfxPaper);
        InfoUpdate();
    }

    private void GoldUpdate()
    {
        moneyLbl.text = "Gold: " + goldHeld.ToString();
    }

    private void InfoUpdate()
    {
        
        switch (helpState)
        {
            case 0:
                helpLbl.text = "Use W, S, A, D keys to move, LMB/RMB to attack, Move+E to interact. Collect coins from chests - respawn costs 10 coins.";
                
                break;
            case 1:
                helpLbl.text = "Many items in the world are interactive. Use or destroy them.";
                respawnLocation.transform.position = new Vector2(-7.89f, -2.231f);
                break;
            case 2:
                helpLbl.text = "Watch out for traps. Sometimes it may be necessary to move away from danger.";
                respawnLocation.transform.position = new Vector2(-21.8f, -2.231f);
                break;
            case 3:
                helpLbl.text = "Some traps may have hidden activate/deactivate switches.";
                respawnLocation.transform.position = new Vector2(-29.4f, -2.231f);
                break;
           case 4:
                helpLbl.text = "Falling objects deal damage based on velocity. Get away from quickly moving items or shield yourself using other items.";
                respawnLocation.transform.position = new Vector2(-40.93f, -2.231f);
                break;
            case 5:
                helpLbl.text = "The cultist is a relentless enemy. Attack him quickly or use traps to your advantage.";
                respawnLocation.transform.position = new Vector2(-59.6f, -2.231f);
                break;

            default:
                print("Use W, S, A, D keys to move, LMB/RMB to attack, E to interact.");
                break;
        }
    }


    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.tag == "AttackCollider")
    //    {
    //        myAudioSource.PlayOneShot(sfxBodyHit);
    //        isAlive = false;
    //    }

    //}

    private void SetSpeed(float value)
    {
        currentMoveSpeed = value;
    }

    private void ResetSpeed()
    {
        currentMoveSpeed = moveSpeed;
    }

    private void ResetRotation()
    {
        attackColliderTransform.transform.rotation = Quaternion.identity;
    }

    private void IsWalking (bool value)
    {
        isWalking = value;       
    }

    private void PlayDeathSound()
    {
        myAudioSource.PlayOneShot(sfxDeathFall);
    }

    private void PlaySwingSound()
    {
        myAudioSource.PlayOneShot(sfxSwing);
    }

   

}
