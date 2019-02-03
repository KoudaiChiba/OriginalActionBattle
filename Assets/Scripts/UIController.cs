using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    // ゲームオーバテキスト
    public GameObject gameOverText;

    // ゲームオーバの判定
    private bool isGameOver = false;

    public GameObject hpFill;

    public GameObject player;

    public GameObject timerText;

    public GameObject scoreText;

    private float time = 30.0f;

    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        // シーンビューからオブジェクトの実体を検索する
        this.gameOverText = GameObject.Find("GameOver");
        this.hpFill = GameObject.Find("HpFill");
        this.player = GameObject.Find("Player");
        this.timerText = GameObject.Find("Time");
        this.scoreText = GameObject.Find("Score");
    }

    // Update is called once per frame
    void Update()
    {
        this.time -= Time.deltaTime;
        this.timerText.GetComponent<Text>().text = this.time.ToString("F1");
        if(this.time <= 0)
        {
            this.time = 0;
            GameOver();
        }

        this.scoreText.GetComponent<Text>().text = "Score: " + this.score.ToString();

        // ゲームオーバになった場合
        if (this.isGameOver == true)
        {
            // クリックされたらシーンをロードする（追加）
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //GameSceneを読み込む（追加）
                SceneManager.LoadScene("GameScene");
            }
        }
    }

    public void GameOver()
    {
        // ゲームオーバになったときに、画面上にゲームオーバを表示する
        this.gameOverText.GetComponent<Text>().text = "GameOver";
        this.isGameOver = true;
        Destroy(player.gameObject);
    }

    public void DecreaseHp()
    {
        this.hpFill.GetComponent<Image>().fillAmount -= 0.2f;
        if(hpFill.GetComponent<Image>().fillAmount <= 0.1)
        {
            GameOver();
        }
    }

    public void Skeleton()
    {
        this.score += 10;
    }

    public void ghost()
    {
        this.score += 20;
    }
}
