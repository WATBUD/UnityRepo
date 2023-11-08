//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class GameSys : MonoBehaviour
//{
//    #region//宣告變數
//    [SerializeField] GameObject[] Line = new GameObject[25];//線圖案
//    [SerializeField] GameObject[] Prize = new GameObject[5];//大獎
//    [SerializeField] GameObject[] LevelAnim = new GameObject[2];//特殊關卡
//    [SerializeField] GameObject PrizePanel;//大獎
//    [SerializeField] GameObject LevelPanel;//關卡
//    [SerializeField] GameObject BonusPanel;//抽蒸籠
//    [SerializeField] GameObject Slot_Panel;
//    [SerializeField] GameObject FreeSpin_Panel;
//    [SerializeField] GameObject FreeSpin_Square;
//    [SerializeField] GameObject FreeSpin_Btn;
//    [SerializeField] GameObject Wild_Panel;
//    [SerializeField] GameObject Line_Sound;

//    [SerializeField] AudioSource Win_Sound;
//    [SerializeField] AudioSource Stage_Sound;
//    [SerializeField] AudioSource Stop_Sound;
//    [SerializeField] AudioClip ReelStop_Sound;
//    [SerializeField] AudioClip FiveReelStop_Sound;

//    [SerializeField] Sprite[] SlotSprite = new Sprite[13];//輪盤圖案
//    [SerializeField] Image[] SlotTurn0 = new Image[30];//第一輪
//    [SerializeField] Image[] SlotTurn1 = new Image[30];//第二輪
//    [SerializeField] Image[] SlotTurn2 = new Image[30];//第三輪
//    [SerializeField] Image[] SlotTurn3 = new Image[30];//第四輪
//    [SerializeField] Image[] SlotTurn4 = new Image[30];//第五輪

//    [SerializeField] Button Bet_Btn;
//    [SerializeField] Button Lobby_Btn;
//    [SerializeField] Text Win_text;//大獎文字
//    [SerializeField] Text GetMoney_text;//贏分的文字
//    [SerializeField] Text Free_text;//免費轉

//    public static bool CanChangeSlotImage;//換圖片(Server給的結果)
//    public static bool ChangeFakeSlotImage;//換圖片(隨機輪轉給玩家看的內容)
//    public static bool CanTurn;//可以轉
//    public static bool AutoPlay;//自動打
//    public static float time;//時間
//    public static int PrizeNum = -1;//大獎編號0Big 1Mega 2Epic 3Ultra 4Jackpot 
//    public static bool PlayBonusGame;//可以玩BonusGame
//    public static bool PlayWildAnim;//美女上菜
//    public static bool TimeAuto;

//    int MaxJ;//連線是幾個3 4 5 
//    int TimeSize;//跑完調整的速度
//    int MoveSize;//輪轉的速度
//    int[] PlayAnimNum = new int[5];//播動畫的數值
//    int[] SlotTurn = new int[5];//五個輪
//    int[,,] SlotTurnNum = new int[5, 5, 30]{
//    {{5,6,5,4,7,8,2,9,9,0,8,7,5,6,9,7,8,6,3,9,1,4,8,5,2,9,6,8,3,7},{2,7,5,9,6,4,8,7,8,0,9,9,5,8,7,3,9,8,5,6,8,9,7,4,8,9,3,8,9,6},{3,6,8,7,2,6,4,8,9,0,8,8,4,9,8,3,9,5,7,6,1,9,8,2,7,9,4,8,5,9},{9,6,7,4,8,2,8,5,8,0,9,7,3,8,6,7,9,5,2,8,4,6,9,3,5,8,7,6,9,4},{10,11,12,9,6,7,5,7,9,0,8,3,6,8,7,2,9,5,8,4,1,9,5,3,8,2,9,6,4,8}},
//    {{4,8,5,3,7,4,2,8,6,1,7,4,7,8,9,5,4,6,8,2,0,5,9,3,9,7,2,6,9,4},{2,9,4,7,6,3,8,4,9,8,2,6,7,4,9,8,3,6,5,7,0,9,5,8,4,9,5,7,2,8},{4,9,5,8,2,7,4,6,9,1,8,5,7,3,6,5,9,3,8,6,0,9,5,8,7,2,7,4,7,9},{3,9,4,8,2,6,9,3,8,5,7,2,7,4,6,3,9,5,7,3,0,6,4,9,2,8,7,3,6,5},{10,11,12,9,8,2,9,3,8,1,6,3,7,5,2,9,6,4,8,5,0,9,3,6,8,2,5,4,6,7}},
//    {{9,6,5,4,7,8,2,9,7,4,6,7,5,4,0,7,8,6,3,9,1,4,8,5,2,9,6,8,3,7},{2,7,5,9,6,4,8,7,5,6,2,9,5,8,0,3,9,8,5,6,8,9,7,4,8,9,3,8,9,6},{3,6,8,7,2,6,4,9,5,2,7,8,4,9,0,3,9,5,7,6,1,9,8,2,7,6,4,8,5,9},{9,6,7,4,8,2,8,5,7,9,4,7,3,8,0,7,9,5,2,8,4,6,9,3,5,8,7,6,9,4},{10,11,12,9,6,7,5,7,9,7,8,3,6,8,0,2,9,5,8,4,1,9,5,3,8,2,5,6,4,8}},
//    {{2,3,4,5,6,7,8,9,2,3,4,5,6,7,8,9,2,3,4,5,6,7,8,9,2,3,4,5,6,7},{2,3,4,5,6,7,8,9,2,3,4,5,6,7,8,9,2,3,4,5,6,7,8,9,2,3,4,5,6,7},{2,3,4,5,6,7,8,9,2,3,4,5,6,7,8,9,2,3,4,5,6,7,8,9,2,3,4,5,6,7},{2,3,4,5,6,7,8,9,2,3,4,5,6,7,8,9,2,3,4,5,6,7,8,9,2,3,4,5,6,7},{2,3,4,5,6,7,8,9,2,3,4,5,6,7,8,9,2,3,4,5,6,7,8,9,2,3,4,5,6,7}},
//    {{2,2,2,2,2,2,2,2,3,3,3,3,3,3,3,3,4,4,4,4,4,4,4,5,5,5,5,5,5,5},{2,2,2,2,2,2,2,2,3,3,3,3,3,3,3,3,4,4,4,4,4,4,4,5,5,5,5,5,5,5},{10,11,12,10,11,12,10,11,12,10,11,12,10,11,12,10,11,12,10,11,12,10,11,12,10,11,12,10,11,12},{2,2,2,2,2,2,2,2,3,3,3,3,3,3,3,3,4,4,4,4,4,4,4,5,5,5,5,5,5,5},{2,2,2,2,2,2,2,2,3,3,3,3,3,3,3,3,4,4,4,4,4,4,4,5,5,5,5,5,5,5}}};
//    float[] newY = new float[5];
//    float PlayAnimWait;//播動畫前延遲時間
//    float[] ChangeSlotTime = new float[10];//輪軸旋轉時間設定

