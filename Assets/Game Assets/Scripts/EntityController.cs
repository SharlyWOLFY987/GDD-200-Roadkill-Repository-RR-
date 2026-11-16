using UnityEngine;
using System.Collections;

public class EntityController : MonoBehaviour
{
    // variables for moving, rotation, and moving to player speed
    public float moveSpeed;
    public float moveToPlayerSpeed;
    public float lookRotationSpeed;
    //transform that entity moves towards 
    public Transform Player;

    //transform that entity rotate towards 
    public Transform lookPlayer;

    Vector3 targetPosition;
    public float range;
    public bool isWaiting;
    public bool isLookingAtPlayer;
    public GameObject entityTest;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        setNewTarget();
        isLookingAtPlayer = false;
    }

    void Update()
    {
        randomMovement();
        lookingAtPlayer();
    }

    //creates a new vector for the entity to move towards
    void setNewTarget()
    {
        Vector3 RandomPosition = new Vector3(Random.Range(-range, range), 0f, Random.Range(-range, range));
        targetPosition = transform.position + RandomPosition;
    }

    // stop the entity from moving for some seconds then generates a new random position to move.
    IEnumerator startMoving()
    {
        isWaiting = true;
        yield return new WaitForSeconds(3);
        setNewTarget();
        isWaiting = false;
    }

    void randomMovement()
    {
        //checking if object is not looking at player 
        if (isLookingAtPlayer == false)
        {
            // if isWaiting is true then it exits the function
            if (isWaiting)
            {
                return;
            }

            // moves the eneity from the current position of entity to the random position plus some moveSpeed
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // checks if entity has reached the desired position
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
               
                StartCoroutine(startMoving());
            }
        }
    }

    // function for object rotating towards the player
    void lookingAtPlayer()
    {
        if (Input.GetKeyDown(KeyCode.T))
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
            if(lookDirection != Vector3.zero)
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
            entityTest.SetActive(true);
        }
    }



}
