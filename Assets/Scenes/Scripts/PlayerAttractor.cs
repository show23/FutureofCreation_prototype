using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttractor : MonoBehaviour
{
    public float attractionRange = 10f; // 引き寄せる範囲
    public float attractionForce = 5f;  // 引き寄せる力
    public KeyCode attractionKey = KeyCode.Q; // 引き寄せるキー

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
                        // プレイヤーから敵への方向ベクトルを計算
                        Vector3 attractionDirection = (transform.position - col.transform.position).normalized;

                        // 引き寄せる力を適用
                        rb.AddForce(attractionDirection * attractionForce, ForceMode.Force);
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
    }
}

