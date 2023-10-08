using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public string enemyTag = "Enemy"; // タグ名を指定
    private List<Transform> touchedEnemies = new List<Transform>(); // プレイヤーが触れた敵を記録するリスト
    public float speed = 50;
    private float originalSpeed; // オリジナルの速度を保存する変数

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(enemyTag))
        {
            // プレイヤーが敵に触れた場合、リストに敵のTransformを追加
            Transform enemyTransform = collision.gameObject.transform;
            if (!touchedEnemies.Contains(enemyTransform))
            {
                touchedEnemies.Add(enemyTransform);
            }
        }
    }

    private void Start()
    {
        PlayerMove playerMove = GetComponent<PlayerMove>();
        originalSpeed = playerMove.moveSpeed; // ゲーム開始時の速度を保存
    }

    void Update()
    {
        PlayerMove playermove = GetComponent<PlayerMove>();
        
        // Rボタンが押されたかをチェック
        if (Input.GetKey(KeyCode.R))
        {
            playermove.moveSpeed = speed;
            // Line Rendererの頂点数を触れた敵の数 + 1 に設定
            lineRenderer.positionCount = touchedEnemies.Count + 1;

            // プレイヤーから各敵への線を描画
            lineRenderer.SetPosition(0, transform.position); // 開始点

            // プレイヤーが触れた順に線を描画
            for (int i = 0; i < touchedEnemies.Count; i++)
            {
                Vector3 enemyPosition = touchedEnemies[i].position;
                lineRenderer.SetPosition(i + 1, enemyPosition); // 敵への線を描画
            }
        }
        else
        {
            // Rボタンが押されていない場合、線を非表示にする
            lineRenderer.positionCount = 0;

            // オリジナルの速度に戻す
            playermove.moveSpeed = originalSpeed;
        }
    }
}
