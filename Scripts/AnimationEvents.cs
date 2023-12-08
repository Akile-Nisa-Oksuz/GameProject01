using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public CharacterMovement charMove;
    public void PlayerAttack()
    {
        Debug.Log("Player Attacked");
        charMove.DoAttack();
    }

    public void PlayerDamage()
    {
        transform.GetComponentInParent<EnemyController>().DamgePlayer();
    }

    public void MoveSound()
    {
        LevelManager.instance.PlaySound(LevelManager.instance.levelSounds[0],LevelManager.instance.player.position);
    }
}
