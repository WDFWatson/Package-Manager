using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public List<int> contents = new List<int>();

    [SerializeField] private float boundaryDistanceX;
    [SerializeField] private float boundaryDistanceY;
    public Rigidbody2D rb;
    public Camera cam;
    public bool isGrabbed = false;

    private void Awake()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }

        if (cam == null)
        {
            cam = FindObjectOfType<Camera>();
        }
    }

    private Vector2 targetPosition;
    // Update is called once per frame
    void Update()
    {
        targetPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        
        float angle = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        Vector2 diff = targetPosition - (Vector2)transform.position;
        Vector2 rotatedX = new Vector2(Mathf.Cos(angle), MathF.Sin(angle));
        Vector2 rotatedY = new Vector2(-Mathf.Sin(angle), MathF.Cos(angle));
        bool inBoundsX = boundaryDistanceX > Mathf.Abs(Vector2.Dot(diff,rotatedX));
        bool inBoundsY = boundaryDistanceY > Mathf.Abs(Vector2.Dot(diff, rotatedY));
        
        if (inBoundsX && inBoundsY && Input.GetButtonDown("Fire1"))
        {
            isGrabbed = true;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        if (isGrabbed && Input.GetButtonUp("Fire1"))
        {
            isGrabbed = false;
            rb.constraints = RigidbodyConstraints2D.None;
            rb.angularVelocity = 0;
        }
    }
    private void FixedUpdate()
    {
        if (isGrabbed)
        {
            rb.MovePosition(targetPosition);
        }
    }

    public List<Vector2> GetSpawnPositions(int rows, int columns)
    {
        var spawnPositions = new List<Vector2>();
        float xUnit = (boundaryDistanceX * 2) / columns;
        float yUnit = (boundaryDistanceY * 2) / rows;
        Vector2 initialPosition = new Vector2(transform.position.x - boundaryDistanceX + 0.5f * xUnit, transform.position.y - boundaryDistanceY + 0.5f * yUnit);
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                spawnPositions.Add(new Vector2(initialPosition.x + x*xUnit,initialPosition.y + y*yUnit));
            }
        }

        return spawnPositions;
    }

}