//    Animator[] PlayAnim = new Animator[15];
//    #endregion
//    // Use this for initialization
//    void Start()
//    {
//        for (int i = 0; i < 30; i++)
//        {
//            SlotTurn0[i].sprite = SlotSprite[SlotTurnNum[Random.Range(0, 3), 0, i]];
//            SlotTurn1[i].sprite = SlotSprite[SlotTurnNum[Random.Range(0, 3), 1, i]];
//            SlotTurn2[i].sprite = SlotSprite[SlotTurnNum[Random.Range(0, 3), 2, i]];
//            SlotTurn3[i].sprite = SlotSprite[SlotTurnNum[Random.Range(0, 3), 3, i]];
//            SlotTurn4[i].sprite = SlotSprite[SlotTurnNum[Random.Range(0, 3), 4, i]];
//        }
//        if (PlayerPrefs.GetInt("SceneNum") == 3){SlotTurnNum = new int[5, 5, 30]{
//    {{5,6,5,4,7,8,2,9,9,0,8,7,5,6,9,7,8,6,3,9,1,4,8,5,2,9,6,8,3,7},{2,7,5,9,6,4,8,7,8,0,9,9,5,8,7,3,9,8,5,6,8,9,7,4,8,9,3,8,9,6},{3,6,8,7,2,6,4,8,9,0,8,8,4,9,8,3,9,5,7,6,1,9,8,2,7,9,4,8,5,9},{9,6,7,4,8,2,8,5,8,0,9,7,3,8,6,7,9,5,2,8,4,6,9,3,5,8,7,6,9,4},{10,11,12,9,6,7,5,7,9,0,8,3,6,8,7,2,9,5,8,4,1,9,5,3,8,2,9,6,4,8}},
//    {{4,8,5,3,7,4,2,8,6,1,7,4,7,8,9,5,4,6,8,2,0,5,9,3,9,7,2,6,9,4},{2,9,4,7,6,3,8,4,9,8,2,6,7,4,9,8,3,6,5,7,0,9,5,8,4,9,5,7,2,8},{4,9,5,8,2,7,4,6,9,1,8,5,7,3,6,5,9,3,8,6,0,9,5,8,7,2,7,4,7,9},{3,9,4,8,2,6,9,3,8,5,7,2,7,4,6,3,9,5,7,3,0,6,4,9,2,8,7,3,6,5},{10,11,12,9,8,2,9,3,8,1,6,3,7,5,2,9,6,4,8,5,0,9,3,6,8,2,5,4,6,7}},
//    {{9,6,5,4,7,8,2,9,7,4,6,7,5,4,0,7,8,6,3,9,1,4,8,5,2,9,6,8,3,7},{2,7,5,9,6,4,8,7,5,6,2,9,5,8,0,3,9,8,5,6,8,9,7,4,8,9,3,8,9,6},{3,6,8,7,2,6,4,9,5,2,7,8,4,9,0,3,9,5,7,6,1,9,8,2,7,6,4,8,5,9},{9,6,7,4,8,2,8,5,7,9,4,7,3,8,0,7,9,5,2,8,4,6,9,3,5,8,7,6,9,4},{10,11,12,9,6,7,5,7,9,7,8,3,6,8,0,2,9,5,8,4,1,9,5,3,8,2,5,6,4,8}},
//    {{2,3,4,5,6,7,8,9,2,3,4,5,6,7,8,9,2,3,4,5,6,7,8,9,2,3,4,5,6,7},{2,3,4,5,6,7,8,9,2,3,4,5,6,7,8,9,2,3,4,5,6,7,8,9,2,3,4,5,6,7},{2,3,4,5,6,7,8,9,2,3,4,5,6,7,8,9,2,3,4,5,6,7,8,9,2,3,4,5,6,7},{2,3,4,5,6,7,8,9,2,3,4,5,6,7,8,9,2,3,4,5,6,7,8,9,2,3,4,5,6,7},{2,3,4,5,6,7,8,9,2,3,4,5,6,7,8,9,2,3,4,5,6,7,8,9,2,3,4,5,6,7}},
//    {{2,2,2,2,2,2,2,2,3,3,3,3,3,3,3,3,4,4,4,4,4,4,4,5,5,5,5,5,5,5},{2,2,2,2,2,2,2,2,3,3,3,3,3,3,3,3,4,4,4,4,4,4,4,5,5,5,5,5,5,5},{10,11,12,10,11,12,10,11,12,10,11,12,10,11,12,10,11,12,10,11,12,10,11,12,10,11,12,10,11,12},{2,2,2,2,2,2,2,2,3,3,3,3,3,3,3,3,4,4,4,4,4,4,4,5,5,5,5,5,5,5},{2,2,2,2,2,2,2,2,3,3,3,3,3,3,3,3,4,4,4,4,4,4,4,5,5,5,5,5,5,5}}};}
//        else if (PlayerPrefs.GetInt("SceneNum") == 4){SlotTurnNum = new int[5, 5, 30] {
//    {{7,6,8,3,7,6,9,4,8,0,9,5,4,2,3,7,2,5,9,1,8,5,6,4,8,9,6,7,9,3},{6,9,7,9,3,7,8,4,9,0,8,6,5,9,7,2,9,5,2,2,3,6,4,8,4,5,8,6,3,7},{3,7,6,9,2,3,7,4,8,0,9,8,7,5,6,2,9,5,8,1,9,7,4,6,5,4,8,3,6,9},{8,9,6,2,3,7,9,4,9,0,8,7,5,6,2,8,6,5,4,2,9,7,5,3,4,8,7,6,3,9},{10,10,10,3,6,7,9,4,8,0,9,5,7,2,8,7,6,5,9,1,8,6,5,4,8,9,4,7,6,3}},
//    {{9,8,6,5,3,7,9,8,4,1,5,5,3,8,9,6,2,4,7,0,6,7,8,9,2,4,9,7,6,8},{5,6,5,8,3,4,8,9,7,2,9,3,5,8,9,6,4,2,7,0,9,8,7,6,2,9,4,6,7,8},{6,5,8,6,3,8,4,5,9,1,3,7,9,5,8,4,9,7,2,0,8,6,9,7,2,9,6,4,8,7},{5,6,5,6,3,4,8,9,7,2,8,3,5,8,7,9,4,2,8,0,9,8,7,6,2,9,4,6,7,9},{5,8,6,5,3,6,9,8,7,1,9,5,3,10,10,10,2,4,9,0,7,7,8,6,2,4,9,7,6,8}},
//    {{5,4,6,9,3,8,9,0,8,7,6,5,7,8,2,9,6,7,5,3,7,8,1,9,8,4,9,5,4,7},{5,6,8,3,9,4,7,8,0,9,7,6,5,9,2,8,6,5,3,7,9,2,8,7,4,9,4,8,5,7},{6,9,3,8,4,5,7,5,9,0,8,7,6,8,2,9,5,3,7,8,1,9,7,6,5,4,8,4,9,7},{5,6,8,3,9,4,7,8,0,9,7,6,5,9,2,8,6,5,3,7,9,2,8,7,4,9,4,8,5,7},{5,4,6,9,3,8,9,0,8,7,6,5,7,8,2,9,6,7,5,3,7,8,1,9,8,4,9,10,10,10}},
//    {{2,3,4,5,6,7,8,9,2,3,4,5,6,7,8,9,2,3,4,5,6,7,8,9,2,3,4,5,6,7},{2,3,4,5,6,7,8,9,2,3,4,5,6,7,8,9,2,3,4,5,6,7,8,9,2,3,4,5,6,7},{2,3,4,5,6,7,8,9,2,3,4,5,6,7,8,9,2,3,4,5,6,7,8,9,2,3,4,5,6,7},{2,3,4,5,6,7,8,9,2,3,4,5,6,7,8,9,2,3,4,5,6,7,8,9,2,3,4,5,6,7},{2,3,4,5,6,7,8,9,2,3,4,5,6,7,8,9,2,3,4,5,6,7,8,9,2,3,4,5,6,7}},
//    {{2,2,2,2,2,2,2,2,3,3,3,3,3,3,3,3,4,4,4,4,4,4,4,5,5,5,5,5,5,5},{2,2,2,2,2,2,2,2,3,3,3,3,3,3,3,3,4,4,4,4,4,4,4,5,5,5,5,5,5,5},{10,11,12,10,11,12,10,11,12,10,11,12,10,11,12,10,11,12,10,11,12,10,11,12,10,11,12,10,11,12},{2,2,2,2,2,2,2,2,3,3,3,3,3,3,3,3,4,4,4,4,4,4,4,5,5,5,5,5,5,5},{2,2,2,2,2,2,2,2,3,3,3,3,3,3,3,3,4,4,4,4,4,4,4,5,5,5,5,5,5,5}}};}
//    }

