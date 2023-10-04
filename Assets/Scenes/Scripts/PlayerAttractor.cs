using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttractor : MonoBehaviour
{
    public float attractionRange = 10f; // �����񂹂�͈�
    public float attractionForce = 5f;  // �����񂹂��
    public KeyCode attractionKey = KeyCode.Q; // �����񂹂�L�[

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
                        // �v���C���[����G�ւ̕����x�N�g�����v�Z
                        Vector3 attractionDirection = (transform.position - col.transform.position).normalized;

                        // �����񂹂�͂�K�p
                        rb.AddForce(attractionDirection * attractionForce, ForceMode.Force);
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
    }
}

