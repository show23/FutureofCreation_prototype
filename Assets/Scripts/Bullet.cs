using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    /////////////////////
    ///////////////////////�Ǐ]�r�[��
    ////////////////////////
    //private Transform target; // �r�[���̒ǔ��Ώ�
    //public float beamSpeed = 100f; // �r�[���̑��x

    //// �ǔ��Ώۂ�ݒ�
    //public void SetTarget(Transform newTarget)
    //{
    //    target = newTarget;
    //}

    //void Update()
    //{
    //    // �ǔ��Ώۂ����݂���ꍇ
    //    if (target != null)
    //    {
    //        // �r�[���̕�����ݒ�i�ǔ��j
    //        Vector3 direction = (target.position - transform.position).normalized;
    //        GetComponent<Rigidbody>().velocity = direction * beamSpeed;
    //    }
    //}

    private Transform target; // �r�[���̒ǔ��Ώ�
    public float beamSpeed = 100f; // �r�[���̑��x
    public float curveStrength = 1f; // �J�[�u�̋��x
    public int curveSwitchFrequency = 60; // �J�[�u������؂�ւ���p�x�i��: 60�t���[�����Ɓj

    private int frameCount = 0; // �t���[���J�E���g
    private bool curveLeft = true; // �J�[�u������؂�ւ���t���O

    // �G�̒ǐՑΏۂ�ݒ�
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void Start()
    {
        // ������ԂŃJ�[�u���������݂ɐݒ�
        curveLeft = (Random.Range(0, 2) == 0) ? true : false;
    }

    void Update()
    {
        // �ǔ��Ώۂ����݂���ꍇ
        if (target != null)
        {
            // �r�[���̕�����ݒ�i�ǔ��j
            Vector3 direction = (target.position - transform.position).normalized;

            // �J�[�u��K�p
            Vector3 curve = Vector3.zero;

            
            // �J�[�u�����ɉ����ăJ�[�u��K�p
            if (curveLeft)
            {
                curve = Vector3.Cross(Vector3.up, direction) * curveStrength;
            }
            else
            {
                curve = -Vector3.Cross(Vector3.up, direction) * curveStrength;
            }

            GetComponent<Rigidbody>().velocity = (direction + curve) * beamSpeed;

           
        }
    }
}
