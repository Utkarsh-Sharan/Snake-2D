using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodFood : FoodController
{
    // Start is called before the first frame update
    void Start()
    {
        RandomizeFoodPosition();
        StartCoroutine(ChangeFoodPosition());
    }

    private IEnumerator ChangeFoodPosition()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            RandomizeFoodPosition();
        }
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player1Controller>())
        {
            SoundManager.Instance.Play(Sounds.PLAYER_ATE_FOOD);

            RandomizeFoodPosition();
            player1Controller.CreateSnakeBody();

            if(Player1PowerupController.Plus5PowerupStatus == true)
            {
                scoreController.Player1ScoreController(+10);
            }
            else
            {
                scoreController.Player1ScoreController(+5);
            }
        }
        else if (other.gameObject.GetComponent<Player2Controller>())
        {
            SoundManager.Instance.Play(Sounds.PLAYER_ATE_FOOD);

            RandomizeFoodPosition();
            player2Controller.CreateSnakeBody();

            if (Player2PowerupController.Plus5PowerupStatus == true)
            {
                scoreController.Player2ScoreController(+10);
            }
            else
            {
                scoreController.Player2ScoreController(+5);
            }
        }
    }
}
