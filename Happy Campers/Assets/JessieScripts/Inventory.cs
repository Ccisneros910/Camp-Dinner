using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<GameObject> collectibles;
    [SerializeField] private int currentIndex;
    [SerializeField] private int maxsize;

    public delegate void ChangeIndex(int num);
    public ChangeIndex changeIndex;

    // Start is called before the first frame update
    void Start()
    {
        collectibles = new List<GameObject>();
        if (maxsize <= 0) maxsize = 3;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(currentIndex > 0)
            {
                --currentIndex;
                changeIndex(-1);
            }
        }else if (Input.GetKeyDown(KeyCode.E))
        {
            if(currentIndex < GetLength() - 1)
            {
                ++currentIndex;
                changeIndex(1);
            }
        }
    }


    public void AddToInventory(GameObject collectible)
    {
        if(GetLength() + 1 > maxsize)
        {
            print("inventory full");
            return;
        }
        collectibles.Add(collectible);
        if(changeIndex != null)
        {
            changeIndex(0);
        }
        
    }

    public GameObject GetItem()
    {

        return collectibles[currentIndex];
    }

    public GameObject GetItem(int index)
    {

        return collectibles[index];
    }

    public string GetItemName(int index)
    {
        return collectibles[index].GetComponent<UsableItem>().GetName();
    }

    public List<GameObject> GetListOfItems()
    {
        return collectibles;
    }

    public int GetLength()
    {
        return collectibles.Count;
    }

    public int GetCurrentIndex()
    {
        return currentIndex;
    }

    public void DropItem()
    {
        if(currentIndex < 0 || currentIndex > GetLength() -1 )
        {
            print("Inventory empty. Nothing to drop");
            return;
        }
        DropItem(currentIndex);
    }

    public void DropItem(int index)
    {
        collectibles[index].GetComponent<IDroppable>()?.Drop();
        collectibles.RemoveAt(index);

        if(changeIndex != null)
        {
            changeIndex(0);
        }
        
    }

    public void ClearItems()
    {
        collectibles.Clear();

        if(changeIndex != null)
        {
            changeIndex(0);
        }
        
    }

}
