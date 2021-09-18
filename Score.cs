using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public  int number;
    private Text score;
    public Text highScore;
    public GameObject target;
    int second = 1;
    
    
   

     void Awake()
    {
        score = GetComponent<Text>();
        highScore.text = "HighScore:"+PlayerPrefs.GetInt("HighScore", 0).ToString();
        PlayerPrefs.DeleteKey("Score");
    }
   
  

    // Update is called once per frame
    void Update()
    {
        //キャラがdestroyしていない時
        if (target != null)
        {
            number += second;
            
        }
        score.text = "Score:" + this.number;
        //スコアを保存（ゲームオーバー画面で表示するため）
        PlayerPrefs.SetInt("Score", number);

        

        //既存のハイスコアが直前のスコアより小さい場合、ハイスコアを更新して保存
        if (number > PlayerPrefs.GetInt("HighScore", 0)) {
            PlayerPrefs.SetInt("HighScore", number);
        }


      



    }
}
