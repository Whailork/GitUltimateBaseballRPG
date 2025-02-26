using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private EnemyBase controller;

    private Rigidbody2D rb;

    public float moveSpeed;

    public enum EnemyAITypes
    {
        
        Yankee

    }

    public EnemyAITypes enemyType;
    
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        switch (enemyType)
        {
            
            case EnemyAITypes.Yankee:

                controller = new YankeeController(moveSpeed);
                break;
            
        }
        controller.SetEnemyController(this);
        controller.Start(rb);
    }

    public void TakeDamage(int dmg, Collision2D col)
    {
        
        controller.TakeDamage(dmg, col);
        
    }
    
    void FixedUpdate()
    {
        controller.UpdateMovement(rb);
    }
}
