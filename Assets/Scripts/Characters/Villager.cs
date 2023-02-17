using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : Character
{
    CharactorType type = CharactorType.Villager;

    // 生成するダイアログに当たるゲームオブジェクト
    [SerializeField]
    GameObject dialogObject;
    // ダイアログを生成するHierarchy上で親関係となるゲームオブジェクト
    [SerializeField]
    Transform canvas;

    CharactorState state = CharactorState.Alive;

    //float Vdt;

    private void Start()
    {

    }

    private void Update()
    {
        Vector3 tmp = GameObject.Find("Player").transform.position;
        if (tmp == null)
        {
            Debug.Log("no player");
        }
        LookYAxis(tmp);
    }

    public override void Attack()
    {

    }

    public override void Damage()
    {
        DisplayDialog();
    }

    public override void CharaDead()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyBullet"|| other.gameObject.tag == "PlayerBullet")
        {
            other.gameObject.SetActive(false);
            Damage();
        }
    }

    void DisplayDialog()
    {
        SetDialog("oh", "Villager");
       // StartCoroutine("UnDisplay");

    }


    //コルーチンは、僕の頑張りの思い出です、もっと早くDestroyのリファレンス見るべきだった
    //IEnumerator UnDisplay()
    //{
    //    var dialog1 = GameObject.Find("Dialog");
    //    yield return new WaitForSeconds(3.0f);
    //    //dialog1.gameObject.SetActive(false);
    //    Destroy(dialog1);
    //}


    // ダメージを受けた際の実装例
    /*void ダメージを受けた！()
    {
        SetDialog("表示するテキスト","誰が話しているか");
    }*/

    /// <summary>
    /// ダイヤログへ文字を表示させる処理
    /// </summary>
    /// <param name="content">表示させる内容</param>
    /// <param name="talker">話者</param>
    private void SetDialog(string content, string talker)
    {
        // ダイアログを生成させる
        var dialog = Instantiate(dialogObject, canvas);
        // Dialogクラスを呼び出し、表示処理を実行する
        dialog.GetComponent<Dialog>().DisplayDialog(content, talker);
        Destroy(dialog, 3);
    }
}
