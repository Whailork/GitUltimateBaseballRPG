using System;
using System.Collections;
using System.Collections.Generic;
using Singletons;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class YankeeController : EnemyBase
{

    private float moveSpeed;
    private Rigidbody2D rb;

    public YankeeController(float speed)
    {

        moveSpeed = speed;
        SetHP(100);

    }

    public override void Start(Rigidbody2D rb)
    {
        this.rb = rb;
        enemy.StartCoroutine(MovementCoroutine(rb));
        
    }

    protected override void Die(Collision2D col)
    {

        GameValues.GetGameValues().Cash += 10;
        enemy.StopAllCoroutines();
        rb.freezeRotation = false;
        rb.mass = 5;
        rb.AddForceAtPosition(-col.relativeVelocity, col.GetContact(0).point, ForceMode2D.Impulse);
        DeleteAfterX d = enemy.AddComponent<DeleteAfterX>();
        d.deleteAfter = 2;

    }

    public override void UpdateMovement(Rigidbody2D rb) { }

    IEnumerator MovementCoroutine(Rigidbody2D rb)
    {

        while (true)
        {
            
            float timeChange = Random.Range(1f, 3f);

            Vector2 movement = Vector2.zero;
            movement.x = Random.Range(-1, 2);
            rb.velocity = movement * moveSpeed;
            yield return new WaitForSeconds(timeChange);
            
        }

    }
    
}
