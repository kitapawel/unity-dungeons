using UnityEngine;
using System.Collections;

public class NPCControllerArab : MonoBehaviour {

    //general variables, serialized to get visibility in editor
    [SerializeField]
    private float moveSpeed = 2;
    [SerializeField]
    private float currentMoveSpeed;
    [SerializeField]
    private Transform attackColliderTransform;

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

    //working variables with getters/setters
   
    private bool isAlive = true;
    private bool seesPlayer = false;
    private bool isAttacking = false;
    private GameObject targetEnemy;

    //object references
    private Rigidbody2D myRigidBody;
    private Animator myAnim;
    private SpriteRenderer mySpriteRenderer;
    private AudioSource myAudioSource;
    private Transform myTransform;



    public bool IsAlive
    {
        get
        {
            return isAlive;
        }

        set
        {
            isAlive = value;
        }
    }

    public bool SeesPlayer
    {
        get
        {
            return seesPlayer;
        }

        set
        {
            seesPlayer = value;
        }
    }

    public bool IsAttacking
    {
        get
        {
            return isAttacking;
        }

        set
        {
            isAttacking = value;
        }
    }

    public GameObject TargetEnemy
    {
        get
        {
            return targetEnemy;
        }

        set
        {
            targetEnemy = value;
        }
    }

    void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        currentMoveSpeed = moveSpeed;
        myAudioSource = GetComponent<AudioSource>();
        myTransform = GetComponent<Transform>();


    }

    
        void FixedUpdate() {

        if (IsAlive)
        {
            if (SeesPlayer && IsAlive)
            {
                FollowPlayer();
            }

            if (!SeesPlayer && IsAlive)
            {
                myAnim.SetBool("isWalking", false);
            }
                   

        }

        if (!IsAlive)
        {
           myAnim.Play("arab_death1");
         
        }
    }

    private void FollowPlayer()
    {
        // set walking if AI sees the player
        myAnim.SetBool("isWalking", true);
        transform.position = Vector2.MoveTowards(transform.position, targetEnemy.transform.position, currentMoveSpeed * Time.deltaTime);
        
        //if target is to the left
        if (AngleDir(transform.position, targetEnemy.transform.position) > 0 )
        {
            transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
        //if target is to the right
        } else if (AngleDir(transform.position, targetEnemy.transform.position) < 0 )
        {
            transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
        }


        ////if target is to the left
        //if (AngleDir(transform.position, targetEnemy.transform.position) > 0 && transform.localScale.x == 1)
        //{
        //    transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
        //    //if target is to the right
        //}
        //else if (AngleDir(transform.position, targetEnemy.transform.position) < 0 && transform.localScale.x == -1)
        //{
        //    transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
        //}




        // play footsteps
        if (myAudioSource.isPlaying == false)
        {
            myAudioSource.PlayOneShot(sfxFootSteps[Random.Range(0, 4)]);
        }
            
    }

    private void Attack()
    {
        {
            myAnim.Play("arab_attack1");
        }
    }

    //method used to compare vectors of Enemy and player and to determine if player is to the right or left of the Enemy
    public static float AngleDir(Vector2 A, Vector2 B)
    {
        return -A.x * B.y + A.y * B.x;
    }


    // check for AttackCollider to see if damage is received
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "AttackCollider" && isAlive)
        {
            myAudioSource.PlayOneShot(sfxBodyHit);
            IsAlive = false;
        }

        if (coll.gameObject.layer == 14 && isAlive)
        {
            myAudioSource.PlayOneShot(sfxBodyHit);
            IsAlive = false;
        }

        if (coll.gameObject.tag == "Corpse")
        {
            SeesPlayer = false;
        }

        if (coll.gameObject.tag == "Player" && isAlive)
        {
            Attack();
        }

        if (coll.gameObject.tag == "ObjectCollidable" && !isAttacking && isAlive)
        {
            //StartCoroutine(Wait(1));
            Attack();
        }

    }

    //IEnumerator Wait(float time)
    //{
    //    yield return new WaitForSeconds(time);
    //}

    //check if player Area markers enter the enemy body collider
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerArea" && !isAttacking && isAlive && seesPlayer)
        {
            Attack();
        }
        
    }


    //method used by Animator to set speed
    private void SetSpeed(float value)
    {
        currentMoveSpeed = value;
    }
    //method used by Animator to set speed
    private void ResetSpeed()
    {
        currentMoveSpeed = moveSpeed;
    }
    //method used by Animator to reset AttackCollider rotation after attack is finished
    void ResetRotation()
    {
        attackColliderTransform.transform.rotation = Quaternion.identity;
    }

    private void PlayDeathSound()
    {
        myAudioSource.PlayOneShot(sfxDeathFall);
    }

    private void PlaySwingSound()
    {
        myAudioSource.PlayOneShot(sfxSwing);
    }

    //method to move the corpse to the Clutter layer
    private void onDeathLayerSwitch()
    {
        gameObject.layer = 10;
    }

}
