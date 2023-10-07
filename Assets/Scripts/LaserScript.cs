using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public GameObject laserVFX; // ���[�U�[VFX��Prefab
    public Transform emitterTransform; // ���[�U�[�̔��ˈʒu
    public Transform target; // �^�[�Q�b�g (Enemy)

    private GameObject currentLaser; // ���݂̃��[�U�[VFX

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // ���Ȃ��̃��[�U�[�𔭎˂���g���K�[������I�����Ă�������
        {
            // ���[�U�[VFX�𐶐�
            currentLaser = Instantiate(laserVFX, emitterTransform.position, emitterTransform.rotation);

            // ���[�U�[�̕������v�Z
            Vector3 direction = target.position - emitterTransform.position;

            // ���[�U�[�̒�����ݒ� (�K�v�ɉ����Ē���)
            float laserLength = direction.magnitude;
            currentLaser.transform.localScale = new Vector3(1f, 1f, laserLength);

            // ���[�U�[���^�[�Q�b�g�Ɍ�����
            currentLaser.transform.LookAt(target);
        }
        else if (Input.GetButtonUp("Fire1")) // ���[�U�[���~����g���K�[������I�����Ă�������
        {
            // ���[�U�[���~���邽�߂ɁAVFX��j��
            Destroy(currentLaser);
        }
    }
}
