using UnityEngine;
using UnityEngine.UI;
//For any questions of this part, please contact Wang Junfeng for help (vx:winter-camellia)


public class FloatingText
{
    public bool active;
    public GameObject go;
    public Text txt;
    public Vector3 motion;
    public float duration;
    public float lastShown;

    public void Show() //��ʾ
    {
        active = true;
        lastShown = Time.time;
        go.SetActive(active);
    }

    public void Hide() //����
    {
        active = false;
        go.SetActive(active);
    }

    public void UpdateFloatingText()
    {
        if (!active)
            return;
        if (Time.time - lastShown > duration)
            Hide();

        go.transform.position += motion * Time.deltaTime; //ĳ��frame�Ǽ���״̬ʱ��Ҫ���������˶��ƶ�

    }
}