//    // Update is called once per frame
//    void FixedUpdate()
//    {
//        if (CanTurn == true)//正在轉
//        {
//            GetMoney_text.text = "線數 25  線注 " + (Bet_Control.BetNum[Bet_Control.SwitchNum] / 25).ToString("#,##0");
//            Lobby_Btn.enabled = false;
//            Line_Sound.SetActive(false);
//            if (PhotonClient.newPhotonClient.iLVNum != 0)
//            {
//                FreeSpin_Btn.GetComponent<Button>().enabled = false;
//                Free_text.text = "免費 " + PhotonClient.newPhotonClient.iLVNum.ToString();
//            }
//            else if (PhotonClient.newPhotonClient.iLVNum == 0) FreeSpin_Btn.SetActive(false);
//            for (int i = 0; i < 25; i++)
//            {
//                if (PhotonClient.newPhotonClient.iLine25[i] != 0)
//                {
//                    Line[i].SetActive(false);//隱藏25線
//                    for (int j = 0; j < 15; j++)
//                    {
//                        if (PlayAnim[j].enabled == true)
//                        {
//                            PlayAnim[j].SetInteger("SlotImage", -1);
//                            PlayAnim[j].enabled = false;
//                        }
//                    }
//                }
//            }
//            if (AutoPlay == false)//沒有開自動
//            {
//                if (Spin_Control.StopAuto == false)//沒按停止鍵
//                {
//                    PlayAnimWait = 5f;MoveSize = -50;
//                    Stop_Sound.clip = FiveReelStop_Sound;
//                    ChangeSlotTime = new float[10] { 1f, 1.5f, 2f, 2.5f, 3f, 3.5f, 1.5f, 2f, 2.5f, 3f };
//                }
//                else if (Spin_Control.StopAuto == true)//按停止鍵
//                {
//                    PlayAnimWait = 2f;MoveSize = -65;
//                    Stop_Sound.clip = ReelStop_Sound;
//                    if (time <= 1.5f) { ChangeSlotTime = new float[10] { 1f, 1f, 1f, 1f, 1f, 1.5f, 1.5f, 1.5f, 1.5f, 1.5f }; }
//                    else if (time > 1.5f && time <= 2f) { ChangeSlotTime = new float[10] { 1f, 1.5f, 1.5f, 1.5f, 1.5f, 2f, 1.5f, 2f, 2f, 2f }; }
//                    else if (time > 2f && time <= 2.5f) { ChangeSlotTime = new float[10] { 1f, 1.5f, 2f, 2f, 2f, 2.5f, 1.5f, 2f, 2.5f, 2.5f }; }
//                    else if (time > 2.5f) { ChangeSlotTime = new float[10] { 1f, 1.5f, 2f, 2.5f, 3f, 3.5f, 1.5f, 2f, 2.5f, 3f }; }
//                }
//            }
//            else if (AutoPlay == true)//開自動
//            {
//                PlayAnimWait = 2f;MoveSize = -60;//移動速度加快
//                Stop_Sound.clip = ReelStop_Sound;
//                ChangeSlotTime = new float[10] { 0.6f, 0.6f, 0.6f, 0.6f, 0.6f, 1f, 1f, 1f, 1f, 1f };
//            }
//            if (CanChangeSlotImage == false)
//            {
//                for (int i = 0; i < 30; i++)
//                {
//                    #region//換行
//                    if (i != 29)//超過最下面跑到最上面
//                    {
//                        if (SlotTurn0[i].transform.localPosition.y <= -450) SlotTurn0[i].transform.localPosition = new Vector2(0, SlotTurn0[i + 1].transform.localPosition.y + 225);
//                        if (SlotTurn1[i].transform.localPosition.y <= -450) SlotTurn1[i].transform.localPosition = new Vector2(0, SlotTurn1[i + 1].transform.localPosition.y + 225);
//                        if (SlotTurn2[i].transform.localPosition.y <= -450) SlotTurn2[i].transform.localPosition = new Vector2(0, SlotTurn2[i + 1].transform.localPosition.y + 225);
//                        if (SlotTurn3[i].transform.localPosition.y <= -450) SlotTurn3[i].transform.localPosition = new Vector2(0, SlotTurn3[i + 1].transform.localPosition.y + 225);
//                        if (SlotTurn4[i].transform.localPosition.y <= -450) SlotTurn4[i].transform.localPosition = new Vector2(0, SlotTurn4[i + 1].transform.localPosition.y + 225);
//                    }
//                    else if (i == 29)//超過最下面跑到最上面//先暴力解決了之後有問題再說
//                    {
//                        if (SlotTurn0[i].transform.localPosition.y <= -450) SlotTurn0[i].transform.localPosition = new Vector2(0, SlotTurn0[0].transform.localPosition.y + 275);
//                        if (SlotTurn1[i].transform.localPosition.y <= -450) SlotTurn1[i].transform.localPosition = new Vector2(0, SlotTurn1[0].transform.localPosition.y + 275);
//                        if (SlotTurn2[i].transform.localPosition.y <= -450) SlotTurn2[i].transform.localPosition = new Vector2(0, SlotTurn2[0].transform.localPosition.y + 275);
//                        if (SlotTurn3[i].transform.localPosition.y <= -450) SlotTurn3[i].transform.localPosition = new Vector2(0, SlotTurn3[0].transform.localPosition.y + 275);
//                        if (SlotTurn4[i].transform.localPosition.y <= -450) SlotTurn4[i].transform.localPosition = new Vector2(0, SlotTurn4[0].transform.localPosition.y + 275);
//                    }
//                    #endregion
//                    #region//移動
//                    SlotTurn0[i].transform.Translate(0, MoveSize, 0);
//                    SlotTurn1[i].transform.Translate(0, MoveSize, 0);
//                    SlotTurn2[i].transform.Translate(0, MoveSize, 0);
//                    SlotTurn3[i].transform.Translate(0, MoveSize, 0);
//                    SlotTurn4[i].transform.Translate(0, MoveSize, 0);
//                    #endregion
//                }
//            }
//            if (CanChangeSlotImage == true)//換成Server給的結果
//            {
//                if (ChangeFakeSlotImage == true) ChangeTurnImage();
//                time = time + Time.deltaTime;//print(time);
//                for (int i = 0; i < 30; i++)
//                {
//                    #region//換行
//                    if (i != 29)//超過最下面跑到最上面
//                    {
//                        if (SlotTurn0[i].transform.localPosition.y <= -450) SlotTurn0[i].transform.localPosition = new Vector2(0, SlotTurn0[i + 1].transform.localPosition.y + 225);
//                        if (SlotTurn1[i].transform.localPosition.y <= -450) SlotTurn1[i].transform.localPosition = new Vector2(0, SlotTurn1[i + 1].transform.localPosition.y + 225);
//                        if (SlotTurn2[i].transform.localPosition.y <= -450) SlotTurn2[i].transform.localPosition = new Vector2(0, SlotTurn2[i + 1].transform.localPosition.y + 225);
//                        if (SlotTurn3[i].transform.localPosition.y <= -450) SlotTurn3[i].transform.localPosition = new Vector2(0, SlotTurn3[i + 1].transform.localPosition.y + 225);
//                        if (SlotTurn4[i].transform.localPosition.y <= -450) SlotTurn4[i].transform.localPosition = new Vector2(0, SlotTurn4[i + 1].transform.localPosition.y + 225);
//                    }
//                    else if (i == 29)//超過最下面跑到最上面//先暴力解決了之後有問題再說
//                    {
//                        if (SlotTurn0[i].transform.localPosition.y <= -450) SlotTurn0[i].transform.localPosition = new Vector2(0, SlotTurn0[0].transform.localPosition.y + 275);
//                        if (SlotTurn1[i].transform.localPosition.y <= -450) SlotTurn1[i].transform.localPosition = new Vector2(0, SlotTurn1[0].transform.localPosition.y + 275);
//                        if (SlotTurn2[i].transform.localPosition.y <= -450) SlotTurn2[i].transform.localPosition = new Vector2(0, SlotTurn2[0].transform.localPosition.y + 275);
//                        if (SlotTurn3[i].transform.localPosition.y <= -450) SlotTurn3[i].transform.localPosition = new Vector2(0, SlotTurn3[0].transform.localPosition.y + 275);
//                        if (SlotTurn4[i].transform.localPosition.y <= -450) SlotTurn4[i].transform.localPosition = new Vector2(0, SlotTurn4[0].transform.localPosition.y + 275);
//                    }
//                    #endregion
//                    #region//移動
//                    if (time <= ChangeSlotTime[0]) {SlotTurn0[i].transform.Translate(0, MoveSize, 0);
//                       // Stop_Sound.Play();
//                    }
//                    if (time <= ChangeSlotTime[1]) SlotTurn1[i].transform.Translate(0, MoveSize, 0);
//                    if (time <= ChangeSlotTime[2]) SlotTurn2[i].transform.Translate(0, MoveSize, 0);
//                    if (time <= ChangeSlotTime[3]) SlotTurn3[i].transform.Translate(0, MoveSize, 0);
//                    if (time <= ChangeSlotTime[4]) SlotTurn4[i].transform.Translate(0, MoveSize, 0);
//                    #endregion
//                    #region//換圖 
//                    if (time > ChangeSlotTime[0] && time <= ChangeSlotTime[6])
//                    {
//                        if (SlotTurn0[i].transform.localPosition.y > 113 && SlotTurn0[i].transform.localPosition.y < 338)
//                        {
//                            Stop_Sound.Play(); print("play");

