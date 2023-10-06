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



    public GameObject beamPrefab; // ビームのプレハブ
    public Transform firePoint;   // ビームの発射位置
    public float beamSpeed = 10f; // ビームの速度


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


        // スペースキーが押されたらビームを発射
        if (Input.GetKey(KeyCode.Space))
        {
            // 一番近くの敵を探す
            GameObject nearestEnemy = FindNearestEnemy();

            // ターゲットが設定されている場合
            if (nearestEnemy != null)
            {
                // ビームを発射
                ShootBeam(nearestEnemy);
            }
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
    GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); // 敵のタグを設定しておく

        GameObject nearestEnemy = null;
        float nearestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < nearestDistance)
            {
                nearestEnemy = enemy;
                nearestDistance = distance;
            }
        }

        return nearestEnemy;
    }

    void ShootBeam(GameObject target)
    {
        // ビームをプレファブからインスタンス化
        GameObject beamInstance = Instantiate(beamPrefab, firePoint.position, firePoint.rotation);

        // ビームの方向を設定（追尾）
        Vector3 direction = (target.transform.position - firePoint.position).normalized;
        beamInstance.GetComponent<Rigidbody>().velocity = direction * beamSpeed;

        // 一定時間後にビームを破壊する（例：1秒後）
        Destroy(beamInstance, 5f);
    }
    private void OnDrawGizmos()
    {
        // ギズモの色を設定
        Gizmos.color = Color.yellow;
        
        // ギズモの範囲を表示
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
