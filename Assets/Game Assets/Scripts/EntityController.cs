using UnityEngine;
using System.Collections;

public class EntityController : MonoBehaviour
{
    // variables for moving, rotation, and moving to player speed
    public float moveSpeed;
    public float moveToPlayerSpeed;
    public float lookRotationSpeed;
    public float rotationSpeed;
    //transform that entity moves towards 
    public Transform Player;

    //transform that entity rotate towards 
    public Transform lookPlayer;

    public bool isWaiting;
    public bool isLookingAtPlayer;
    public GameObject entityTest;

    // all the transforms where the player will move towards
    public Transform locationOne;
    public Transform locationTwo;
    public Transform locationThree;

    // all the transforms where the player will be rotating
    public Transform locationOneBody;
    public Transform locationTwoBody;
    public Transform locationThreeBody;

    public bool isMoving;
    public bool moveToLocationOne;
    public bool moveToLocationTwo;
    public bool moveToLocationThree;

    [Header("Behaviors")]
    public bool isTriggered;
    public bool isFleeing;
    public GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isMoving = true;
        moveToLocationOne = true;
        isLookingAtPlayer = false;
    }

    void Update()
    {
        EntityMovement();
        lookingAtPlayer();
    }



    void EntityMovement()
    {
        // checks if a player is looking towards a player
        if (isLookingAtPlayer == false)
        {
            // checks if the player is moving
            if (isMoving == true)
            {
                //checks if player is moving to the location one
                if (moveToLocationOne == true)
                {
                    //rotation mechanics
                    Vector3 locationOneDirection = locationOneBody.position - transform.position;
                    if (locationOneDirection != Vector3.zero)
                    {
                        Quaternion targetRotation = Quaternion.LookRotation(locationOneDirection);
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                    }

                    //moving mechanics
                    transform.position = Vector3.MoveTowards(transform.position, locationOne.position, moveSpeed * Time.deltaTime);
                    if (Vector3.Distance(transform.position, locationOne.position) < 0.1f)
                    {
                        StartCoroutine(moveRoutine());
                        moveToLocationOne = false;
                        moveToLocationTwo = true;
                    }
                }

                if (moveToLocationTwo == true)
                {
                    Vector3 locationTwoDirection = locationTwoBody.position - transform.position;

                    if (locationTwoDirection != Vector3.zero)
                    {
                        Quaternion targetRotation = Quaternion.LookRotation(locationTwoDirection);
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                    }

                    transform.position = Vector3.MoveTowards(transform.position, locationTwo.position, moveSpeed * Time.deltaTime);
                    if (Vector3.Distance(transform.position, locationTwo.position) < 0.1f)
                    {
                        StartCoroutine(moveRoutine());
                        moveToLocationThree = true;
                        moveToLocationTwo = false;
                    }
                }

                if (moveToLocationThree == true)
                {
                    Vector3 locationThreeDirection = locationThreeBody.position - transform.position;

                    if (locationThreeDirection != Vector3.zero)
                    {
                        Quaternion targetRotation = Quaternion.LookRotation(locationThreeDirection);
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                    }

                    transform.position = Vector3.MoveTowards(transform.position, locationThree.position, moveSpeed * Time.deltaTime);
                    if (Vector3.Distance(transform.position, locationThree.position) < 0.1f)
                    {
                        StartCoroutine(moveRoutine());
                        moveToLocationThree = false;
                        moveToLocationOne = true;

                    }
                }
            }

        }
    }



    // function for object rotating towards the player
    void lookingAtPlayer()
    {
        if (isTriggered) // - Chuck: if the player takes ANY photo while it's spawned in
        {
            isLookingAtPlayer = !isLookingAtPlayer;
        }
        if (isLookingAtPlayer)
        {
            // creates a vector three and is equal to the player position
            Vector3 targetPosition = Player.position;

            // setting the targetposition to the entity Y position which is zero
            targetPosition.y = transform.position.y;

            // moves the entity towards the player
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveToPlayerSpeed * Time.deltaTime);
            //calculates the direction between the current position and the position of the player.
            Vector3 lookDirection = lookPlayer.position - transform.position;

            // checks if the direction is not zero
            if (lookDirection != Vector3.zero)
            {
                // calculates the roatation of the entity and the player.
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lookDirection), lookRotationSpeed * Time.deltaTime);
            }
        }
    }


    // checks if entity has entered a collider
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerCollide"))
        {
            //entityTest.SetActive(true);
            gameManager.carDamage++;
        }
    }

    IEnumerator moveRoutine()
    {
        isMoving = false;
        yield return new WaitForSeconds(5);
        isMoving = true;
    }
}
