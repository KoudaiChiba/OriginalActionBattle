using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    // ゲームオーバテキスト
    public GameObject gameOverText;

    // 走行距離テキスト
    public GameObject runLengthText;

    // 走った距離
    private float len = 0;

    // 走る速度
    private float speed = 0.03f;

    // ゲームオーバの判定
    private bool isGameOver = false;

    public GameObject hpFill;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // シーンビューからオブジェクトの実体を検索する
        this.gameOverText = GameObject.Find("GameOver");
        this.runLengthText = GameObject.Find("RunLength");
        this.hpFill = GameObject.Find("HpFill");
        this.player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isGameOver == false)
        {
            // 走った距離を更新する
            this.len += this.speed;

            // 走った距離を表示する
            this.runLengthText.GetComponent<Text>().text = "Distance:  " + len.ToString("F2") + "m";
        }

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
}