//                            SlotTurn[0] = i;
//                            if (i < 28)
//                            {
//                                if (PhotonClient.newPhotonClient.islot3x5[0] != -1) SlotTurn0[i].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[0]];
//                                if (PhotonClient.newPhotonClient.islot3x5[5] != -1) SlotTurn0[i + 1].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[5]];
//                                if (PhotonClient.newPhotonClient.islot3x5[10] != -1) SlotTurn0[i + 2].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[10]];
//                            }
//                            else if (i == 28)
//                            {
//                                if (PhotonClient.newPhotonClient.islot3x5[0] != -1) SlotTurn0[28].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[0]];
//                                if (PhotonClient.newPhotonClient.islot3x5[5] != -1) SlotTurn0[29].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[5]];
//                                if (PhotonClient.newPhotonClient.islot3x5[10] != -1) SlotTurn0[0].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[10]];
//                            }
//                            else if (i == 29)
//                            {
//                                if (PhotonClient.newPhotonClient.islot3x5[0] != -1) SlotTurn0[29].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[0]];
//                                if (PhotonClient.newPhotonClient.islot3x5[5] != -1) SlotTurn0[0].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[5]];
//                                if (PhotonClient.newPhotonClient.islot3x5[10] != -1) SlotTurn0[1].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[10]];
//                            }
//                            newY[0] = Vector2.Distance(SlotTurn0[i].transform.localPosition, new Vector2(0, 225));
//                            if (newY[0] < 0) TimeSize = (int)(newY[0] / -2);
//                            else if (newY[0] > 0) TimeSize = (int)(newY[0] / 2);
//                            for (int j = 0; j < i; j++) { SlotTurn0[j].transform.localPosition = Vector2.Lerp(SlotTurn0[j].transform.localPosition, new Vector2(0, SlotTurn0[j].transform.localPosition.y + newY[0]), Time.deltaTime * TimeSize); }
//                            for (int j = 29; j >= i; j--) { SlotTurn0[j].transform.localPosition = Vector2.Lerp(SlotTurn0[j].transform.localPosition, new Vector2(0, SlotTurn0[j].transform.localPosition.y + newY[0]), Time.deltaTime * TimeSize); }
//                        }
//                    }
//                    if (time > ChangeSlotTime[1] && time <= ChangeSlotTime[7])
//                    {
//                        if (SlotTurn1[i].transform.localPosition.y > 113 && SlotTurn1[i].transform.localPosition.y < 338)
//                        {
//                            SlotTurn[1] = i;
//                            if (i < 28)
//                            {
//                                if (PhotonClient.newPhotonClient.islot3x5[1] != -1) SlotTurn1[i].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[1]];
//                                if (PhotonClient.newPhotonClient.islot3x5[6] != -1) SlotTurn1[i + 1].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[6]];
//                                if (PhotonClient.newPhotonClient.islot3x5[11] != -1) SlotTurn1[i + 2].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[11]];
//                            }
//                            else if (i == 28)
//                            {
//                                if (PhotonClient.newPhotonClient.islot3x5[1] != -1) SlotTurn1[28].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[1]];
//                                if (PhotonClient.newPhotonClient.islot3x5[6] != -1) SlotTurn1[29].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[6]];
//                                if (PhotonClient.newPhotonClient.islot3x5[11] != -1) SlotTurn1[0].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[11]];
//                            }
//                            else if (i == 29)
//                            {
//                                if (PhotonClient.newPhotonClient.islot3x5[1] != -1) SlotTurn1[29].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[1]];
//                                if (PhotonClient.newPhotonClient.islot3x5[6] != -1) SlotTurn1[0].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[6]];
//                                if (PhotonClient.newPhotonClient.islot3x5[11] != -1) SlotTurn1[1].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[11]];
//                            }
//                            newY[1] = Vector2.Distance(SlotTurn1[i].transform.localPosition, new Vector2(0, 225));
//                            if (newY[1] < 0) TimeSize = (int)(newY[1] / -2);
//                            else if (newY[1] > 0) TimeSize = (int)(newY[1] / 2);
//                            for (int j = 0; j < i; j++) { SlotTurn1[j].transform.localPosition = Vector2.Lerp(SlotTurn1[j].transform.localPosition, new Vector2(0, SlotTurn1[j].transform.localPosition.y + newY[1]), Time.deltaTime * TimeSize); }
//                            for (int j = 29; j >= i; j--) { SlotTurn1[j].transform.localPosition = Vector2.Lerp(SlotTurn1[j].transform.localPosition, new Vector2(0, SlotTurn1[j].transform.localPosition.y + newY[1]), Time.deltaTime * TimeSize); }
//                        }
//                    }
//                    if (time > ChangeSlotTime[2] && time <= ChangeSlotTime[8])
//                    {
//                        if (SlotTurn2[i].transform.localPosition.y > 113 && SlotTurn2[i].transform.localPosition.y < 338)
//                        {
//                            SlotTurn[2] = i;
//                            if (i < 28)
//                            {
//                                if (PhotonClient.newPhotonClient.islot3x5[2] != -1) SlotTurn2[i].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[2]];
//                                if (PhotonClient.newPhotonClient.islot3x5[7] != -1) SlotTurn2[i + 1].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[7]];
//                                if (PhotonClient.newPhotonClient.islot3x5[12] != -1) SlotTurn2[i + 2].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[12]];
//                            }
//                            else if (i == 28)
//                            {
//                                if (PhotonClient.newPhotonClient.islot3x5[2] != -1) SlotTurn2[28].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[2]];
//                                if (PhotonClient.newPhotonClient.islot3x5[7] != -1) SlotTurn2[29].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[7]];
//                                if (PhotonClient.newPhotonClient.islot3x5[12] != -1) SlotTurn2[0].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[12]];
//                            }
//                            else if (i == 29)
//                            {
//                                if (PhotonClient.newPhotonClient.islot3x5[2] != -1) SlotTurn2[29].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[2]];
//                                if (PhotonClient.newPhotonClient.islot3x5[7] != -1) SlotTurn2[0].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[7]];
//                                if (PhotonClient.newPhotonClient.islot3x5[12] != -1) SlotTurn2[1].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[12]];
//                            }
//                            newY[2] = Vector2.Distance(SlotTurn2[i].transform.localPosition, new Vector2(0, 225));
//                            if (newY[2] < 0) TimeSize = (int)(newY[2] / -2);
//                            else if (newY[2] > 0) TimeSize = (int)(newY[2] / 2);
//                            for (int j = 0; j < i; j++) { SlotTurn2[j].transform.localPosition = Vector2.Lerp(SlotTurn2[j].transform.localPosition, new Vector2(0, SlotTurn2[j].transform.localPosition.y + newY[2]), Time.deltaTime * TimeSize); }
//                            for (int j = 29; j >= i; j--) { SlotTurn2[j].transform.localPosition = Vector2.Lerp(SlotTurn2[j].transform.localPosition, new Vector2(0, SlotTurn2[j].transform.localPosition.y + newY[2]), Time.deltaTime * TimeSize); }
//                        }
//                    }
//                    if (time > ChangeSlotTime[3] && time <= ChangeSlotTime[9])
//                    {
//                        if (SlotTurn3[i].transform.localPosition.y > 113 && SlotTurn3[i].transform.localPosition.y < 338)
//                        {
//                            if (PhotonClient.newPhotonClient.iAllFG == 3) Stage_Sound.Play();
//                            SlotTurn[3] = i;
//                            if (i < 28)
//                            {
//                                if (PhotonClient.newPhotonClient.islot3x5[3] != -1) SlotTurn3[i].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[3]];
//                                if (PhotonClient.newPhotonClient.islot3x5[8] != -1) SlotTurn3[i + 1].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[8]];
//                                if (PhotonClient.newPhotonClient.islot3x5[13] != -1) SlotTurn3[i + 2].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[13]];
//                            }
//                            else if (i == 28)
//                            {
//                                if (PhotonClient.newPhotonClient.islot3x5[3] != -1) SlotTurn3[28].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[3]];
//                                if (PhotonClient.newPhotonClient.islot3x5[8] != -1) SlotTurn3[29].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[8]];
//                                if (PhotonClient.newPhotonClient.islot3x5[13] != -1) SlotTurn3[0].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[13]];
//                            }
//                            else if (i == 29)
//                            {
//                                if (PhotonClient.newPhotonClient.islot3x5[3] != -1) SlotTurn3[29].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[3]];
//                                if (PhotonClient.newPhotonClient.islot3x5[8] != -1) SlotTurn3[0].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[8]];
//                                if (PhotonClient.newPhotonClient.islot3x5[13] != -1) SlotTurn3[1].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[13]];
//                            }
//                            newY[3] = Vector2.Distance(SlotTurn3[i].transform.localPosition, new Vector2(0, 225));
//                            if (newY[3] < 0) TimeSize = (int)(newY[3] / -2);
//                            else if (newY[3] > 0) TimeSize = (int)(newY[3] / 2);
//                            for (int j = 0; j < i; j++) { SlotTurn3[j].transform.localPosition = Vector2.Lerp(SlotTurn3[j].transform.localPosition, new Vector2(0, SlotTurn3[j].transform.localPosition.y + newY[3]), Time.deltaTime * TimeSize); }
//                            for (int j = 29; j >= i; j--) { SlotTurn3[j].transform.localPosition = Vector2.Lerp(SlotTurn3[j].transform.localPosition, new Vector2(0, SlotTurn3[j].transform.localPosition.y + newY[3]), Time.deltaTime * TimeSize); }
//                        }
//                    }
//                    if (time > ChangeSlotTime[4] && time <= ChangeSlotTime[5])
//                    {
//                        if (SlotTurn4[i].transform.localPosition.y > 113 && SlotTurn4[i].transform.localPosition.y < 338)
//                        {
//                            SlotTurn[4] = i;
//                            if (i < 28)
//                            {
//                                if (PhotonClient.newPhotonClient.islot3x5[4] != -1) SlotTurn4[i].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[4]];
//                                if (PhotonClient.newPhotonClient.islot3x5[9] != -1) SlotTurn4[i + 1].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[9]];
//                                if (PhotonClient.newPhotonClient.islot3x5[14] != -1) SlotTurn4[i + 2].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[14]];
//                            }
//                            else if (i == 28)
//                            {
//                                if (PhotonClient.newPhotonClient.islot3x5[4] != -1) SlotTurn4[28].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[4]];
//                                if (PhotonClient.newPhotonClient.islot3x5[9] != -1) SlotTurn4[29].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[9]];
//                                if (PhotonClient.newPhotonClient.islot3x5[14] != -1) SlotTurn4[0].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[14]];
//                            }
//                            else if (i == 29)
//                            {
//                                if (PhotonClient.newPhotonClient.islot3x5[4] != -1) SlotTurn4[29].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[4]];
//                                if (PhotonClient.newPhotonClient.islot3x5[9] != -1) SlotTurn4[0].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[9]];
//                                if (PhotonClient.newPhotonClient.islot3x5[14] != -1) SlotTurn4[1].sprite = SlotSprite[PhotonClient.newPhotonClient.islot3x5[14]];
//                            }
//                            newY[4] = Vector2.Distance(SlotTurn4[i].transform.localPosition, new Vector2(0, 225));
//                            if (newY[4] < 0) TimeSize = (int)(newY[4] / -2);
//                            else if (newY[4] > 0) TimeSize = (int)(newY[4] / 2);
//                            for (int j = 0; j < i; j++) { SlotTurn4[j].transform.localPosition = Vector2.Lerp(SlotTurn4[j].transform.localPosition, new Vector2(0, SlotTurn4[j].transform.localPosition.y + newY[4]), Time.deltaTime * TimeSize); }
//                            for (int j = 29; j >= i; j--) { SlotTurn4[j].transform.localPosition = Vector2.Lerp(SlotTurn4[j].transform.localPosition, new Vector2(0, SlotTurn4[j].transform.localPosition.y + newY[4]), Time.deltaTime * TimeSize); }
//                        }
//                    }
//                    else if (time >= ChangeSlotTime[5]) { CanTurn = false; }
//                    #endregion
//                }
//            }
//        }
//        else if (CanTurn == false)//沒有在轉
//        {
//            FreeSpin_Btn.GetComponent<Button>().enabled = true;
//            time = time + Time.deltaTime;
//            CanChangeSlotImage = false;
//            Lobby_Btn.enabled = true;
//            if (AutoPlay == false) { if (Spin_Control.StopAuto == true) Spin_Control.StopAuto = false; }
//            if (PlayBonusGame == true) { if (AutoPlay == true) { if (CanTurn == false) { TimeAuto = true; AutoPlay = false; } } }
//            if (Auto_Control.AutoNum[Auto_Control.SwitchNum] == 0) AutoPlay = false;
//            if (PhotonClient.newPhotonClient.iAllFG != 1)
//            {
//                if (PhotonClient.newPhotonClient.Line_Money > 0)
//                {
//                    GetMoney_text.text = "恭喜中獎   贏分 " + PhotonClient.newPhotonClient.Line_Money.ToString("#,##0");
//                    if (PhotonClient.newPhotonClient.Line_Money / Bet_Control.BetNum[Bet_Control.SwitchNum] < 10) PrizePanel.SetActive(false);
//                }
//                else if (PhotonClient.newPhotonClient.Line_Money == 0)
//                {
//                    GetMoney_text.text = "線數 25  線注 " + (Bet_Control.BetNum[Bet_Control.SwitchNum] / 25).ToString("#,##0");
//                    PrizePanel.SetActive(false);

//                }
//            }                
//            if (PhotonClient.newPhotonClient.iLVNum == 0)//如果不是關卡
//            {
//                Slot_Panel.SetActive(true);
//                FreeSpin_Panel.SetActive(false);
//                FreeSpin_Square.SetActive(false);
//                FreeSpin_Btn.SetActive(false);
//                Wild_Panel.SetActive(false);
                
