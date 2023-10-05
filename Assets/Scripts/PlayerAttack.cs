using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float interactionRange = 2.0f; // PlayerとEnemyの間の許容距離

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractWithEnemy();
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
        // ギズモの色を設定（例: グリーン）
        Gizmos.color = Color.yellow;

        // ギズモの範囲を表示
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
