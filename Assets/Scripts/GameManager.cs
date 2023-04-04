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
        //PlayerPrefs.DeleteAll();//清空积累的钱，经验等
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);//保留数据不因为换关卡消失
    }

    //资源
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable; //升级所需经验值

    //引用
    public Player player;
    //public Weapon weapon; ......
    public FloatingTextManager floatingTextManager;

    //属性
    public int pesos;//钱
    public int experience;//xp


    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }


    public void SaveState()
    {
        //保存游戏
        string s = "";
        s += "0" + "|"; //人物皮肤
        s += pesos.ToString() + "|"; //钱
        s += experience.ToString() + "|"; //xp
        s += "0"; //武器等级

        PlayerPrefs.SetString("SaveState", s);
        Debug.Log("Save");
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        //加载进度
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        //换肤(tbd)
        
        pesos = int.Parse(data[1]);
        experience = int.Parse(data[2]);

        //改变武器等级(tbd)
    }
}
