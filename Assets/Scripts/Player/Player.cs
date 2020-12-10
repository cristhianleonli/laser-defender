using System.Collections;
using DG.Tweening;
using UnityEngine;
using Utils;

public enum ObjectTag
{
    PowerUpShield
}

public class Player : MonoBehaviour
{
    #region Player Movement
    private float playerSpeed = 10f;
    private float xPadding = 1f;
    private float yPadding = 1f;
    private int health = 200;
    #endregion

    #region Player rotation
    private float currentAngle = 0;
    private bool hasShield = false;
    #endregion

    #region Jets
    [SerializeField] private PlayerJet leftJet;
    [SerializeField] private PlayerJet rightJet;
    [SerializeField] private SpriteRenderer shield;
    #endregion

    #region Projectile
    private float projectileSpeed = 1f;
    private float projectileFiringPeriod = 0.2f;
    [SerializeField] private PlayerLaser laserPrefab;
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
        SetupObjects();
    }

    private void Update()
    {
        Rotate();
        Move();
        Fire();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag($"{ObjectTag.PowerUpShield}"))
        {
            AddShield();
        }

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

        if (deltaX == 0 && deltaY == 0)
        {
            rightJet.FadeOut();
            leftJet.FadeOut();
        } else
        {
            rightJet.FadeIn();
            leftJet.FadeIn();
        }

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
            PlayerLaser laser = Instantiate(laserPrefab, firePoint.position, transform.rotation);
            var borderPosition = new Vector3(mousePosition.x, mousePosition.y, 0);

            var borderDistance = Geometry.HypotenuseLength(
                borderPosition.y - laser.transform.position.y,
                borderPosition.x - laser.transform.position.x
            );

            var animationDuration = borderDistance * projectileSpeed / (maxX - minX);
            AudioManager.Instance.PlayerPlayerLaser();
            laser.transform
                .DOMove(borderPosition, animationDuration)
                .OnComplete(() => laser.StopFlying());

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
        var rotationAngle = Geometry.RotationAngle(mousePosition, transform.position);
        currentAngle = rotationAngle;
        transform.eulerAngles = new Vector3(0, 0, rotationAngle - 90);
    }

    private void SetupObjects()
    {
        shield.DOFade(0, 0);
    }

    private void AddShield()
    {
        shield.DOFade(1, 0.2f);
        hasShield = true;
    }

    private void RemoveShield()
    {
        shield.DOFade(0, 0f);
        hasShield = false;
    }
}