using Player;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI numberOfJumpsTMP;
    [SerializeField] private TextMeshProUGUI numberOfSuccessfulShotsTMP;
    [SerializeField] private TextMeshProUGUI timeSinceStartTMP;

    [Space(20)]
    [SerializeField] private IntValue numberOfJumps;
    [SerializeField] private IntValue numberOfSuccessfulShots;

    [Space(20)]
    [SerializeField] private PlayerManager playerManager;

    private PlayerMovementInput inputActions;
    private float startTime;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        inputActions = new PlayerMovementInput();
        inputActions.Player.Enable();

        RestartGame();
    }

    private void OnEnable()
    {
        inputActions.Player.Reset.performed += (context) => RestartGame();
    }

    private void RestartGame()
    {
        playerManager.ResetPosition();
        startTime = (int)Time.time;
        numberOfJumps.Value = 0;
        numberOfSuccessfulShots.Value = 0;
    }

    private void Update()
    {
        numberOfJumpsTMP.text = numberOfJumps.Value.ToString();
        numberOfSuccessfulShotsTMP.text = numberOfSuccessfulShots.Value.ToString();
        timeSinceStartTMP.text = ((int)(Time.time - startTime)).ToString();
    }
}
