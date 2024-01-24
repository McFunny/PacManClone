using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1;

    public Direction currentDirection, nextDirection;

    public LayerMask obstacleLayer;

    Vector2 intendedDirection = new Vector2(0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.W)) nextDirection = Direction.Up;
       if (Input.GetKeyDown(KeyCode.S)) nextDirection = Direction.Down;
       if (Input.GetKeyDown(KeyCode.A)) nextDirection = Direction.Left;
       if (Input.GetKeyDown(KeyCode.D)) nextDirection = Direction.Right;
        Move();
        if(currentDirection != nextDirection || nextDirection != Direction.None)
        {
            CheckDirection();
        }
    }

    void Move()
    {
        if(currentDirection == Direction.Up)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
        }
        if(currentDirection == Direction.Down)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
        }
        if(currentDirection == Direction.Left)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
        if(currentDirection == Direction.Right)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        }
    }

    public void CheckDirection()
    {
        if (nextDirection == Direction.Up)
        {
            intendedDirection = Vector3.up;
        }
        if (nextDirection == Direction.Down)
        {
            intendedDirection = Vector3.down;
        }
        if (nextDirection == Direction.Left)
        {
            intendedDirection = Vector3.left;
        }
        if (nextDirection == Direction.Right)
        {
            intendedDirection = Vector3.right;
        }
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.75f, 0.0f, intendedDirection, 1.5f, this.obstacleLayer);
        if (hit.collider == null) currentDirection = nextDirection;
    }

}

public enum Direction 
{
    None,
    Left,
    Right,
    Up,
    Down
}
