using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Tilemaps;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float hSpeed = 10f;
    [SerializeField] private float vSpeed = 6f;
    private new Rigidbody2D rigidbody2D;
    [SerializeField] private bool canMove;

    public static CharacterMovement instance;

    public Animator animator;


    private bool facingRight = true;

    [Range(0, 1.0f)]
    [SerializeField] float movementSmooth = 0.5f;
    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

                if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void Move(float hMove, float vMove, bool jump)
    {
        if (canMove)
        {
            Vector3 targetVelocity = new Vector2(hMove * hSpeed, vMove * vSpeed);

            rigidbody2D.velocity = Vector3.SmoothDamp(rigidbody2D.velocity, targetVelocity, ref velocity, movementSmooth);

            if (targetVelocity.magnitude > 1f){
                
                targetVelocity.Normalize();
                
                }

            if (hMove > 0 && !facingRight)
            {
                flip();
            }else if (hMove < 0 && facingRight)
            {
                flip();
            }
        }
    }

    private void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0,180,0);
    }

        // Method to enable player input
    public void EnableMovement()
    {
        canMove = true;
    }

    // Method to disable player input
    public void DisableMovement()
    {
        canMove = false;
        rigidbody2D.velocity = Vector2.zero;
    }

        private void CheckMovement()
    {
        // Check if the character is moving by comparing its current velocity to nearly zero
        bool isCurrentlyMoving = rigidbody2D.velocity.sqrMagnitude > 0.001f;
        
        // Set the Animator's isMoving parameter
        if (animator != null)
        {
            animator.SetBool("isMoving", isCurrentlyMoving);
        }
    }

    // Method to move the character to the right for a set distance
    private const float PixelsPerUnit = 100f;

    public IEnumerator MoveRight(float distanceInPixels, float durationInSeconds)
    {
        DisableMovement();

        float distanceInUnits = distanceInPixels / PixelsPerUnit;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = startPosition + Vector3.right * distanceInUnits;
        float elapsedTime = 0;

        while (elapsedTime < durationInSeconds)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / durationInSeconds);
            elapsedTime += Time.deltaTime;
            
            if (animator != null)
            {
                animator.SetBool("isMoving", true);
            }
            yield return null;
        }
        

        transform.position = endPosition; // Ensure it ends exactly at the endPosition
        if (animator != null)
        {
            animator.SetBool("isMoving", false);
        }
        
    }

    public void addSpeed(float speedPercent){
        hSpeed = hSpeed * speedPercent;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        CheckMovement();
        animator.SetFloat("speed", hSpeed);
    }
}
