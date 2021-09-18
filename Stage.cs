using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    //自動生成するオブジェクト同士のz軸の差
    const int StageTipSize = 300;
   
    int currentTipIndex;
  
    public Transform character;
    //ステージチップの配列
    public GameObject[] stageTips;
    //自動生成する時に使う変数startTipIndex
    public int startTipIndex;
    //ステージ生成の先読み個数
    public int preInstantiate;
    //作ったステージチップの保持リスト
    public List<GameObject> generatedStageList = new List<GameObject>();

    void Start()
    {
        //初期化処理　
        currentTipIndex = startTipIndex - 1;
        UpdateStage(preInstantiate);
        
    }

    

    void Update()
    {
        //キャラクターの位置から現在のステージチップのインデックスを計算　
        int charaPositionIndex = (int)(character.position.z / StageTipSize);
        //次のステージチップに入ったらステージの更新処理　
        if (character.position != null && charaPositionIndex + preInstantiate > currentTipIndex)
        {
            UpdateStage(charaPositionIndex + preInstantiate);
        }

        
    }

        void UpdateStage(int toTipIndex)
        {
            if (toTipIndex <= currentTipIndex) return;
            //指定のステージチップまで生成
            for (int i = currentTipIndex + 1; i <= toTipIndex; i++)
            {
                GameObject stageObject = GenerateStage(i);
                //生成したステージチップを管理リストに追加
                generatedStageList.Add(stageObject);
            }
            //ステージ保持上限になるまで古いステージを削除
            while (generatedStageList.Count > preInstantiate + 2) DestroyOldestStage();

            currentTipIndex = toTipIndex;
        }
        GameObject GenerateStage(int tipIndex)　//新たに生成するステージと、既存のステージの一番最後を繋げるため場所をずらす
        {
            int nextStageTip = Random.Range(0, stageTips.Length);

            GameObject stageObject = (GameObject)Instantiate(
                stageTips[nextStageTip],
                new Vector3(0, 0, tipIndex * StageTipSize),
                Quaternion.identity);
            return stageObject;
        }
        //一番古いステージを削除
        void DestroyOldestStage()
        {
            GameObject oldStage = generatedStageList[0];
            generatedStageList.RemoveAt(0);
            Destroy(oldStage);
        }
   

    
}
