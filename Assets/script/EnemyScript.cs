using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public PlayerScript Player;

    public int chargeValue;

    public int maxValue;

    public bool barrier;

    public int randomValue;

    public Text ChargeText;

    public Image battlelog1;

    public Image battlelog2;

    public Image battlelog3;

    public Image battlelog4;

    public float logalfa1;

    public float logalfa2;

    public float logalfa3;

    public float logalfa4;

    public int playerHPvalue;

    public Text playerHP;



    // Start is called before the first frame update
    void Start()
    {
        playerHPvalue = 5;
        playerHP.text = playerHPvalue.ToString();

        logalfa1 = 0;
        battlelog1.color = new Color(255, 255, 255, logalfa1);

        logalfa2 = 0;
        battlelog2.color = new Color(255, 255, 255, logalfa2);

        logalfa3 = 0;
        battlelog3.color = new Color(255, 255, 255, logalfa3);

        logalfa4 = 0;
        battlelog4.color = new Color(255, 255, 255, logalfa4);
    }

    // Update is called once per frame
    void Update()
    {
        ChargeText.text = chargeValue.ToString();
        if(Player.PlayerTurn == false)
        {
            //敵の処理
            switch(chargeValue)
            {
                case 0:
                    randomValue = Random.Range(0, 2);
                    if (randomValue == 0)
                    {
                        Charge();
                    }
                    else if (randomValue == 1)
                    {
                        Barrier();
                    }
                    break;

                case 1:
                    randomValue = Random.Range(0, 2);
                    if(randomValue == 0)
                    {
                        Charge();
                    }
                    else if(randomValue == 1)
                    {
                        Barrier();
                    }
                    break;

                case 2:
                    randomValue = Random.Range(0, 3);
                    if (randomValue == 0)
                    {
                        Charge();
                    }
                    else if (randomValue == 1)
                    {
                        Barrier();
                    }
                    else if (randomValue == 2)
                    {
                        Fire();
                    }
                    break;
                case 3:
                    randomValue = Random.Range(0, 3);
                    if (randomValue == 0)
                    {
                        Charge();
                    }
                    else if (randomValue == 1)
                    {
                        Barrier();
                    }
                    else if (randomValue == 2)
                    {
                        Fire();
                    }
                    break;
                case 4:
                    randomValue = Random.Range(0, 3);
                    if (randomValue == 0)
                    {
                        Charge();
                    }
                    else if (randomValue == 1)
                    {
                        Barrier();
                    }
                    else if (randomValue == 2)
                    {
                        Fire();
                    }
                    break;
                case 5:
                    randomValue = Random.Range(0, 2);
                    if (randomValue == 0)
                    {
                        Barrier();
                    }
                    else if (randomValue == 1)
                    {
                        Fire();
                    }
                
                    break;
            }
        }
    }

    void Charge()
    {
        chargeValue++;
        
        logalfa2 = 0;
        battlelog2.color = new Color(255, 255, 255, logalfa2);

        logalfa3 = 0;
        battlelog3.color = new Color(255, 255, 255, logalfa3);

        logalfa4 = 0;
        battlelog4.color = new Color(255, 255, 255, logalfa4);

        logalfa1 = 255;
        battlelog1.color = new Color(255, 255, 255, logalfa1);
        if (Player.isFireing)
        {
            Debug.Log("Playerの勝ち");
            logalfa2 = 0;
            battlelog2.color = new Color(255, 255, 255, logalfa2);

            logalfa3 = 0;
            battlelog3.color = new Color(255, 255, 255, logalfa3);

            logalfa1 = 0;
            battlelog1.color = new Color(255, 255, 255, logalfa1);

            logalfa4 = 255;
            battlelog4.color = new Color(255, 255, 255, logalfa4);

        }
        TurnFinish();
    }

    void Fire()
    {
        chargeValue = chargeValue - 2;
        if(Player.barrier == true)
        {
            Debug.Log("Playerがファイアーを防いだ！");
                return;
        }
        else if(Player.isFireing == true)
        {
            Debug.Log("同時打ち");
        }
        else if(Player.barrier == false)
        {
            Debug.Log("Playeは攻撃を喰らった！！");
            playerHPvalue--;
            playerHP.text = playerHPvalue.ToString();

            logalfa2 = 0;
            battlelog2.color = new Color(255, 255, 255, logalfa2);

            logalfa1 = 0;
            battlelog1.color = new Color(255, 255, 255, logalfa1);

            logalfa4 = 0;
            battlelog4.color = new Color(255, 255, 255, logalfa4);

            logalfa3 = 255;
            battlelog3.color = new Color(255, 255, 255, logalfa3);

        }
        TurnFinish();
    }

    void Barrier()
    {
        logalfa1 = 0;
        battlelog1.color = new Color(255, 255, 255, logalfa1);

        logalfa3 = 0;
        battlelog3.color = new Color(255, 255, 255, logalfa3);

        logalfa4 = 0;
        battlelog4.color = new Color(255, 255, 255, logalfa4);

        logalfa2 = 255;
        battlelog2.color = new Color(255, 255, 255, logalfa2);

        if (Player.isFireing)
        {
            Debug.Log("Enemyがファイアーを防いだ！");
        }
        TurnFinish();
    }

    void TurnFinish()
    {
        Player.isFireing = false;
        Player.barrier = false;
        Player.PlayerTurn = true;

        for (int i = 0; i <= 2; i++)
        {
            Player.Buttons[i].SetActive(true);
        }
    }
}
