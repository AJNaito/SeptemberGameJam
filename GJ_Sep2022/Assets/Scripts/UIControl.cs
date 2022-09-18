using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public Slider slide; 
    [SerializeField]
    private TextMeshProUGUI timerText;

    private int maxFoodCarry = 7;

    private int[] foodOrders = new int[7] {0,0,0,0,0,0,0};
    private int currentCount = 0;
    GameController gameController;

    public void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }
    public void Update()
    {
        if(getOrderCounter() == 0)
        {
            foreach(int i in foodOrders)
                putNewOrder(gameController.getRoomNumber());
        }

    }

    public int[] getFoodOrders()
    {
        return foodOrders;
    }

    public void updateTime(float curTime)
    {
        int minutes = Mathf.FloorToInt(curTime / 60);
        int seconds = Mathf.FloorToInt(curTime % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public void FoodbarProgress(float val)
    {
        slide.value = val;
    }

    public void putNewOrder(int roomNumber)
    {
        if (currentCount < 7)
        {
            foodOrders[currentCount] = roomNumber;

            FoodbarProgress((float)(currentCount + 1) / maxFoodCarry);

            currentCount++;
        }
    }

    public int getOrderCounter()
    {
        return currentCount;
    }

    public void orderFilled(int index)
    {
        if (currentCount > 0)
        {
            foodOrders[index] = 0;
            currentCount--;
        }
    }
}
