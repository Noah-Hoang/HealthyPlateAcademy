using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    public int playerOneScore;
    public int playerTwoScore;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LeftBound"))
        {
            playerOneScore += 1;
        }

        else if (other.CompareTag("RightBound"))
        {
            playerTwoScore += 1;    
        }
    }
}
