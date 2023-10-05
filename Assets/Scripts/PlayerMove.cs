using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 50.0f; // プレイヤーの移動速度

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 入力に基づいて移動ベクトルを作成
        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput) * moveSpeed * Time.deltaTime;

        // プレイヤーを移動させる
        transform.Translate(movement);

        //// プレイヤーの向きをカメラの方向に合わせる
        //if (movement != Vector3.zero)
        //{
        //    Quaternion newRotation = Quaternion.LookRotation(movement);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 0.1f);
        //}
    }
}