//                Bet_Btn.enabled = true;
//            }
//            for (int i = 0; i < 25; i++)
//            {
//                if (PhotonClient.newPhotonClient.iLine25[i] != 0)//如果有連線
//                {
//                    if (PhotonClient.newPhotonClient.iLine25[i] % 3 == 1) MaxJ = 5;
//                    else if (PhotonClient.newPhotonClient.iLine25[i] % 3 == 2) MaxJ = 4;
//                    else if (PhotonClient.newPhotonClient.iLine25[i] % 3 == 0) MaxJ = 3;
//                    Line[i].SetActive(true);
//                    Line_Sound.SetActive(true);
//                    switch (i)//25線
//                    {
//                        case 0:
//                            PlayAnimNum = new int[] { 0, 1, 2, 3, 4 }; PlayAnim[PlayAnimNum[0]] = SlotTurn0[SlotTurn[0]].GetComponent<Animator>(); PlayAnim[PlayAnimNum[1]] = SlotTurn1[SlotTurn[1]].GetComponent<Animator>(); PlayAnim[PlayAnimNum[2]] = SlotTurn2[SlotTurn[2]].GetComponent<Animator>(); PlayAnim[PlayAnimNum[3]] = SlotTurn3[SlotTurn[3]].GetComponent<Animator>(); PlayAnim[PlayAnimNum[4]] = SlotTurn4[SlotTurn[4]].GetComponent<Animator>();
//                            for (int j = 0; j < MaxJ; j++) { PlayAnim[PlayAnimNum[j]].enabled = true; if(PhotonClient.newPhotonClient.islot3x5[0]!=10) PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[0]);else PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[1]); }
//                            if (MaxJ == 5) { if (PhotonClient.newPhotonClient.islot3x5[4] == 10 || PhotonClient.newPhotonClient.islot3x5[4] == 11 || PhotonClient.newPhotonClient.islot3x5[4] == 12) { PlayAnim[PlayAnimNum[4]].enabled = false; PlayAnim[PlayAnimNum[4]].SetInteger("SlotImage", -1); } }
//                            break;
//                        case 1:
//                            PlayAnimNum = new int[] { 5, 6, 7, 8, 9 }; PlayAnim[PlayAnimNum[0]] = SlotTurn0[(SlotTurn[0] + 1) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[1]] = SlotTurn1[(SlotTurn[1] + 1) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[2]] = SlotTurn2[(SlotTurn[2] + 1) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[3]] = SlotTurn3[(SlotTurn[3] + 1) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[4]] = SlotTurn4[(SlotTurn[4] + 1) % 30].GetComponent<Animator>();
//                            for (int j = 0; j < MaxJ; j++) { PlayAnim[PlayAnimNum[j]].enabled = true; if (PhotonClient.newPhotonClient.islot3x5[5] != 10) PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[5]); else PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[6]); }
//                            if (MaxJ == 5) { if (PhotonClient.newPhotonClient.islot3x5[9] == 10 || PhotonClient.newPhotonClient.islot3x5[9] == 11 || PhotonClient.newPhotonClient.islot3x5[9] == 12) { PlayAnim[PlayAnimNum[4]].enabled = false; PlayAnim[PlayAnimNum[4]].SetInteger("SlotImage", -1); } }
//                            break;
//                        case 2:
//                            PlayAnimNum = new int[] { 10, 11, 12, 13, 14 }; PlayAnim[PlayAnimNum[0]] = SlotTurn0[(SlotTurn[0] + 2) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[1]] = SlotTurn1[(SlotTurn[1] + 2) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[2]] = SlotTurn2[(SlotTurn[2] + 2) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[3]] = SlotTurn3[(SlotTurn[3] + 2) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[4]] = SlotTurn4[(SlotTurn[4] + 2) % 30].GetComponent<Animator>();
//                            for (int j = 0; j < MaxJ; j++) { PlayAnim[PlayAnimNum[j]].enabled = true; if (PhotonClient.newPhotonClient.islot3x5[10] != 10) PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[10]); else PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[11]); }
//                            if (MaxJ == 5) { if (PhotonClient.newPhotonClient.islot3x5[14] == 10 || PhotonClient.newPhotonClient.islot3x5[14] == 11 || PhotonClient.newPhotonClient.islot3x5[14] == 12) { PlayAnim[PlayAnimNum[4]].enabled = false; PlayAnim[PlayAnimNum[4]].SetInteger("SlotImage", -1); } }
//                            break;
//                        case 3:
//                            PlayAnimNum = new int[] { 0, 6, 12, 8, 4 }; PlayAnim[PlayAnimNum[0]] = SlotTurn0[SlotTurn[0]].GetComponent<Animator>(); PlayAnim[PlayAnimNum[1]] = SlotTurn1[(SlotTurn[1] + 1) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[2]] = SlotTurn2[(SlotTurn[2] + 2) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[3]] = SlotTurn3[(SlotTurn[3] + 1) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[4]] = SlotTurn4[SlotTurn[4]].GetComponent<Animator>();
//                            for (int j = 0; j < MaxJ; j++) { PlayAnim[PlayAnimNum[j]].enabled = true; if (PhotonClient.newPhotonClient.islot3x5[0] != 10) PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[0]); else PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[6]); }
//                            if (MaxJ == 5) { if (PhotonClient.newPhotonClient.islot3x5[4] == 10 || PhotonClient.newPhotonClient.islot3x5[4] == 11 || PhotonClient.newPhotonClient.islot3x5[4] == 12) { PlayAnim[PlayAnimNum[4]].enabled = false; PlayAnim[PlayAnimNum[4]].SetInteger("SlotImage", -1); } }
//                            break;
//                        case 4:
//                            PlayAnimNum = new int[] { 10, 6, 2, 8, 14 }; PlayAnim[PlayAnimNum[0]] = SlotTurn0[(SlotTurn[0] + 2) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[1]] = SlotTurn1[(SlotTurn[1] + 1) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[2]] = SlotTurn2[SlotTurn[2]].GetComponent<Animator>(); PlayAnim[PlayAnimNum[3]] = SlotTurn3[(SlotTurn[3] + 1) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[4]] = SlotTurn4[(SlotTurn[4] + 2) % 30].GetComponent<Animator>();
//                            for (int j = 0; j < MaxJ; j++) { PlayAnim[PlayAnimNum[j]].enabled = true; if (PhotonClient.newPhotonClient.islot3x5[10] != 10) PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[10]); else PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[6]); }
//                            if (MaxJ == 5) { if (PhotonClient.newPhotonClient.islot3x5[14] == 10 || PhotonClient.newPhotonClient.islot3x5[14] == 11 || PhotonClient.newPhotonClient.islot3x5[14] == 12) { PlayAnim[PlayAnimNum[4]].enabled = false; PlayAnim[PlayAnimNum[4]].SetInteger("SlotImage", -1); } }
//                            break;
//                        case 5:
//                            PlayAnimNum = new int[] { 5, 1, 2, 3, 9 }; PlayAnim[PlayAnimNum[0]] = SlotTurn0[(SlotTurn[0] + 1) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[1]] = SlotTurn1[SlotTurn[1]].GetComponent<Animator>(); PlayAnim[PlayAnimNum[2]] = SlotTurn2[SlotTurn[2]].GetComponent<Animator>(); PlayAnim[PlayAnimNum[3]] = SlotTurn3[SlotTurn[3]].GetComponent<Animator>(); PlayAnim[PlayAnimNum[4]] = SlotTurn4[(SlotTurn[4] + 1) % 30].GetComponent<Animator>();
//                            for (int j = 0; j < MaxJ; j++) { PlayAnim[PlayAnimNum[j]].enabled = true; if (PhotonClient.newPhotonClient.islot3x5[5] != 10) PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[5]); else PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[1]); }
//                            if (MaxJ == 5) { if (PhotonClient.newPhotonClient.islot3x5[9] == 10 || PhotonClient.newPhotonClient.islot3x5[9] == 11 || PhotonClient.newPhotonClient.islot3x5[9] == 12) { PlayAnim[PlayAnimNum[4]].enabled = false; PlayAnim[PlayAnimNum[4]].SetInteger("SlotImage", -1); } }
//                            break;
//                        case 6:
//                            PlayAnimNum = new int[] { 5, 11, 12, 13, 9 }; PlayAnim[PlayAnimNum[0]] = SlotTurn0[(SlotTurn[0] + 1) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[1]] = SlotTurn1[(SlotTurn[1] + 2) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[2]] = SlotTurn2[(SlotTurn[2] + 2) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[3]] = SlotTurn3[(SlotTurn[3] + 2) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[4]] = SlotTurn4[(SlotTurn[4] + 1) % 30].GetComponent<Animator>();
//                            for (int j = 0; j < MaxJ; j++) { PlayAnim[PlayAnimNum[j]].enabled = true; if (PhotonClient.newPhotonClient.islot3x5[5] != 10) PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[5]); else PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[11]); }
//                            if (MaxJ == 5) { if (PhotonClient.newPhotonClient.islot3x5[9] == 10 || PhotonClient.newPhotonClient.islot3x5[9] == 11 || PhotonClient.newPhotonClient.islot3x5[9] == 12) { PlayAnim[PlayAnimNum[4]].enabled = false; PlayAnim[PlayAnimNum[4]].SetInteger("SlotImage", -1); } }
//                            break;
//                        case 7:
//                            PlayAnimNum = new int[] { 0, 1, 7, 13, 14 }; PlayAnim[PlayAnimNum[0]] = SlotTurn0[SlotTurn[0]].GetComponent<Animator>(); PlayAnim[PlayAnimNum[1]] = SlotTurn1[SlotTurn[1]].GetComponent<Animator>(); PlayAnim[PlayAnimNum[2]] = SlotTurn2[(SlotTurn[2] + 1) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[3]] = SlotTurn3[(SlotTurn[3] + 2) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[4]] = SlotTurn4[(SlotTurn[4] + 2) % 30].GetComponent<Animator>();
//                            for (int j = 0; j < MaxJ; j++) { PlayAnim[PlayAnimNum[j]].enabled = true; if (PhotonClient.newPhotonClient.islot3x5[0] != 10) PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[0]); else PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[1]); }
//                            if (MaxJ == 5) { if (PhotonClient.newPhotonClient.islot3x5[14] == 10 || PhotonClient.newPhotonClient.islot3x5[14] == 11 || PhotonClient.newPhotonClient.islot3x5[14] == 12) { PlayAnim[PlayAnimNum[4]].enabled = false; PlayAnim[PlayAnimNum[4]].SetInteger("SlotImage", -1); } }
//                            break;
//                        case 8:
//                            PlayAnimNum = new int[] { 10, 11, 7, 3, 4 }; PlayAnim[PlayAnimNum[0]] = SlotTurn0[(SlotTurn[0] + 2) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[1]] = SlotTurn1[(SlotTurn[1] + 2) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[2]] = SlotTurn2[(SlotTurn[2] + 1) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[3]] = SlotTurn3[SlotTurn[3]].GetComponent<Animator>(); PlayAnim[PlayAnimNum[4]] = SlotTurn4[SlotTurn[4]].GetComponent<Animator>();
//                            for (int j = 0; j < MaxJ; j++) { PlayAnim[PlayAnimNum[j]].enabled = true; if (PhotonClient.newPhotonClient.islot3x5[10] != 10) PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[10]); else PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[11]); }
//                            if (MaxJ == 5) { if (PhotonClient.newPhotonClient.islot3x5[4] == 10 || PhotonClient.newPhotonClient.islot3x5[4] == 11 || PhotonClient.newPhotonClient.islot3x5[4] == 12) { PlayAnim[PlayAnimNum[4]].enabled = false; PlayAnim[PlayAnimNum[4]].SetInteger("SlotImage", -1); } }
//                            break;
//                        case 9:
//                            PlayAnimNum = new int[] { 5, 1, 7, 13, 9 }; PlayAnim[PlayAnimNum[0]] = SlotTurn0[(SlotTurn[0] + 1) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[1]] = SlotTurn1[SlotTurn[1]].GetComponent<Animator>(); PlayAnim[PlayAnimNum[2]] = SlotTurn2[(SlotTurn[2] + 1) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[3]] = SlotTurn3[(SlotTurn[3] + 2) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[4]] = SlotTurn4[(SlotTurn[4] + 1) % 30].GetComponent<Animator>();
//                            for (int j = 0; j < MaxJ; j++) { PlayAnim[PlayAnimNum[j]].enabled = true; if (PhotonClient.newPhotonClient.islot3x5[5] != 10) PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[5]); else PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[1]); }
//                            if (MaxJ == 5) { if (PhotonClient.newPhotonClient.islot3x5[9] == 10 || PhotonClient.newPhotonClient.islot3x5[9] == 11 || PhotonClient.newPhotonClient.islot3x5[9] == 12) { PlayAnim[PlayAnimNum[4]].enabled = false; PlayAnim[PlayAnimNum[4]].SetInteger("SlotImage", -1); } }
//                            break;
//                        case 10:
//                            PlayAnimNum = new int[] { 5, 11, 7, 3, 9 }; PlayAnim[PlayAnimNum[0]] = SlotTurn0[(SlotTurn[0] + 1) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[1]] = SlotTurn1[(SlotTurn[1] + 2) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[2]] = SlotTurn2[(SlotTurn[2] + 1) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[3]] = SlotTurn3[SlotTurn[3]].GetComponent<Animator>(); PlayAnim[PlayAnimNum[4]] = SlotTurn4[(SlotTurn[4] + 1) % 30].GetComponent<Animator>();
//                            for (int j = 0; j < MaxJ; j++) { PlayAnim[PlayAnimNum[j]].enabled = true; if (PhotonClient.newPhotonClient.islot3x5[5] != 10) PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[5]); else PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[11]); }
//                            if (MaxJ == 5) { if (PhotonClient.newPhotonClient.islot3x5[9] == 10 || PhotonClient.newPhotonClient.islot3x5[9] == 11 || PhotonClient.newPhotonClient.islot3x5[9] == 12) { PlayAnim[PlayAnimNum[4]].enabled = false; PlayAnim[PlayAnimNum[4]].SetInteger("SlotImage", -1); } }
//                            break;
//                        case 11:
//                            PlayAnimNum = new int[] { 0, 6, 7, 8, 4 }; PlayAnim[PlayAnimNum[0]] = SlotTurn0[SlotTurn[0]].GetComponent<Animator>(); PlayAnim[PlayAnimNum[1]] = SlotTurn1[(SlotTurn[1] + 1) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[2]] = SlotTurn2[(SlotTurn[2] + 1) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[3]] = SlotTurn3[(SlotTurn[3] + 1) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[4]] = SlotTurn4[SlotTurn[4]].GetComponent<Animator>();
//                            for (int j = 0; j < MaxJ; j++) { PlayAnim[PlayAnimNum[j]].enabled = true; if (PhotonClient.newPhotonClient.islot3x5[0] != 10) PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[0]); else PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[6]); }
//                            if (MaxJ == 5) { if (PhotonClient.newPhotonClient.islot3x5[4] == 10 || PhotonClient.newPhotonClient.islot3x5[4] == 11 || PhotonClient.newPhotonClient.islot3x5[4] == 12) { PlayAnim[PlayAnimNum[4]].enabled = false; PlayAnim[PlayAnimNum[4]].SetInteger("SlotImage", -1); } }
//                            break;
//                        case 12:
//                            PlayAnimNum = new int[] { 10, 6, 7, 8, 4 }; PlayAnim[PlayAnimNum[0]] = SlotTurn0[(SlotTurn[0] + 2) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[1]] = SlotTurn1[(SlotTurn[1] + 1) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[2]] = SlotTurn2[(SlotTurn[2] + 1) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[3]] = SlotTurn3[(SlotTurn[3] + 1) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[4]] = SlotTurn4[(SlotTurn[4] + 2) % 30].GetComponent<Animator>();
//                            for (int j = 0; j < MaxJ; j++) { PlayAnim[PlayAnimNum[j]].enabled = true; if (PhotonClient.newPhotonClient.islot3x5[10] != 10) PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[10]); else PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[6]); }
//                            if (MaxJ == 5) { if (PhotonClient.newPhotonClient.islot3x5[14] == 10 || PhotonClient.newPhotonClient.islot3x5[14] == 11 || PhotonClient.newPhotonClient.islot3x5[14] == 12) { PlayAnim[PlayAnimNum[4]].enabled = false; PlayAnim[PlayAnimNum[4]].SetInteger("SlotImage", -1); } }
//                            break;
//                        case 13:
//                            PlayAnimNum = new int[] { 0, 6, 2, 8, 4 }; PlayAnim[PlayAnimNum[0]] = SlotTurn0[SlotTurn[0]].GetComponent<Animator>(); PlayAnim[PlayAnimNum[1]] = SlotTurn1[(SlotTurn[1] + 1) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[2]] = SlotTurn2[SlotTurn[2]].GetComponent<Animator>(); PlayAnim[PlayAnimNum[3]] = SlotTurn3[(SlotTurn[3] + 1) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[4]] = SlotTurn4[SlotTurn[4]].GetComponent<Animator>();
//                            for (int j = 0; j < MaxJ; j++) { PlayAnim[PlayAnimNum[j]].enabled = true; if (PhotonClient.newPhotonClient.islot3x5[0] != 10) PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[0]); else PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[6]); }
//                            if (MaxJ == 5) { if (PhotonClient.newPhotonClient.islot3x5[4] == 10 || PhotonClient.newPhotonClient.islot3x5[4] == 11 || PhotonClient.newPhotonClient.islot3x5[4] == 12) { PlayAnim[PlayAnimNum[4]].enabled = false; PlayAnim[PlayAnimNum[4]].SetInteger("SlotImage", -1); } }
//                            break;
//                        case 14:
//                            PlayAnimNum = new int[] { 10, 6, 12, 8, 14 }; PlayAnim[PlayAnimNum[0]] = SlotTurn0[(SlotTurn[0] + 2) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[1]] = SlotTurn1[(SlotTurn[1] + 1) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[2]] = SlotTurn2[(SlotTurn[2] + 2) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[3]] = SlotTurn3[(SlotTurn[3] + 1) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[4]] = SlotTurn4[(SlotTurn[4] + 2) % 30].GetComponent<Animator>();
//                            for (int j = 0; j < MaxJ; j++) { PlayAnim[PlayAnimNum[j]].enabled = true; if (PhotonClient.newPhotonClient.islot3x5[10] != 10) PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[10]); else PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[6]); }
//                            if (MaxJ == 5) { if (PhotonClient.newPhotonClient.islot3x5[14] == 10 || PhotonClient.newPhotonClient.islot3x5[14] == 11 || PhotonClient.newPhotonClient.islot3x5[14] == 12) { PlayAnim[PlayAnimNum[4]].enabled = false; PlayAnim[PlayAnimNum[4]].SetInteger("SlotImage", -1); } }
//                            break;
//                        case 15:
//                            PlayAnimNum = new int[] { 5, 6, 2, 8, 9 }; PlayAnim[PlayAnimNum[0]] = SlotTurn0[(SlotTurn[0] + 1) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[1]] = SlotTurn1[(SlotTurn[1] + 1) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[2]] = SlotTurn2[SlotTurn[2]].GetComponent<Animator>(); PlayAnim[PlayAnimNum[3]] = SlotTurn3[(SlotTurn[3] + 1) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[4]] = SlotTurn4[(SlotTurn[4] + 1) % 30].GetComponent<Animator>();
//                            for (int j = 0; j < MaxJ; j++) { PlayAnim[PlayAnimNum[j]].enabled = true; if (PhotonClient.newPhotonClient.islot3x5[5] != 10) PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[5]); else PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[6]); }
//                            if (MaxJ == 5) { if (PhotonClient.newPhotonClient.islot3x5[9] == 10 || PhotonClient.newPhotonClient.islot3x5[9] == 11 || PhotonClient.newPhotonClient.islot3x5[9] == 12) { PlayAnim[PlayAnimNum[4]].enabled = false; PlayAnim[PlayAnimNum[4]].SetInteger("SlotImage", -1); } }
//                            break;
//                        case 16:
//                            PlayAnimNum = new int[] { 5, 6, 12, 8, 9 }; PlayAnim[PlayAnimNum[0]] = SlotTurn0[(SlotTurn[0] + 1) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[1]] = SlotTurn1[(SlotTurn[1] + 1) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[2]] = SlotTurn2[(SlotTurn[2] + 2) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[3]] = SlotTurn3[(SlotTurn[3] + 1) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[4]] = SlotTurn4[(SlotTurn[4] + 1) % 30].GetComponent<Animator>();
//                            for (int j = 0; j < MaxJ; j++) { PlayAnim[PlayAnimNum[j]].enabled = true; if (PhotonClient.newPhotonClient.islot3x5[5] != 10) PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[5]); else PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[6]); }
//                            if (MaxJ == 5) { if (PhotonClient.newPhotonClient.islot3x5[9] == 10 || PhotonClient.newPhotonClient.islot3x5[9] == 11 || PhotonClient.newPhotonClient.islot3x5[9] == 12) { PlayAnim[PlayAnimNum[4]].enabled = false; PlayAnim[PlayAnimNum[4]].SetInteger("SlotImage", -1); } }
//                            break;
//                        case 17:
//                            PlayAnimNum = new int[] { 0, 1, 12, 3, 4 }; PlayAnim[PlayAnimNum[0]] = SlotTurn0[SlotTurn[0]].GetComponent<Animator>(); PlayAnim[PlayAnimNum[1]] = SlotTurn1[SlotTurn[1]].GetComponent<Animator>(); PlayAnim[PlayAnimNum[2]] = SlotTurn2[(SlotTurn[2] + 2) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[3]] = SlotTurn3[SlotTurn[3]].GetComponent<Animator>(); PlayAnim[PlayAnimNum[4]] = SlotTurn4[SlotTurn[4]].GetComponent<Animator>();
//                            for (int j = 0; j < MaxJ; j++) { PlayAnim[PlayAnimNum[j]].enabled = true; if (PhotonClient.newPhotonClient.islot3x5[0] != 10) PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[0]); else PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[1]); }
//                            if (MaxJ == 5) { if (PhotonClient.newPhotonClient.islot3x5[4] == 10 || PhotonClient.newPhotonClient.islot3x5[4] == 11 || PhotonClient.newPhotonClient.islot3x5[4] == 12) { PlayAnim[PlayAnimNum[4]].enabled = false; PlayAnim[PlayAnimNum[4]].SetInteger("SlotImage", -1); } }
//                            break;
//                        case 18:
//                            PlayAnimNum = new int[] { 10, 11, 2, 13, 14 }; PlayAnim[PlayAnimNum[0]] = SlotTurn0[(SlotTurn[0] + 2) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[1]] = SlotTurn1[(SlotTurn[1] + 2) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[2]] = SlotTurn2[SlotTurn[2]].GetComponent<Animator>(); PlayAnim[PlayAnimNum[3]] = SlotTurn3[(SlotTurn[3] + 2) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[4]] = SlotTurn4[(SlotTurn[4] + 2) % 30].GetComponent<Animator>();
//                            for (int j = 0; j < MaxJ; j++) { PlayAnim[PlayAnimNum[j]].enabled = true; if (PhotonClient.newPhotonClient.islot3x5[10] != 10) PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[10]); else PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[11]); }
//                            if (MaxJ == 5) { if (PhotonClient.newPhotonClient.islot3x5[14] == 10 || PhotonClient.newPhotonClient.islot3x5[14] == 11 || PhotonClient.newPhotonClient.islot3x5[14] == 12) { PlayAnim[PlayAnimNum[4]].enabled = false; PlayAnim[PlayAnimNum[4]].SetInteger("SlotImage", -1); } }
//                            break;
//                        case 19:
//                            PlayAnimNum = new int[] { 0, 11, 12, 13, 4 }; PlayAnim[PlayAnimNum[0]] = SlotTurn0[SlotTurn[0]].GetComponent<Animator>(); PlayAnim[PlayAnimNum[1]] = SlotTurn1[(SlotTurn[1] + 2) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[2]] = SlotTurn2[(SlotTurn[2] + 2) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[3]] = SlotTurn3[(SlotTurn[3] + 2) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[4]] = SlotTurn4[SlotTurn[4]].GetComponent<Animator>();
//                            for (int j = 0; j < MaxJ; j++) { PlayAnim[PlayAnimNum[j]].enabled = true; if (PhotonClient.newPhotonClient.islot3x5[0] != 10) PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[0]); else PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[11]); }
//                            if (MaxJ == 5) { if (PhotonClient.newPhotonClient.islot3x5[4] == 10 || PhotonClient.newPhotonClient.islot3x5[4] == 11 || PhotonClient.newPhotonClient.islot3x5[4] == 12) { PlayAnim[PlayAnimNum[4]].enabled = false; PlayAnim[PlayAnimNum[4]].SetInteger("SlotImage", -1); } }
//                            break;
//                        case 20:
//                            PlayAnimNum = new int[] { 10, 1, 2, 3, 14 }; PlayAnim[PlayAnimNum[0]] = SlotTurn0[(SlotTurn[0] + 2) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[1]] = SlotTurn1[SlotTurn[1]].GetComponent<Animator>(); PlayAnim[PlayAnimNum[2]] = SlotTurn2[SlotTurn[2]].GetComponent<Animator>(); PlayAnim[PlayAnimNum[3]] = SlotTurn3[SlotTurn[3]].GetComponent<Animator>(); PlayAnim[PlayAnimNum[4]] = SlotTurn4[(SlotTurn[4] + 2) % 30].GetComponent<Animator>();
//                            for (int j = 0; j < MaxJ; j++) { PlayAnim[PlayAnimNum[j]].enabled = true; if (PhotonClient.newPhotonClient.islot3x5[10] != 10) PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[10]); else PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[1]); }
//                            if (MaxJ == 5) { if (PhotonClient.newPhotonClient.islot3x5[14] == 10 || PhotonClient.newPhotonClient.islot3x5[14] == 11 || PhotonClient.newPhotonClient.islot3x5[14] == 12) { PlayAnim[PlayAnimNum[4]].enabled = false; PlayAnim[PlayAnimNum[4]].SetInteger("SlotImage", -1); } }
//                            break;
//                        case 21:
//                            PlayAnimNum = new int[] { 5, 1, 12, 3, 9 }; PlayAnim[PlayAnimNum[0]] = SlotTurn0[(SlotTurn[0] + 1) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[1]] = SlotTurn1[SlotTurn[1]].GetComponent<Animator>(); PlayAnim[PlayAnimNum[2]] = SlotTurn2[(SlotTurn[2] + 2) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[3]] = SlotTurn3[SlotTurn[3]].GetComponent<Animator>(); PlayAnim[PlayAnimNum[4]] = SlotTurn4[(SlotTurn[4] + 1) % 30].GetComponent<Animator>();
//                            for (int j = 0; j < MaxJ; j++) { PlayAnim[PlayAnimNum[j]].enabled = true; if (PhotonClient.newPhotonClient.islot3x5[5] != 10) PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[5]); else PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[1]); }
//                            if (MaxJ == 5) { if (PhotonClient.newPhotonClient.islot3x5[9] == 10 || PhotonClient.newPhotonClient.islot3x5[9] == 11 || PhotonClient.newPhotonClient.islot3x5[9] == 12) { PlayAnim[PlayAnimNum[4]].enabled = false; PlayAnim[PlayAnimNum[4]].SetInteger("SlotImage", -1); } }
//                            break;
//                        case 22:
//                            PlayAnimNum = new int[] { 5, 11, 2, 13, 9 }; PlayAnim[PlayAnimNum[0]] = SlotTurn0[(SlotTurn[0] + 1) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[1]] = SlotTurn1[(SlotTurn[1] + 2) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[2]] = SlotTurn2[SlotTurn[2]].GetComponent<Animator>(); PlayAnim[PlayAnimNum[3]] = SlotTurn3[(SlotTurn[3] + 2) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[4]] = SlotTurn4[(SlotTurn[4] + 1) % 30].GetComponent<Animator>();
//                            for (int j = 0; j < MaxJ; j++) { PlayAnim[PlayAnimNum[j]].enabled = true; if (PhotonClient.newPhotonClient.islot3x5[5] != 10) PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[5]); else PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[11]); }
//                            if (MaxJ == 5) { if (PhotonClient.newPhotonClient.islot3x5[9] == 10 || PhotonClient.newPhotonClient.islot3x5[9] == 11 || PhotonClient.newPhotonClient.islot3x5[9] == 12) { PlayAnim[PlayAnimNum[4]].enabled = false; PlayAnim[PlayAnimNum[4]].SetInteger("SlotImage", -1); } }
//                            break;
//                        case 23:
//                            PlayAnimNum = new int[] { 0, 11, 2, 13, 4 }; PlayAnim[PlayAnimNum[0]] = SlotTurn0[SlotTurn[0]].GetComponent<Animator>(); PlayAnim[PlayAnimNum[1]] = SlotTurn1[(SlotTurn[1] + 2) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[2]] = SlotTurn2[SlotTurn[2]].GetComponent<Animator>(); PlayAnim[PlayAnimNum[3]] = SlotTurn3[(SlotTurn[3] + 2) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[4]] = SlotTurn4[SlotTurn[4]].GetComponent<Animator>();
//                            for (int j = 0; j < MaxJ; j++) { PlayAnim[PlayAnimNum[j]].enabled = true; if (PhotonClient.newPhotonClient.islot3x5[0] != 10) PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[0]); else PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[11]); }
//                            if (MaxJ == 5) { if (PhotonClient.newPhotonClient.islot3x5[4] == 10 || PhotonClient.newPhotonClient.islot3x5[4] == 11 || PhotonClient.newPhotonClient.islot3x5[4] == 12) { PlayAnim[PlayAnimNum[4]].enabled = false; PlayAnim[PlayAnimNum[4]].SetInteger("SlotImage", -1); } }
//                            break;
//                        case 24:
//                            PlayAnimNum = new int[] { 10, 1, 12, 3, 14 }; PlayAnim[PlayAnimNum[0]] = SlotTurn0[(SlotTurn[0] + 2) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[1]] = SlotTurn1[SlotTurn[1]].GetComponent<Animator>(); PlayAnim[PlayAnimNum[2]] = SlotTurn2[(SlotTurn[2] + 2) % 30].GetComponent<Animator>(); PlayAnim[PlayAnimNum[3]] = SlotTurn3[SlotTurn[3]].GetComponent<Animator>(); PlayAnim[PlayAnimNum[4]] = SlotTurn4[(SlotTurn[4] + 2) % 30].GetComponent<Animator>();
//                            for (int j = 0; j < MaxJ; j++) { PlayAnim[PlayAnimNum[j]].enabled = true; if (PhotonClient.newPhotonClient.islot3x5[10] != 10) PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[10]); else PlayAnim[PlayAnimNum[j]].SetInteger("SlotImage", PhotonClient.newPhotonClient.islot3x5[1]); }
//                            if (MaxJ == 5) { if (PhotonClient.newPhotonClient.islot3x5[14] == 10 || PhotonClient.newPhotonClient.islot3x5[14] == 11 || PhotonClient.newPhotonClient.islot3x5[14] == 12) { PlayAnim[PlayAnimNum[4]].enabled = false; PlayAnim[PlayAnimNum[4]].SetInteger("SlotImage", -1); } }
//                            break;
//                    }
//                }
//            }
//            if (time > PlayAnimWait)//等動畫播完
//            {
//                PlayAnim = new Animator[15] { SlotTurn0[SlotTurn[0]].GetComponent<Animator>(), SlotTurn1[SlotTurn[1]].GetComponent<Animator>(), SlotTurn2[SlotTurn[2]].GetComponent<Animator>(), SlotTurn3[SlotTurn[3]].GetComponent<Animator>(), SlotTurn4[SlotTurn[4]].GetComponent<Animator>(), SlotTurn0[(SlotTurn[0] + 1) % 30].GetComponent<Animator>(), SlotTurn1[(SlotTurn[1] + 1) % 30].GetComponent<Animator>(), SlotTurn2[(SlotTurn[2] + 1) % 30].GetComponent<Animator>(), SlotTurn3[(SlotTurn[3] + 1) % 30].GetComponent<Animator>(), SlotTurn4[(SlotTurn[4] + 1) % 30].GetComponent<Animator>(), SlotTurn0[(SlotTurn[0] + 2) % 30].GetComponent<Animator>(), SlotTurn1[(SlotTurn[1] + 2) % 30].GetComponent<Animator>(), SlotTurn2[(SlotTurn[2] + 2) % 30].GetComponent<Animator>(), SlotTurn3[(SlotTurn[3] + 2) % 30].GetComponent<Animator>(), SlotTurn4[(SlotTurn[4] + 2) % 30].GetComponent<Animator>() };
//                for (int i = 0; i < 25; i++) { Line[i].SetActive(false); } //線關掉
//                if (PrizeNum >= 0) { PlayPrizeAnimation(PrizeNum); }//大獎動畫
//                if (PlayBonusGame == true)//Bonus動畫
//                {
//                    Free_text.text = "免費";
//                    Bet_Btn.enabled = false;
//                    if (time < (PlayAnimWait + 0.8f))
//                    {
//                        if (time < (PlayAnimWait + 0.2f)) Stage_Sound.Play();
//                        LevelPanel.SetActive(true);//動畫
//                        LevelAnim[0].SetActive(true);//Bonus Game動畫
                        
