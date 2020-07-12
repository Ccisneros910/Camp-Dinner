using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileManager : MonoBehaviour
{
    [SerializeField] private string[] ingredientList;
    [SerializeField] private int ingredientsToCollect;
    [SerializeField] public int IngredientsToCollect
    {
        get
        {
            return ingredientsToCollect;
        }
        set
        {
            ingredientsToCollect = value;
        }
    }

    [SerializeField] private Inventory inventory;
    [SerializeField] private UIHandlerRequests myUI;

    private Request request;

    private void Start()
    {
        MakeNewRequest();


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U)) MakeNewRequest();        
    }

    private void MakeNewRequest()
    {
        request = new Request();
        myUI.ConfigureRequest(request);


    }

    public string GetIngredient(int num)
    {
        return ingredientList[num];
    }

    

    public void PurgeItems(Inventory inventoryItems)
    {

        for (int j = 0; j < inventoryItems.GetLength(); ++j)
        {
            AddToList(inventoryItems.GetItem(j));
        }

        bool isComplete = CompleteItems();
        print("GOT ALL ITEMS: " + isComplete);

        //clear my pile
        if (isComplete)
        {
            inventory.ClearItems();
            MakeNewRequest();
        }
        inventoryItems.ClearItems();
        
    }

    public void CheckItems(Inventory inventoryItems)
    {
        for(int i = 0; i < ingredientsToCollect; ++i)
        {
           for(int j = 0; j < inventoryItems.GetLength(); ++j)
            {
                print("testing index: " + j);
                if (ingredientList[i] == inventoryItems.GetItemName(j))
                {
                    print("have item: " + ingredientList[i]);
                    AddToList(inventoryItems.GetItem(j));
                    inventoryItems.DropItem(j);
                }
                else
                {
                    print("don't have item: " + ingredientList[i]);
                }
            }
        }

        print("================done checking items");
    }

    void AddToList(GameObject item)
    {
        inventory.AddToInventory(item);
    }


    public int MarshCount = 0;
    public int BananCount = 0;
    public int SmoreCount = 0;
    public int MarshNeeded = 0;
    public int BananNeeded = 0;
    public int SmoreNeeded = 0;
    //I fucking hate this function 
    bool CompleteItems()
    {
        MarshCount = 0;
        BananCount = 0;
        SmoreCount = 0;
        MarshNeeded = 0;
        BananNeeded = 0;
        SmoreNeeded = 0; 

        for(int i = 0; i < inventory.GetLength(); ++i)
        {
            string name = inventory.GetItemName(i);
            if (name == Request.FoodTypes.Marshmellon.ToString())
            {
                MarshCount += 1;
            }else if(name == Request.FoodTypes.Bananadog.ToString())
            {
                BananCount += 1;
            }else if(name == Request.FoodTypes.Smorange.ToString())
            {
                SmoreCount += 1;
            }
        }

        for(int i = 0; i < 3; ++i)
        {
            Request.FoodTypes name = request.GetFood(i);
            if (name == Request.FoodTypes.Marshmellon)
            {
                MarshNeeded += 1;
            }else if(name == Request.FoodTypes.Bananadog)
            {
                BananNeeded += 1;
            }else if(name == Request.FoodTypes.Smorange)
            {
                SmoreNeeded += 1;
            }
        }

        if (BananNeeded <= BananCount && MarshNeeded <= MarshCount && SmoreNeeded <= SmoreCount)
        {
            return true;
        }

        return false;
    }
}
