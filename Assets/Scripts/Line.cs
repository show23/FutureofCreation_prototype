using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public string enemyTag = "Enemy"; // �^�O�����w��
    private List<Transform> touchedEnemies = new List<Transform>(); // �v���C���[���G�ꂽ�G���L�^���郊�X�g
    public float speed = 50;
    private float originalSpeed; // �I���W�i���̑��x��ۑ�����ϐ�

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(enemyTag))
        {
            // �v���C���[���G�ɐG�ꂽ�ꍇ�A���X�g�ɓG��Transform��ǉ�
            Transform enemyTransform = collision.gameObject.transform;
            if (!touchedEnemies.Contains(enemyTransform))
            {
                touchedEnemies.Add(enemyTransform);
            }
        }
    }

    private void Start()
    {
        PlayerMove playerMove = GetComponent<PlayerMove>();
        originalSpeed = playerMove.moveSpeed; // �Q�[���J�n���̑��x��ۑ�
    }

    void Update()
    {
        PlayerMove playermove = GetComponent<PlayerMove>();
        
        // R�{�^���������ꂽ�����`�F�b�N
        if (Input.GetKey(KeyCode.R))
        {
            playermove.moveSpeed = speed;
            // Line Renderer�̒��_����G�ꂽ�G�̐� + 1 �ɐݒ�
            lineRenderer.positionCount = touchedEnemies.Count + 1;

            // �v���C���[����e�G�ւ̐���`��
            lineRenderer.SetPosition(0, transform.position); // �J�n�_

            // �v���C���[���G�ꂽ���ɐ���`��
            for (int i = 0; i < touchedEnemies.Count; i++)
            {
                Vector3 enemyPosition = touchedEnemies[i].position;
                lineRenderer.SetPosition(i + 1, enemyPosition); // �G�ւ̐���`��
            }
        }
        else
        {
            // R�{�^����������Ă��Ȃ��ꍇ�A�����\���ɂ���
            lineRenderer.positionCount = 0;

            // �I���W�i���̑��x�ɖ߂�
            playermove.moveSpeed = originalSpeed;
        }
    }
}
