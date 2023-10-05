using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float interactionRange = 2.0f; // Player��Enemy�̊Ԃ̋��e����

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractWithEnemy();
        }
    }

    void InteractWithEnemy()
    {
        // Player�̈ʒu
        Vector3 playerPosition = transform.position;

        // �͈͓��̑S�Ă�Enemy�����o
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            // Enemy��Player�̋������v�Z
            float distance = Vector3.Distance(playerPosition, enemy.transform.position);

            // ���e�������ɂ��邩�ǂ������m�F
            if (distance <= interactionRange)
            {
                // Enemy��j��
                Destroy(enemy);
            }
        }
    }
    private void OnDrawGizmos()
    {
        // �M�Y���̐F��ݒ�i��: �O���[���j
        Gizmos.color = Color.yellow;

        // �M�Y���͈̔͂�\��
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
