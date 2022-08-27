using UnityEngine;

public class GoldLoot : MonoBehaviour
{
    public GameObject prefab;
    public int count;
    

    public void DropGold(Vector3 pos)
    {
        var dropGold = Instantiate(prefab);
        dropGold.transform.tag = "Loot";
        count = Random.Range(30, 100);
        dropGold.transform.position = pos;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
