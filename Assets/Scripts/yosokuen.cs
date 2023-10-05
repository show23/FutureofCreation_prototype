using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yosokuen : MonoBehaviour
{
    // ターゲットとなるオブジェクトのTransformコンポーネントを取得
    private Transform targetTransform;

    // オブジェクトの初期サイズと新しいサイズを設定
    private Vector3 initialSize;
    private Vector3 newSize = new Vector3(2.0f, 2.0f, 2.0f); // 例として2倍の大きさに変更

    // サイズ変更の速度
    public float sizeChangeSpeed = 1.0f;

    private bool isResizing = false;

    private void Start()
    {
        // ターゲットオブジェクトを名前で検索し、そのTransformを取得
        targetTransform = GameObject.Find("トーラス").transform;

        // ターゲットオブジェクトの初期サイズを保存
        initialSize = new Vector3(0.0f, 0.0f, 0.0f);
    }

    private void Update()
    {
        // 例としてスペースキーを押すとサイズを変更する
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isResizing = true;
        }
        // リセットする場合（初期サイズに戻す）
        else if (Input.GetKeyDown(KeyCode.R))
        {
            isResizing = false;
            targetTransform.localScale = initialSize;
        }

        // ボタンが押されている間にサイズを変更する
        if (isResizing)
        {
            // 新しいサイズに向かって徐々に変更
            targetTransform.localScale = Vector3.Lerp(targetTransform.localScale, newSize, sizeChangeSpeed * Time.deltaTime);
        }
    }


}
