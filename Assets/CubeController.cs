using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeController : MonoBehaviour
{
    // SE変数の指定
    private AudioSource block01;

    // キューブの移動速度
    private float speed = -0.2f;

    // 消滅位置
    private float deadLine = -10;

    // Use this for initialization
    void Start(){
        
        //　AudioSourceの呼び出し
        block01 = GetComponent<AudioSource>();

    }
    
    // 衝突時にSE再生
    void OnCollisionEnter2D(Collision2D collision)
    {
        //キャラクターとの衝突時は再生しない
        if (collision.gameObject.tag == "Character"){
            block01.volume = 0;
        }else{
            block01.Play();
        }
    }
    // Update is called once per frame
    void Update()
    {
        // キューブを移動させる
        transform.Translate(this.speed, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }
}