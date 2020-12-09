using System.Collections;
using DG.Tweening;
using UnityEngine;
using Utils;

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
    #endregion

    #region Projectile
    private float projectileSpeed = 1f;
    private float projectileFiringPeriod = 0.2f;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private Transform firePoint;
    #endregion

    private Camera gameCamera;
    private Coroutine firingCoroutine;

    private Vector3 mousePosition => Coordinates.GetMouseWorldPosition(gameCamera);

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
            GameObject laser = Instantiate(laserPrefab, firePoint.position, transform.rotation) as GameObject;
            var borderPosition = ProjectPositionToBorder(firePoint.position, mousePosition);

            var borderDistance = Geometry.HypotenuseLength(
                borderPosition.y - laser.transform.position.y,
                borderPosition.x - laser.transform.position.x
            );

            var animationDuration = borderDistance * projectileSpeed / (maxX - minX);

            laser.transform.DOMove(borderPosition, animationDuration);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }

    private Vector3 ProjectPositionToBorder(Vector3 origin, Vector3 direction)
    {
        int layer_mask = LayerMask.GetMask("Shredder");

        var raycast = Physics2D.Raycast(
            new Vector2(origin.x, origin.y),
            new Vector2(direction.x, direction.y), 50, layer_mask
        );

        Debug.DrawRay(origin, direction, Color.red, 3);
        //Debug.Log(raycast.point);
        return new Vector3(raycast.point.x, raycast.point.y, 0);
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
        var rotationAngle = Geometry.RotationAngle(mousePosition, transform.position);
        currentAngle = rotationAngle;
        transform.eulerAngles = new Vector3(0, 0, rotationAngle - 90);
    }
}
