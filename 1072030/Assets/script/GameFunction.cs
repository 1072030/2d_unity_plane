using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
public class GameFunction : MonoBehaviour
{
    public GameObject Emeny;
    public GameObject Emeny2;
    public GameObject Boss;
    public GameObject Warning;
    public GameObject Teach;
    public Text ScoreText;
    public Text YourScore;
    public int Score = 0;
    private int Score_shoot = 50;
    private int Score_boss = 500;
    public static GameFunction Instance;
    public float time;
    public float time2;
    public float time_end;

    public GameObject GameTitle; //宣告GameTitle物件
    public GameObject GameOverTitle; //宣告GameOverTitle物件
    public GameObject YouWinTitle;
    public GameObject YouScoreTitle;
    public GameObject PlayButton; //宣告PlayButton物件
    public bool IsPlaying = false; // 宣告IsPlaying 的布林資料，並設定初始值false
    private bool IsBoss = true;

    public GameObject RestartButton; //宣告RestartButto的物件
    public GameObject QuitButton; //宣告QuitButton的物件

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        GameOverTitle.SetActive(false);
        RestartButton.SetActive(false);
        YouScoreTitle.SetActive(false);
        YouWinTitle.SetActive(false);
        Warning.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(IsPlaying == true){
            time_end += Time.deltaTime;
            if(time_end < 40f)
            {
                time += Time.deltaTime; //時間增加
                if (time > 0.5f && IsPlaying == true) //如果時間大於0.5(秒)
                {
                    Vector3 pos = new Vector3(Random.Range(-2.5f, 2.5f), 4.5f, 0); //宣告位置pos，Random.Range(-2.5f,2.5f)代表X是2.5到-2.5之間隨機
                    Instantiate(Emeny, pos, transform.rotation); //產生敵人
                    time = 0f; //時間歸零
                }
                time2 += Time.deltaTime;
                if (time2 > 1.5f && IsPlaying == true) //如果時間大於0.5(秒)
                {
                    Vector3 pos2 = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(1.5f, 3f), 0); //宣告位置pos，Random.Range(-2.5f,2.5f)代表X是2.5到-2.5之間隨機
                    Instantiate(Emeny2, pos2, transform.rotation); //產生敵人
                    time2 = 0f;
                }
            }
        }
        if(time_end > 40 && time_end < 44)
        {
            Warning.SetActive(true);
        }
        else
        {
            Warning.SetActive(false);
        }
        if (time_end>45f && IsPlaying == true) //如果時間大於45(秒)
        {
            if (IsBoss == true)
            {
                Vector3 pos3 = new Vector3(0f, 5f, 0f);
                Instantiate(Boss, pos3, transform.rotation);
            }
            IsBoss = false;
        }
    }

    public void AddScore()
    {
        Score += 10;
        ScoreText.text = "Score:" + Score;
        YourScore.text = "Your Score:" + Score;
    }
    public void PlusScore()
    {
        Score += Score_shoot;
        ScoreText.text = "Score:" + Score;
        YourScore.text = "Your Score:" + Score;
    }
    public void BossScore()
    {
        Score += Score_boss;
        ScoreText.text = "Score:" + Score;
        YourScore.text = "Your Score:" + Score;
    }
    public void GameStart()
    {
        IsPlaying = true; //設定IsPlaying為true，代表遊戲正在進行中
        GameTitle.SetActive(false); //不顯示GameTitle
        PlayButton.SetActive(false); //不顯示PlayButton
        QuitButton.SetActive(false); //QuitButton設定成不顯示
        Teach.SetActive(false);
    }
    public void GameOver() //GameOver的Function
    {
        IsPlaying = false; //IsPlaying設定成false，停止產生外星人
        GameOverTitle.SetActive(true); //GameOverTitle設定為ture
        RestartButton.SetActive(true); //RestartButton設定成不顯示
        QuitButton.SetActive(true); //QuitButton設定成不顯示
        time_end = 0;
    }
    public void Win()
    {
        IsPlaying = false;
        GameOverTitle.SetActive(false);
        YouWinTitle.SetActive(true);
        YouScoreTitle.SetActive(true);
        RestartButton.SetActive(true);
        QuitButton.SetActive(true);
        
    }
    public void ResetGame() //RestartButton的功能
    {
        Application.LoadLevel(Application.loadedLevel); //讀取關卡(已讀取的關卡
    }
    public void QuitGame() //QuitButton的功
    {
        Application.Quit(); //離開應用程式
    }

}
