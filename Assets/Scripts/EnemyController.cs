using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int id;
    public Transform goal;
    public float moveSpeed = 1.4f;

    private bool triggered = false;
    private Vector2 movement;
    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody2D>();
        boxCollider2D = this.GetComponent<BoxCollider2D>();
        GameEvents.current.onGemColisionEnter += OnGemCollected;
        GameEvents.current.onGemDrop += onGemDropped;
    }

    private void Update()
    {
        Vector2 direction = goal.position - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //rb.rotation = angle;
        direction.Normalize();
        movement = direction;

        rigidBody.isKinematic = !triggered;
        boxCollider2D.enabled = triggered;
    }
    private void FixedUpdate()
    {
        if (triggered)
        {
            moveEnemy(movement);
        }
    }

    private void OnGemCollected(int id)
    {
        if (id == this.id)
        {
            triggered = true;
        }
    }

    private void onGemDropped(int id)
    {
        if (id == this.id)
        {
            triggered = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameEvents.current.GemDropped(this.id);
            // TODO :: readjust
        }
    }

    private void moveEnemy(Vector2 direction)
    {
        rigidBody.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.fixedDeltaTime));
    }
}
