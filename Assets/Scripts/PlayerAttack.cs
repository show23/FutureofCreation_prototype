using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // シングルトン
    public static PlayerAttack instance;

    public float interactionRange = 0.0f; // PlayerとEnemyの間の許容距離
    public KeyCode attackKey = KeyCode.E; // 引き寄せるキー
    public float increasedRange = 10.0f; // キーが押されている間に拡大する範囲

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        // キーが押されている間
        if (Input.GetKey(attackKey))
        {
            // interactionRangeを増加させる
            interactionRange += increasedRange * Time.deltaTime;
            //InteractWithEnemy();
        }
        else
        {
           
            
        }

        if (Input.GetKeyUp(attackKey))
        {
            InteractWithEnemy();
            // キーが離されたらinteractionRangeを元に戻す
            interactionRange = 0.0f; // 初期値に戻す、必要に応じて変更
        }
        
    }

    void InteractWithEnemy()
    {
        
        // Playerの位置
        Vector3 playerPosition = transform.position;

        // 範囲内の全てのEnemyを検出
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
           
            // EnemyとPlayerの距離を計算
            float distance = Vector3.Distance(playerPosition, enemy.transform.position);

            // 許容距離内にいるかどうかを確認
            if (distance <= interactionRange)
            {
                // Enemyを破壊
                Destroy(enemy);
                
            }
        }
    }

    private void OnDrawGizmos()
    {
        // ギズモの色を設定
        Gizmos.color = Color.yellow;
        
        // ギズモの範囲を表示
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
