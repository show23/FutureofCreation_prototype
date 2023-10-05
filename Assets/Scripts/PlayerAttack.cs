using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // �V���O���g��
    public static PlayerAttack instance;

    public float interactionRange = 0.0f; // Player��Enemy�̊Ԃ̋��e����
    public KeyCode attackKey = KeyCode.E; // �����񂹂�L�[
    public float increasedRange = 10.0f; // �L�[��������Ă���ԂɊg�傷��͈�

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

    private void Update()
    {
        // �L�[��������Ă����
        if (Input.GetKey(attackKey))
        {
            // interactionRange�𑝉�������
            interactionRange += increasedRange * Time.deltaTime;
            //InteractWithEnemy();
        }
        else
        {
           
            
        }

        if (Input.GetKeyUp(attackKey))
        {
            InteractWithEnemy();
            // �L�[�������ꂽ��interactionRange�����ɖ߂�
            interactionRange = 0.0f; // �����l�ɖ߂��A�K�v�ɉ����ĕύX
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
        // �M�Y���̐F��ݒ�
        Gizmos.color = Color.yellow;
        
        // �M�Y���͈̔͂�\��
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
