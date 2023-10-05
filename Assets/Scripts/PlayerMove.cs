using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 50.0f; // �v���C���[�̈ړ����x

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // ���͂Ɋ�Â��Ĉړ��x�N�g�����쐬
        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput) * moveSpeed * Time.deltaTime;

        // �v���C���[���ړ�������
        transform.Translate(movement);

        //// �v���C���[�̌������J�����̕����ɍ��킹��
        //if (movement != Vector3.zero)
        //{
        //    Quaternion newRotation = Quaternion.LookRotation(movement);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 0.1f);
        //}
    }
}
