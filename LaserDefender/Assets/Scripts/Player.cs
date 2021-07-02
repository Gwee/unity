using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float boundaryPadding = 1f;
    [SerializeField] GameObject playerProjectile;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.1f;
    private const string HorizonalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";
    private const string Fire1Axis = "Fire1";
    private float minXBoundary;
    private float minYBoundary;
    private float maxXBoundary;
    private float maxYBoundary;
    private Coroutine firingCoroutine;


    // Start is called before the first frame update
    void Start()
    {
        SetupMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    private void Fire() {
        if (Input.GetButtonDown(Fire1Axis)) {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp(Fire1Axis)) {
            StopCoroutine(firingCoroutine);
        }
    }

    private IEnumerator FireContinuously() {
        while(true) {
            GameObject playerProjectile = Instantiate(this.playerProjectile,
            transform.position, Quaternion.identity);

            playerProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }

    private void SetupMoveBoundaries() {
        Camera gameCamera = Camera.main;
        this.minXBoundary = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + boundaryPadding;
        this.maxXBoundary = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - boundaryPadding;
        this.minYBoundary = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + boundaryPadding;
        this.maxYBoundary = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - boundaryPadding;
    }

    private void Move() {
        transform.position = getMovePosition();
    }

    private Vector2 getMovePosition() {
        float deltaX = Input.GetAxis(HorizonalAxis) * Time.deltaTime * movementSpeed;
        float deltaY = Input.GetAxis(VerticalAxis) * Time.deltaTime * movementSpeed;
        
        float boundedX = Mathf.Clamp(transform.position.x + deltaX, minXBoundary, maxXBoundary);
        float boundedY = Mathf.Clamp(transform.position.y + deltaY, minYBoundary, maxYBoundary);
        return new Vector2(boundedX, boundedY);
    }
}
