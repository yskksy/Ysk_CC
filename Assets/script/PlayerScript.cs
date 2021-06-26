using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public EnemyScript Enemy;

    public bool PlayerTurn;

    public bool startYourturn;

    public Image startYourturnimage;

    public float alfa;

    public Image startEnemyimage;

    public int chargeValue;

    public int maxValue;

    public bool barrier;

    //ファイアーの同時打ちではない
    public bool isFireing;

    public GameObject[] Buttons;

    public Button FireButton;

    public Text ChargeText;

    public float timer;

    public AudioSource ChargeSond;
    public AudioSource FireSond;
    public AudioSource BarrierSond;

    // Start is called before the first frame update
    void Start()
    {
        chargeValue = 0;
        maxValue = 5;
        PlayerTurn = true;
        startYourturn = PlayerTurn;
       
    }

    // Update is called once per frame
    void Update()
    {
        ChargeText.text = chargeValue.ToString();
        if(chargeValue < 2)
        {
            FireButton.interactable = false;
        }
        else
        {
            FireButton.interactable = true;
        }
        if (startYourturn != PlayerTurn && PlayerTurn==true)
        {
            alfa +=0.1f;
            startYourturnimage.color=new Color(0, 0, 0, alfa);   
        }
        if (alfa > 254)
        {
            startYourturn = PlayerTurn;

        }
        if (startYourturn == PlayerTurn )
        {
            alfa -= 0.5f;
            startYourturnimage.color = new Color(0, 0, 0, alfa);
            if (alfa<0)
            {
                alfa = 0;
            }
        }
        
    }

    public void PushChargeButton()
    {
        chargeValue++;
        if(chargeValue > maxValue)
        {
            chargeValue = maxValue;
        }
        //ボタンを消す
        for (int i = 0; i <= 2; i++)
        {
            Buttons[i].SetActive(false);
        }
        ChargeSond.Play();
        Invoke("TurnOff",3.5f);
    }

    public void PushFireButton()
    {
        chargeValue = chargeValue - 2;
        isFireing = true;

        //if(Enemy.barrier == true)
        //{
        //    //バリアで防がれた
        //    return;
        //}
        //else if(Enemy.barrier == false)
        //{
        //    //ゲーム終了
        //    Debug.Log("Playerの勝ち");
        //}

        //ボタンを消す
        for (int i = 0; i <= 2; i++)
        {
            Buttons[i].SetActive(false);
        }
        FireSond.Play();
        Invoke("TurnOff",3.5f);
    }

    public void PushBarrierButton()
    {
        barrier = true;
        //ボタンを消す
        for (int i = 0; i <= 2; i++)
        {
            Buttons[i].SetActive(false);
        }
        BarrierSond.Play();
        Invoke("TurnOff",3.5f);
    }
    public void TurnOff()
    {
        PlayerTurn = false;
    }
}
