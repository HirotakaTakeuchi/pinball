using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {
    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;
    private ScoreText scoreText;
    private Rigidbody rigid;
    // Use this for initialization
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        this.scoreText = GameObject.Find("GameScore").GetComponent<ScoreText>();
        this.rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";

            //Gameoverから復帰
            if (Input.GetKeyUp(KeyCode.Space))
            {
                this.gameoverText.GetComponent<Text>().text = "";
                scoreText.Score = 0;
                this.transform.position = new Vector3(3.01f, 2.8f, 5.32f);
                this.rigid.velocity = Vector3.zero;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "SmallStarTag":
                scoreText.Score += 10;
                break;
            case "LargeStarTag":
                scoreText.Score += 100;
                break;
            case "SmallCloudTag":
                scoreText.Score += 50;
                break;
            case "LargeCloudTag":
                scoreText.Score += 200;
                break;
        }
    }
}
