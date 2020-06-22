using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;

    [SerializeField] float randomFactor = 0.2f;

    Vector2 paddleToBallVector;

    bool isBallLaunched;

    [SerializeField] AudioClip[] soundEffects;
    AudioSource audioSource;

    Random random;

    Rigidbody2D rigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        this.audioSource = GetComponent<AudioSource>();
        this.rigidBody2D = GetComponent<Rigidbody2D>();
        paddleToBallVector = this.transform.position -  paddle1.transform.position;
        random = new Random();
    }

    // Update is called once per frame
    void Update()
    {
        LockBallToPaddle();
        LaunchOnMouseClick();
    }
    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        Vector2 velocityTweak = new Vector2(
            Random.Range(0f, this.randomFactor),
            Random.Range(0f, this.randomFactor));

        if (isBallLaunched) {
            int randomNumber = Random.Range(0, soundEffects.Length);
            AudioClip audioClip = this.soundEffects[randomNumber];
            this.audioSource.PlayOneShot(audioClip);
            this.rigidBody2D.velocity += velocityTweak;
        }
    }

    
    private void LockBallToPaddle() {
        if (!isBallLaunched) {
            Vector2 paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
            this.transform.position = paddlePosition + paddleToBallVector;
        }
    }

    private void LaunchOnMouseClick() {
        if (Input.GetMouseButtonDown(0) && !isBallLaunched)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
            isBallLaunched = true;
        }
    }

}