//                    }
//                    if (time > (PlayAnimWait + 1.5f))//等動畫播完
//                    {
//                        CookGirl_BonusGame_Control.StartCountDown();//開始倒數
//                        BonusPanel.SetActive(true);//Bonus Game頁面
//                        FreeSpin_Square.SetActive(true);//特效框
//                        ChangeTurnImage();
//                        PlayBonusGame = false;
//                    }
//                }
//            }
//        }
//    }

//    public static void GetSlotInfo() { CanChangeSlotImage = true; }
//    public static void StartTurn()//開始轉
//    {
//        time = 0;
//        CanTurn = true;
//    }
//    public void ChangeTurnImage()//切換輪轉圖
//    {
//        for (int i = 0; i < 30; i++)
//        {
//            if (PhotonClient.newPhotonClient.iAllFG == 2)
//            {
//                if (CanTurn == false)
//                {
//                    SlotTurn0[i].sprite = SlotSprite[SlotTurnNum[4, 0, i]];
//                    SlotTurn1[i].sprite = SlotSprite[SlotTurnNum[4, 1, i]];
//                    SlotTurn2[i].sprite = SlotSprite[SlotTurnNum[4, 2, i]];
//                    SlotTurn3[i].sprite = SlotSprite[SlotTurnNum[4, 3, i]];
//                    SlotTurn4[i].sprite = SlotSprite[SlotTurnNum[4, 4, i]];
//                }
//            }else
//            {
//                if (PhotonClient.newPhotonClient.iLVNow == 0)
//                {
//                    if (PhotonClient.newPhotonClient.islot3x5[0] == 10)
//                    {
//                        SlotTurn0[i].sprite = SlotSprite[SlotTurnNum[3, 0, i]];
//                        SlotTurn1[i].sprite = SlotSprite[SlotTurnNum[3, 1, i]];
//                        SlotTurn2[i].sprite = SlotSprite[SlotTurnNum[3, 2, i]];
//                        SlotTurn3[i].sprite = SlotSprite[SlotTurnNum[3, 3, i]];
//                        SlotTurn4[i].sprite = SlotSprite[SlotTurnNum[3, 4, i]];
//                    }
//                    else
//                    {
//                        SlotTurn0[i].sprite = SlotSprite[SlotTurnNum[Random.Range(0, 3), 0, i]];
//                        SlotTurn1[i].sprite = SlotSprite[SlotTurnNum[Random.Range(0, 3), 1, i]];
//                        SlotTurn2[i].sprite = SlotSprite[SlotTurnNum[Random.Range(0, 3), 2, i]];
//                        SlotTurn3[i].sprite = SlotSprite[SlotTurnNum[Random.Range(0, 3), 3, i]];
//                        SlotTurn4[i].sprite = SlotSprite[SlotTurnNum[Random.Range(0, 3), 4, i]];
//                    }
//                }
//                else if (PhotonClient.newPhotonClient.iLVNow == 2)
//                {
//                    SlotTurn0[i].sprite = SlotSprite[SlotTurnNum[4, 0, i]];
//                    SlotTurn1[i].sprite = SlotSprite[SlotTurnNum[4, 1, i]];
//                    SlotTurn2[i].sprite = SlotSprite[SlotTurnNum[4, 2, i]];
//                    SlotTurn3[i].sprite = SlotSprite[SlotTurnNum[4, 3, i]];
//                    SlotTurn4[i].sprite = SlotSprite[SlotTurnNum[4, 4, i]];
//                }
//                else if (PhotonClient.newPhotonClient.iLVNow == 3)
//                {
//                    SlotTurn0[i].sprite = SlotSprite[SlotTurnNum[3, 0, i]];
//                    SlotTurn1[i].sprite = SlotSprite[SlotTurnNum[3, 1, i]];
//                    SlotTurn2[i].sprite = SlotSprite[SlotTurnNum[3, 2, i]];
//                    SlotTurn3[i].sprite = SlotSprite[SlotTurnNum[3, 3, i]];
//                    SlotTurn4[i].sprite = SlotSprite[SlotTurnNum[3, 4, i]];
//                }
//            }
//        }
//        ChangeFakeSlotImage = false;
//    }

