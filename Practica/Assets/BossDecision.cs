using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDecision : MonoBehaviour
{
    public GameObject choiceBox;
    public Animator bossDeathAnimation;
    public GameObject boss;
    public Animator playerAttackAnimation;

    public KarmaData karma;

    public void DisableChoiceBox()
    {
        choiceBox.SetActive(false);
    }

    public void SetGoodKarma()
    {
        karma.PlayerGoodKarma += 0.5f;
        Destroy(boss.GetComponent<Rigidbody2D>());
        boss.GetComponent<Collider2D>().enabled = false;
    }

    public void SetBadKarma()
    {
        playerAttackAnimation.SetTrigger("isAttacking");
        Destroy(boss.GetComponent<Rigidbody2D>());
        boss.GetComponent<Collider2D>().enabled = false;
        bossDeathAnimation.speed = 1;
        karma.PlayerBadKarma += 0.5f;
    }
}
