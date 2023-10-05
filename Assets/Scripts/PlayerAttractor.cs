using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttractor : MonoBehaviour
{
    //�V���O���g��
    public static PlayerAttractor instance;

    public float attractionRange = 10f;     // �����񂹂�͈�
    public float attractionForce = 5f;      // �����񂹂��
    public float maxSpeed = 10f;            // �ő呬�x
    public float stopDistance = 2f;         // ��~����
    public KeyCode attractionKey = KeyCode.Q; // �����񂹂�L�[

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
                        // �v���C���[����G�ւ̕����x�N�g���Ƌ������v�Z
                        Vector3 directionToPlayer = transform.position - col.transform.position;
                        float distanceToPlayer = directionToPlayer.magnitude;

                        // �����񂹂�͂�K�p
                        if (distanceToPlayer > stopDistance)
                        {
                            Vector3 attractionDirection = directionToPlayer.normalized;
                            rb.AddForce(attractionDirection * attractionForce, ForceMode.Force);

                            // ���x�𐧌����čő呬�x�Ɏ���������
                            if (rb.velocity.magnitude > maxSpeed)
                            {
                                rb.velocity = rb.velocity.normalized * maxSpeed;
                            }
                        }
                        else
                        {
                            // ��~�������ɂ���ꍇ�A�͂��[���ɐݒ肵�Ē�~
                            rb.velocity = Vector3.zero;
                        }
                    }
                }
            }
        }
    }

    // �M�Y����\�����邽�߂̃��\�b�h
    private void OnDrawGizmos()
    {
        // �M�Y���̐F��ݒ�i��: �O���[���j
        Gizmos.color = Color.green;

        // �M�Y���͈̔͂�\��
        Gizmos.DrawWireSphere(transform.position, attractionRange);

        // �M�Y���̒�~������\��
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stopDistance);
    }
}
