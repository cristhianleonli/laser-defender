﻿using System.Collections;
using DG.Tweening;
using UnityEngine;
using Utils;

public enum ObjectTag
{
    PowerUpShield,
    Player
}

public class Player : MonoBehaviour
{
    #region Player Movement
    private float playerSpeed = 10f;
    private float xPadding = 1f;
    private float yPadding = 1f;
    private int health = 200;
    #endregion

    #region Shield
    private bool hasShield = false;
    private int shieldHitCount = 0;
    private int maxShieldCount = 2;
    private float shieldDuration = 4f;
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
        if (hasShield)
        {
            shieldHitCount -= 1;

            if (shieldHitCount <= 0)
            {
                RemoveShield();
            }
            AudioManager.Instance.PlayHurtShield();
        } else
        {
            AudioManager.Instance.PlayHurt();
            health -= damageDealer.GetDamage();
            if (health <= 0)
            {
                // TODO: Present finish screen and proper animations
                Destroy(this.gameObject);
                return;
            }
        }

        // TODO: Play hurt animation
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
        transform.eulerAngles = new Vector3(0, 0, rotationAngle - 90);
    }

    private void SetupObjects()
    {
        shield.DOFade(0, 0);
    }

    private void AddShield()
    {
        if (hasShield) { return; }

        shield.DOFade(1, 0.2f);
        hasShield = true;
        shieldHitCount = maxShieldCount;
        AudioManager.Instance.PlayAddShield();

        StartCoroutine(ShieldTimeout());
    }

    private void RemoveShield()
    {
        if (!hasShield) { return; }

        shield.DOFade(0, 0f);
        hasShield = false;
        shieldHitCount = maxShieldCount;
        AudioManager.Instance.PlayRemoveShield();
    }

    private IEnumerator ShieldTimeout()
    {
        yield return new WaitForSeconds(shieldDuration);
        RemoveShield();
    }
}