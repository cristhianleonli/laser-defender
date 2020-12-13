using System.Collections;
using DG.Tweening;
using UnityEngine;
using Utils;
using Constants;

public class Player : MonoBehaviour
{
    #region Player Movement
    private float playerSpeed = 10f;
    private float xPadding = 0.7f;
    private float yPadding = 0.7f;
    #endregion

    #region Health
    private int health;
    private bool hasShield = false;
    private int shieldHitCount = 0;
    private int maxShieldCount = 2;
    private float shieldDuration = 6f;
    public static int MaxHealth = 3;
    #endregion

    #region Add-ons
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
    private float minX, maxX, minY, maxY;
    private Vector3 mousePosition => Coordinates.GetMouseWorldPosition(gameCamera);

    #region events
    public delegate void PlayerAction(int health);
    public static event PlayerAction OnHealthUpdate;
    #endregion

    private void Start()
    {
        gameCamera = Camera.main;
        SetupMoveBoundaries();
        SetUpObjects();
    }

    private void Update()
    {
        Rotate();
        Move();
        Fire();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag($"{Tags.PowerUpShield}"))
        {
            AddShield();
        }

        if (collision.gameObject.CompareTag($"{Tags.PowerUpPill}"))
        {
            HealthDealer healthDealer = collision.gameObject.GetComponent<HealthDealer>();
            IncreaseHealth(healthDealer.GetHealth());
        }

        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if (damageDealer) {
            ProcessHit(damageDealer);
        }
    }

    private void IncreaseHealth(int amount)
    {
        // make sure health doesn't go above the maximum
        health = (health + amount) > MaxHealth ? MaxHealth : (health + amount);
        AudioManager.Instance.PlaySound(SoundType.Pill);
        OnHealthUpdate?.Invoke(health);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        CameraShake.Instance.ShakeCamera(5f, 0.1f);
        
        if (hasShield)
        {
            shieldHitCount -= 1;

            if (shieldHitCount <= 0)
            {
                RemoveShield();
            }

            AudioManager.Instance.PlaySound(SoundType.HurtShield);
        } else
        {
            AudioManager.Instance.PlaySound(SoundType.Hurt);
            health -= damageDealer.GetDamage();
            if (health <= 0)
            {
                // TODO: Present finish screen and proper animations
                OnHealthUpdate?.Invoke(0);
                Destroy(this.gameObject);
                return;
            }
        }

        OnHealthUpdate?.Invoke(health);
        damageDealer.Hit();
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
            // create player laser
            PlayerLaser laser = Instantiate(laserPrefab, firePoint.position, transform.rotation);
            var borderPosition = new Vector3(mousePosition.x, mousePosition.y, 0);

            // calculate the distance from player to mouse position
            var borderDistance = Geometry.HypotenuseLength(
                borderPosition.y - laser.transform.position.y,
                borderPosition.x - laser.transform.position.x
            );

            // calculate animation duration of laser, from player to mouse position
            var animationDuration = borderDistance * projectileSpeed / (maxX - minX);
            AudioManager.Instance.PlaySound(SoundType.PlayerLaser);

            // animate
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
        transform.eulerAngles = new Vector3(0, 0, rotationAngle - 90);
    }

    private void SetUpObjects()
    {
        shield.DOFade(0, 0);
        health = MaxHealth;
        OnHealthUpdate?.Invoke(health);
    }

    private void AddShield()
    {
        if (hasShield) { return; }

        // make shield visible
        shield.DOFade(1, 0.2f);
        hasShield = true;

        // restore shield hit count to max
        shieldHitCount = maxShieldCount;
        AudioManager.Instance.PlaySound(SoundType.AddShield);

        StartCoroutine(ShieldTimeout());
    }

    private void RemoveShield()
    {
        if (!hasShield) { return; }

        shield.DOFade(0, 0f);
        hasShield = false;
        shieldHitCount = maxShieldCount;
        AudioManager.Instance.PlaySound(SoundType.RemoveShield);
    }

    private IEnumerator ShieldTimeout()
    {
        yield return new WaitForSeconds(shieldDuration);
        RemoveShield();
    }
}