//    public static void SpecialLevel(int Level, int LevelCount)// 全盤獎(0.沒有 1.JP 2Free 3上菜)
//    {
//        switch (Level)
//        {
//            case 1://JPWin
//                if (AutoPlay == true) { if (CanTurn == false) { Spin_Control.StopAuto = true; AutoPlay = false; } }
//                PrizeNum = 4;
//                break;
//            case 2://BonusGame
//                PlayBonusGame = true;
//                break;
//            case 3://Wild
//                PlayWildAnim = true;
//                break;
//        }
//    }
//    public static void PrizeAnimation(int GetMoney)//判斷是哪一個大獎
//    { 
//        if (GetMoney / Bet_Control.BetNum[Bet_Control.SwitchNum] >= 50) { PrizeNum = 3; }
//        else if (GetMoney / Bet_Control.BetNum[Bet_Control.SwitchNum] >= 30) { PrizeNum = 2; }
//        else if (GetMoney / Bet_Control.BetNum[Bet_Control.SwitchNum] >= 20) { PrizeNum = 1; }
//        else if (GetMoney / Bet_Control.BetNum[Bet_Control.SwitchNum] >= 10) { PrizeNum = 0; }
//    }
//    public void PlayPrizeAnimation(int i)//播大獎動畫
//    {
//        for (int j = 0; j < 5; j++){if (j != i) Prize[j].SetActive(false);}
//        if (i != 4) {StartCoroutine(Money_Str(PhotonClient.newPhotonClient.Line_Money));}//數值切換
//        else if (i == 4) {StartCoroutine(Money_Str(PhotonClient.newPhotonClient.JP_Money));}//數值切換
//        PrizePanel.SetActive(true);
//        Prize[i].SetActive(true);
//        Win_Sound.Play();
//        PrizeNum = -1;
//    }
//    private IEnumerator Money_Str(int GetMoney)
//    {
//        int i = 0;//顯示出來的數值
//        while (i < GetMoney)
//        {
//            if (i < GetMoney *0.7)  i = (int)(GetMoney * 0.7); 
//            else i=i+ (int)(GetMoney * 0.01);//顯示出來的數值
//            SetMoneyStr(i);//設定進度條資訊
//            yield return new WaitForEndOfFrame();//一幀一幀跑
//        }
//    }
//    void SetMoneyStr(int Money){Win_text.text = Money.ToString("#,##0");}
//}