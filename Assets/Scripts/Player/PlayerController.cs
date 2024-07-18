using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Properties
    [Header("Components")]
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private InputActionAsset inputAsset;
    [SerializeField] private PlayerHealth health;
    [SerializeField] private PlayerDataSO SOProps;

    private readonly string actionMapName = "Player";
    private readonly string movementInputActionName = "Move";


    private InputActionMap input;
    private InputAction movementAction;

    private GameManager gameManager;

    private PlayerData Data;
    private Vector2 movementDirection;
    #endregion

    #region Methods
    #region Unity

    public void Init(GameManager gameManager)
    {
        this.gameManager = gameManager;
        Data = SOProps.Data;

        InitInputActions();
        movement.Init(Data.speed);
        health.Init(Data.health);
        movementAction.Enable();
    }
    public void DeInit()
    {
        movementAction.Disable();
    }

    private void Update()
    {
        movement.Move(movementDirection);
    }
    #endregion
    #region Private
    private void InitInputActions()
    {
        input = inputAsset.FindActionMap(actionMapName);
        movementAction = input.FindAction(movementInputActionName);

        movementAction.performed += (context) => { movementDirection = context.ReadValue<Vector2>(); };
        movementAction.canceled += (context) => { movementDirection = Vector2.zero; };
    }
    #endregion
    #endregion
}