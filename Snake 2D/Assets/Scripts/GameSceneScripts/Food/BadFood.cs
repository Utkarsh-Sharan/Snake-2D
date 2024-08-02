using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadFood : FoodController
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
            playerController.DestroySnakeBody();
            scoreController.PlayerScoreController(-5);
        }
    }
}
