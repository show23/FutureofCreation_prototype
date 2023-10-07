using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public GameObject laserVFX; // レーザーVFXのPrefab
    public Transform emitterTransform; // レーザーの発射位置
    public Transform target; // ターゲット (Enemy)

    private GameObject currentLaser; // 現在のレーザーVFX

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // あなたのレーザーを発射するトリガー条件を選択してください
        {
            // レーザーVFXを生成
            currentLaser = Instantiate(laserVFX, emitterTransform.position, emitterTransform.rotation);

            // レーザーの方向を計算
            Vector3 direction = target.position - emitterTransform.position;

            // レーザーの長さを設定 (必要に応じて調整)
            float laserLength = direction.magnitude;
            currentLaser.transform.localScale = new Vector3(1f, 1f, laserLength);

            // レーザーをターゲットに向ける
            currentLaser.transform.LookAt(target);
        }
        else if (Input.GetButtonUp("Fire1")) // レーザーを停止するトリガー条件を選択してください
        {
            // レーザーを停止するために、VFXを破棄
            Destroy(currentLaser);
        }
    }
}
