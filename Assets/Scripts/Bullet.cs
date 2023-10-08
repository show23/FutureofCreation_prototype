using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    /////////////////////
    ///////////////////////追従ビーム
    ////////////////////////
    //private Transform target; // ビームの追尾対象
    //public float beamSpeed = 100f; // ビームの速度

    //// 追尾対象を設定
    //public void SetTarget(Transform newTarget)
    //{
    //    target = newTarget;
    //}

    //void Update()
    //{
    //    // 追尾対象が存在する場合
    //    if (target != null)
    //    {
    //        // ビームの方向を設定（追尾）
    //        Vector3 direction = (target.position - transform.position).normalized;
    //        GetComponent<Rigidbody>().velocity = direction * beamSpeed;
    //    }
    //}

    private Transform target; // ビームの追尾対象
    public float beamSpeed = 100f; // ビームの速度
    public float curveStrength = 1f; // カーブの強度
    public int curveSwitchFrequency = 60; // カーブ方向を切り替える頻度（例: 60フレームごと）

    private int frameCount = 0; // フレームカウント
    private bool curveLeft = true; // カーブ方向を切り替えるフラグ

    // 敵の追跡対象を設定
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void Start()
    {
        // 初期状態でカーブ方向を交互に設定
        curveLeft = (Random.Range(0, 2) == 0) ? true : false;
    }

    void Update()
    {
        // 追尾対象が存在する場合
        if (target != null)
        {
            // ビームの方向を設定（追尾）
            Vector3 direction = (target.position - transform.position).normalized;

            // カーブを適用
            Vector3 curve = Vector3.zero;

            
            // カーブ方向に応じてカーブを適用
            if (curveLeft)
            {
                curve = Vector3.Cross(Vector3.up, direction) * curveStrength;
            }
            else
            {
                curve = -Vector3.Cross(Vector3.up, direction) * curveStrength;
            }

            GetComponent<Rigidbody>().velocity = (direction + curve) * beamSpeed;

           
        }
    }
}
