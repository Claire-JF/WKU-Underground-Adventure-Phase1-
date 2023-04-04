using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{

    public GameObject textContainer;

    public GameObject textPrefab;

    private List<FloatingText> floatingTexts = new List<FloatingText>();


    private void Update()
    {
        foreach (FloatingText txt in floatingTexts)
            txt.UpdateFloatingText(); //Call for updates
    }

    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingText floatingText = GetFloatingText();
        floatingText.txt.text = msg;
        floatingText.txt.fontSize = fontSize;
        floatingText.txt.color = color;
        floatingText.go.transform.position = Camera.main.WorldToScreenPoint(position);
        //人物和物体的坐标系为world coordinate，而Text以及其他UI的坐标系为screen coordinate，所以要转换
        floatingText.motion = motion;
        floatingText.duration = duration;

        floatingText.Show();
    }

    private FloatingText GetFloatingText()
    {
        FloatingText txt = floatingTexts.Find(t => !t.active); //找没被激活的

        if (txt == null)
        {
            txt = new FloatingText();
            txt.go = Instantiate(textPrefab);
            txt.go.transform.SetParent(textContainer.transform);
            txt.txt = txt.go.GetComponent<Text>();

            floatingTexts.Add(txt);
        }
        return txt;
    }
}
