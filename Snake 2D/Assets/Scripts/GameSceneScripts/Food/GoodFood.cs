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
        if (other.gameObject.GetComponent<PlayerController>())
        {
            SoundManager.Instance.Play(Sounds.PLAYER_ATE_FOOD);

            RandomizeFoodPosition();
            playerController.CreateSnakeBody();

            if(PlayerPowerupController.Plus5PowerupStatus == true)
            {
                scoreController.PlayerScoreController(+10);
            }
            else
            {
                scoreController.PlayerScoreController(+5);
            }
        }
    }
}
