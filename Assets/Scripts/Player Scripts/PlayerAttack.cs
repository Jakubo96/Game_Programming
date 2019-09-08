using UnityEngine;

public enum ComboState
{
    NONE,
    PUNCH_1,
    PUNCH_2,
    PUNCH_3,
    KICK_1,
    KICK_2
}

public class PlayerAttack : MonoBehaviour
{
    private CharacterAnimation playerAnim;

    private bool activateTimerToReset;

    public float defaultComboTimer = 0.4f;
    private float currentComboTimer;

    private ComboState currentComboState;

    private void Awake()
    {
        playerAnim = GetComponentInChildren<CharacterAnimation>();
    }

    private void Start()
    {
        currentComboTimer = defaultComboTimer;
        currentComboState = ComboState.NONE;
    }

    private void Update()
    {
        ComboAttacks();
        ResetComboState();
    }

    void ComboAttacks()
    {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(Buttons.PUNCH_1_BUTTON))
        {
            switch (currentComboState)
            {
                case ComboState.PUNCH_3:
                case ComboState.KICK_2:
                    return;
                case ComboState.KICK_1:
                    currentComboState = ComboState.NONE;
                    break;
                case ComboState.NONE:
                case ComboState.PUNCH_1:
                case ComboState.PUNCH_2:
                    ++currentComboState;
                    break;
            }

            StartComboCountdown();

            switch (currentComboState)
            {
                case ComboState.PUNCH_1:
                    playerAnim.Punch1();
                    break;
                case ComboState.PUNCH_2:
                    playerAnim.Punch2();
                    break;
                case ComboState.PUNCH_3:
                    playerAnim.Punch3();
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(Buttons.KICK_1_BUTTON))
        {
            switch (currentComboState)
            {
                case ComboState.KICK_2:
                case ComboState.PUNCH_3:
                    return;
                case ComboState.NONE:
                case ComboState.PUNCH_1:
                case ComboState.PUNCH_2:
                    currentComboState = ComboState.KICK_1;
                    break;
                case ComboState.KICK_1:
                    ++currentComboState;
                    break;
            }

            StartComboCountdown();

            switch (currentComboState)
            {
                case ComboState.KICK_1:
                    playerAnim.Kick1();
                    break;
                case ComboState.KICK_2:
                    playerAnim.Kick2();
                    break;
            }
        }
    }

    void ResetComboState()
    {
        if (activateTimerToReset)
        {
            currentComboTimer -= Time.deltaTime;

            if (currentComboTimer <= 0f)
            {
                currentComboState = ComboState.NONE;

                activateTimerToReset = false;
                currentComboTimer = defaultComboTimer;
            }
        }
    }

    void StartComboCountdown()
    {
        activateTimerToReset = true;
        currentComboTimer = defaultComboTimer;
    }
}