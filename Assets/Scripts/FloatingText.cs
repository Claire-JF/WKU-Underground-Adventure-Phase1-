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

    public void Show() //显示
    {
        active = true;
        lastShown = Time.time;
        go.SetActive(active);
    }

    public void Hide() //隐藏
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

        go.transform.position += motion * Time.deltaTime; //某个frame是激活状态时，要跟随人物运动移动

    }
}
