using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoBall : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public int player1Score = 0;
    public int player2Score = 0;
    // Start is called before the first frame update
    void Start()
    {
        Launch();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Launch()
    {
        float x = Random.Range(0,2) == 0 ? -1 : 1;
        float y = Random.Range(0,2) == 0 ? -1 : 1;
        GetComponent<Rigidbody> ().velocity = new Vector3(speed * x, speed * y, 0f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Goal1"))
        {
            Debug.Log("Player 2 Scored");
            player2Score++;
            Debug.Log("Player 1 Score: " + player1Score);
            Debug.Log("Player 2 Score: " + player2Score);
            if (player2Score == 3)
            {
                Debug.Log("Game Over, Left Paddle Wins");
                player1Score = 0;
                player2Score = 0;
            }
        }

        else if (collision.gameObject.CompareTag("Goal2"))
        {
            Debug.Log("Player 1 Scored");
            player1Score++;
            Debug.Log("Player 1 Score: " + player1Score);
            Debug.Log("Player 2 Score: " + player2Score);
            if (player1Score == 3)
            {
                Debug.Log("Game Over, Right Paddle Wins");
                player1Score = 0;
                player2Score = 0;
            }

        }
     }
}
