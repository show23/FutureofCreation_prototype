using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttractor : MonoBehaviour
{
    //シングルトン
    public static PlayerAttractor instance;

    public float attractionRange = 10f;     // 引き寄せる範囲
    public float attractionForce = 5f;      // 引き寄せる力
    public float maxSpeed = 10f;            // 最大速度
    public float stopDistance = 2f;         // 停止距離
    public KeyCode attractionKey = KeyCode.Q; // 引き寄せるキー

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
    private void FixedUpdate()
    {
        if (Input.GetKey(attractionKey))
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, attractionRange);

            foreach (Collider col in colliders)
            {
                if (col.CompareTag("Enemy"))
                {
                    Rigidbody rb = col.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        // プレイヤーから敵への方向ベクトルと距離を計算
                        Vector3 directionToPlayer = transform.position - col.transform.position;
                        float distanceToPlayer = directionToPlayer.magnitude;

                        // 引き寄せる力を適用
                        if (distanceToPlayer > stopDistance)
                        {
                            Vector3 attractionDirection = directionToPlayer.normalized;
                            rb.AddForce(attractionDirection * attractionForce, ForceMode.Force);

                            // 速度を制限して最大速度に収束させる
                            if (rb.velocity.magnitude > maxSpeed)
                            {
                                rb.velocity = rb.velocity.normalized * maxSpeed;
                            }
                        }
                        else
                        {
                            // 停止距離内にいる場合、力をゼロに設定して停止
                            rb.velocity = Vector3.zero;
                        }
                    }
                }
            }
        }
    }

    // ギズモを表示するためのメソッド
    private void OnDrawGizmos()
    {
        // ギズモの色を設定（例: グリーン）
        Gizmos.color = Color.green;

        // ギズモの範囲を表示
        Gizmos.DrawWireSphere(transform.position, attractionRange);

        // ギズモの停止距離を表示
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stopDistance);
    }
}
