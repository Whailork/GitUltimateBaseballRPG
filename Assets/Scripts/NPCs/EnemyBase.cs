using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class EnemyBase
{
    protected EnemyController enemy;

    protected int hpMax;
    protected int hp;

    public void SetEnemyController(EnemyController c)
    {

        enemy = c;

    }

    protected void SetHP(int max)
    {

        hpMax = max;
        hp = max;

    }

    public abstract void Start(Rigidbody2D rb);
    
    public abstract void UpdateMovement(Rigidbody2D rb);

    public virtual void TakeDamage(int damage, Collision2D col)
    {

        Debug.Log($"TAKE DMG {damage}");
        hp -= damage;
        if (hp <= 0) Die(col);

    }

    protected virtual void Die(Collision2D col)
    {
        
        MonoBehaviour.Destroy(enemy.gameObject);
        
    }

}
