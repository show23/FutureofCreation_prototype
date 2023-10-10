using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LightGage : MonoBehaviour
{
    [SerializeField]
    Image image1;
    Image image2;

    bool mouseButton = false;

    // Start is called before the first frame update
    void Start()
    {
        image2 = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

        // Fill Amountによってゲージの色を変える
        if (image2.fillAmount > 0.5f)
        {

            image1.color = Color.red;

        }
        else if (image2.fillAmount > 0.2f)
        {

            image1.color = new Color(1f, 0.67f, 0f);

        }
        else
        {

            image1.color = Color.green;

        }

        // マウスを使ってゲージを増減させる
        if (Input.GetMouseButtonDown(0))
        {
            mouseButton = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            mouseButton = false;
        }


        if (mouseButton)
        {

            image2.fillAmount += Time.deltaTime;

        }
        else if (image2.fillAmount > 0f)
        {

            image2.fillAmount -= Time.deltaTime;

        }

    }
}
