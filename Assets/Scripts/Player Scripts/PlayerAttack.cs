using System;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private CharacterAnimation playerAnim;

    private void Awake()
    {
        playerAnim = GetComponentInChildren<CharacterAnimation>();
    }

    private void Update()
    {
        ComboAttacks();
    }

    void ComboAttacks()
    {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(Buttons.PUNCH_1_BUTTON))
        {
            playerAnim.Punch1();
        }

        if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(Buttons.KICK_1_BUTTON))
        {
            playerAnim.Kick1();
        }
    }
}