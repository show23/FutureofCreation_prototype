using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player;  // �v���C���[��Transform
    public Vector3 offset;  // �v���C���[�ƃJ�����̑��Έʒu
    public float smoothTime = 0.3f;  // �J�������v���C���[��ǐՂ���ۂ̃X���[�Y���̒����p�p�����[�^
    private Vector3 velocity = Vector3.zero;  // �J�����ړ����̑��x�x�N�g��
    // �v���C���[�ړ���ɃJ�����ړ������������̂ŁALateUpdate���g��
    void LateUpdate()
    {
        // �v���C���[�̈ʒu�ɃJ������Ǐ]������
        Vector3 targetPosition = player.position + offset;
        targetPosition.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

}
