using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yosokuen : MonoBehaviour
{
    // �^�[�Q�b�g�ƂȂ�I�u�W�F�N�g��Transform�R���|�[�l���g���擾
    private Transform targetTransform;

    // �I�u�W�F�N�g�̏����T�C�Y�ƐV�����T�C�Y��ݒ�
    private Vector3 initialSize;
    private Vector3 newSize = new Vector3(2.0f, 2.0f, 2.0f); // ��Ƃ���2�{�̑傫���ɕύX

    // �T�C�Y�ύX�̑��x
    public float sizeChangeSpeed = 1.0f;

    private bool isResizing = false;

    private void Start()
    {
        // �^�[�Q�b�g�I�u�W�F�N�g�𖼑O�Ō������A����Transform���擾
        targetTransform = GameObject.Find("�g�[���X").transform;

        // �^�[�Q�b�g�I�u�W�F�N�g�̏����T�C�Y��ۑ�
        initialSize = new Vector3(0.0f, 0.0f, 0.0f);
    }

    private void Update()
    {
        // ��Ƃ��ăX�y�[�X�L�[�������ƃT�C�Y��ύX����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isResizing = true;
        }
        // ���Z�b�g����ꍇ�i�����T�C�Y�ɖ߂��j
        else if (Input.GetKeyDown(KeyCode.R))
        {
            isResizing = false;
            targetTransform.localScale = initialSize;
        }

        // �{�^����������Ă���ԂɃT�C�Y��ύX����
        if (isResizing)
        {
            // �V�����T�C�Y�Ɍ������ď��X�ɕύX
            targetTransform.localScale = Vector3.Lerp(targetTransform.localScale, newSize, sizeChangeSpeed * Time.deltaTime);
        }
    }


}
