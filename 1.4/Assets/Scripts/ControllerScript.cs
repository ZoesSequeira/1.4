using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
   
    int bronzeSupply = 0;
    int silverSupply = 2;
    int goldSupply = 0;
    bool spawnGold = false; //should we spawn a gold
    float mineNow;
    float miningSpeed = 3;
    public GameObject redPrefab;
    public GameObject silverPrefab;
    public GameObject goldPrefab;
    public Vector3 cubePosition;
    int xPos = 0;
   

    // Start is called before the first frame update
    void Start()
    {
        mineNow = miningSpeed;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > mineNow)
        {
            mineNow += miningSpeed;
           
            if (bronzeSupply < 2)
            {
                
                bronzeSupply++;
                cubePosition = new Vector3(xPos, 0, 0);
                Instantiate(redPrefab, cubePosition, Quaternion.identity);
                xPos+=2;
               if(bronzeSupply==2&&silverSupply==2)
                {
                    spawnGold = true;
                }
            }
           else if (spawnGold)
            {
                goldSupply++;
                spawnGold = false;
                cubePosition = new Vector3(xPos, 2, 0);
                Instantiate(goldPrefab, cubePosition, Quaternion.identity);
            }
            else 
            {
                silverSupply++;
                cubePosition = new Vector3(xPos, -2, 0);
                Instantiate(silverPrefab, cubePosition, Quaternion.identity);
                xPos-=2;
                if (bronzeSupply == 2 && silverSupply == 2)
                {
                    spawnGold = true;
                }
            }
            print("Bronze: " + bronzeSupply+"Silver: " + silverSupply+ "Gold: "+goldSupply);
        }

    }
}
