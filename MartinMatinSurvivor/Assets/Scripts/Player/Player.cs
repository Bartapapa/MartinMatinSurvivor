using KinematicCharacterController.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Player : MonoBehaviour
{
    [Header("Character Controller")]
    [SerializeField] private CharacterController _CC;
    [SerializeField] private Weapon _W;

    private Vector2 _movement = Vector2.zero;
    private bool _shootButtonPressed = false;

    private const string MouseXInput = "Mouse X";
    private const string MouseYInput = "Mouse Y";
    private const string MouseScrollInput = "Mouse ScrollWheel";
    private const string HorizontalInput = "Horizontal";
    private const string VerticalInput = "Vertical";

    private void Update()
    {
        if (_CC)
        {
            HandleCharacterInput();
        }
    }

    private void HandleCharacterInput()
    {
        PlayerCharacterInputs characterInputs = new PlayerCharacterInputs();

        // Build the CharacterInputs struct
        characterInputs.MoveAxisForward = Input.GetAxisRaw(VerticalInput);
        characterInputs.MoveAxisRight = Input.GetAxisRaw(HorizontalInput);
        characterInputs.ShootDown = Input.GetMouseButton(0);

        // Apply inputs to character
        _CC.SetInputs(ref characterInputs);
        _W.SetInput(characterInputs);
    }
}
