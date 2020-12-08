using System.Collections;
using AOT;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Player Movement
    private float playerSpeed = 10f;
    private float xPadding = 1f;
    private float yPadding = 1f;
    private int health = 200;
    #endregion

    #region Player rotation
    private float currentAngle;
    private Vector3 currentMousePosition;
    #endregion

    #region Projectile
    private float projectileSpeed = 20f;
    private float projectileFiringPeriod = 0.2f;
    [SerializeField] private GameObject laserPrefab;
    #endregion

    private Camera gameCamera;
    private Coroutine firingCoroutine;

    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    private void Start()
    {
        gameCamera = Camera.main;
        SetupMoveBoundaries();
    }

    private void Update()
    {
        Rotate();
        Move();
        Fire();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; };
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed;

        var newXPosition = Mathf.Clamp(transform.position.x + deltaX, minX, maxX);
        var newYPosition = Mathf.Clamp(transform.position.y + deltaY, minY, maxY);

        transform.position = new Vector2(newXPosition, newYPosition);
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinuosly());
        }

        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    private IEnumerator FireContinuosly()
    {
        while (true)
        {
            GameObject laser = Instantiate(laserPrefab, transform.position, transform.rotation) as GameObject;

            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(
                currentMousePosition.x,
                currentMousePosition.y
            );

            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }

    private void SetupMoveBoundaries()
    {
        minX = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + xPadding;
        maxX = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - xPadding;

        minY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + yPadding;
        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - yPadding;
    }

    private void Rotate()
    {
        var newTransform = transform.position;
        var mousePosition = gameCamera.ScreenToWorldPoint(Input.mousePosition);

        currentMousePosition = mousePosition;

        Vector2 vec1 = new Vector2(newTransform.x, newTransform.y);
        Vector2 vec2 = new Vector2(mousePosition.x, mousePosition.y);

        Vector2 diference = vec2 - vec1;
        float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
        var rotationAngle = Vector2.Angle(Vector2.right, diference) * sign;

        transform.localEulerAngles = new Vector3(0, 0, rotationAngle - 90);
    }
}
