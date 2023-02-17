using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goblin : Enemy
{

    public override void Damage()
    {
        damage = 5;
        hp -= damage;

        Supdate();

        if (hp <= 0)
        {
            Debug.Log("a");
            CharaDead();
        }

    }
}
