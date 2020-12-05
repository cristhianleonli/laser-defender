using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Player : MonoBehaviour
{

    [SerializeField] private float playerSpeed = 10f;
    [SerializeField] float xPadding = 1f;
    [SerializeField] float yPadding = 1f;

    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    private void Start()
    {
        SetupMoveBoundaries();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed;

        var newXPosition = Mathf.Clamp(transform.position.x + deltaX, minX, maxX);
        var newYPosition = Mathf.Clamp(transform.position.y + deltaY, minY, maxY);

        transform.position = new Vector2(newXPosition, newYPosition);
    }

    private void SetupMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        minX = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + xPadding;
        maxX = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - xPadding;

        minY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + yPadding;
        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - yPadding;
    }
}
