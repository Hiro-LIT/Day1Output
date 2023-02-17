using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Character
{

    CharactorType type = CharactorType.Enemy;

    // HPを表示させるスライダー
    [SerializeField]
    Slider hpSlider;
    // 攻撃した際に発射されるGameObject
    [SerializeField]
    GameObject fireBallBullet;
    // 死亡した際に表示するテキスト
    [SerializeField]
    GameObject deadText;

    float Cycle = 3;
    //float dt = 0.0f;
    protected int damage;//Goblinクラスのためにここで宣言(protected←とくに意図なし)

    //bool life = true;
    CharactorState state = CharactorState.Alive;

    private void Start()
    {
        Maxhp = hp;
        hpSlider.maxValue = 1;

        
    }

    private void Update()
    {
        Vector3 tmp = GameObject.Find("Player").transform.position;
        if(tmp == null)
        {
            Debug.Log("no player");
        }

        Edt += Time.deltaTime;
        if(Edt > Cycle)
        {
            Attack();

            Edt = 0.0f;
        }

        LookYAxis(tmp);
    }
    public override void Attack()
    {
        //if(life == true)
        if(state == CharactorState.Alive)
        {
            Instantiate(fireBallBullet, this.transform.position, transform.rotation);
        }
        
    }

    public override void Damage()
    {   
        damage = 10;
        hp -= damage;

        Supdate();

        if (hp <= 0)
        {
            CharaDead();
        }
        
    }

    public void Supdate()
    {
        hpSlider.value = (float)hp / (float)Maxhp;
    }

    public override void CharaDead()
    {
        deadText.gameObject.SetActive(true);
        hpSlider.gameObject.SetActive(false);
        //life = false;
        state = CharactorState.Dead;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("a");
        if (other.gameObject.tag == "PlayerBullet")
        {
            //Debug.Log("b");
            other.gameObject.SetActive(false);
            Damage();          
        }
    }


}