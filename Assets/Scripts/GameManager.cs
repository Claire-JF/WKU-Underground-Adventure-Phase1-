using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//For any questions of this part, please contact Wang Junfeng for help (vx:winter-camellia)

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if(GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        //PlayerPrefs.DeleteAll();//��ջ��۵�Ǯ�������
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);//�������ݲ���Ϊ���ؿ���ʧ
    }

    //��Դ
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable; //�������辭��ֵ

    //����
    public Player player;
    //public Weapon weapon; ......
    public FloatingTextManager floatingTextManager;

    //����
    public int pesos;//Ǯ
    public int experience;//xp


    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }


    public void SaveState()
    {
        //������Ϸ
        string s = "";
        s += "0" + "|"; //����Ƥ��
        s += pesos.ToString() + "|"; //Ǯ
        s += experience.ToString() + "|"; //xp
        s += "0"; //�����ȼ�

        PlayerPrefs.SetString("SaveState", s);
        Debug.Log("Save");
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        //���ؽ���
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        //����(tbd)
        
        pesos = int.Parse(data[1]);
        experience = int.Parse(data[2]);

        //�ı������ȼ�(tbd)
    }
}
