using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkController : MonoBehaviour
{
    /// <summary>
    /// 誰が話しているかの話者を指定するEnum
    /// 
    /// </summary>
    /// 
    public enum Talker
    {
        Enemy,  //敵;
        Player, //プレイヤー;
        Buddy,  //相棒;
    }

    /// <summary>
    /// Talkデータを持つ構造体
    /// </summary>
    public struct TalkStruct
    {
        public int id;
        public Talker talker;
        public string contents;

        public TalkStruct(int id, Talker talker, string contents)
        {
            this.id = id;
            this.talker = talker;
            this.contents = contents;
        }
    }

    /// <summary>
    /// TalkStruct型のListを定義する
    /// </summary>
    

    // Start is called before the first frame update
    public void Start()
    {
        List<TalkStruct> talkList = new List<TalkStruct>();
        talkList.Add(new TalkStruct(1, Talker.Player, "おはよう"));
        talkList.Add(new TalkStruct(2, Talker.Buddy, "今日もいい天気だね"));
        talkList.Add(new TalkStruct(3, Talker.Player, "待って、あそこに何かいる"));
        talkList.Add(new TalkStruct(4, Talker.Enemy, "がおー"));
        talkList.Add(new TalkStruct(5, Talker.Buddy, "うわ！ゴブリンが出てきた！"));


        foreach(TalkStruct element in talkList)
        {
            Debug.Log("Talker:" + element.talker + ", Contents:" + element.contents);
        }
    }


}
