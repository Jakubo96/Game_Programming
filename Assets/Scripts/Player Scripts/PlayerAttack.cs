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
        if (Input.GetKeyDown(KeyCode.Z))
        {
            playerAnim.Punch_1();       
        }    
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            playerAnim.Kick_1();       
        }   
    }
}