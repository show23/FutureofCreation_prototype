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



    public GameObject beamPrefab; // �r�[���̃v���n�u
    public Transform firePoint;   // �r�[���̔��ˈʒu
    public float beamSpeed = 10f; // �r�[���̑��x


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


        // �X�y�[�X�L�[�������ꂽ��r�[���𔭎�
        if (Input.GetKey(KeyCode.Space))
        {
            // ��ԋ߂��̓G��T��
            GameObject nearestEnemy = FindNearestEnemy();

            // �^�[�Q�b�g���ݒ肳��Ă���ꍇ
            if (nearestEnemy != null)
            {
                // �r�[���𔭎�
                ShootBeam(nearestEnemy);
            }
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
    GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); // �G�̃^�O��ݒ肵�Ă���

        GameObject nearestEnemy = null;
        float nearestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < nearestDistance)
            {
                nearestEnemy = enemy;
                nearestDistance = distance;
            }
        }

        return nearestEnemy;
    }

    void ShootBeam(GameObject target)
    {
        // �r�[�����v���t�@�u����C���X�^���X��
        GameObject beamInstance = Instantiate(beamPrefab, firePoint.position, firePoint.rotation);

        // �r�[���̕�����ݒ�i�ǔ��j
        Vector3 direction = (target.transform.position - firePoint.position).normalized;
        beamInstance.GetComponent<Rigidbody>().velocity = direction * beamSpeed;

        // ��莞�Ԍ�Ƀr�[����j�󂷂�i��F1�b��j
        Destroy(beamInstance, 5f);
    }
    private void OnDrawGizmos()
    {
        // �M�Y���̐F��ݒ�
        Gizmos.color = Color.yellow;
        
        // �M�Y���͈̔͂�\��
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
