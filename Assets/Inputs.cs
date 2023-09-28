using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Inputs
{
    private static PlayerInputs _actions;
    private static PlayerController _owner;


    public static void BindNewPlayer(PlayerController player)
    {
        _owner = player;
    }
    public static void Init(PlayerController player)
    {
        _actions = new PlayerInputs();
        BindNewPlayer(player);

        //_actions.Player.Look.performed += ctx => _owner.setLook(ctx.ReadValue<Vector2>());
        _actions.Player.Movement.performed += ctx => _owner.Movement(ctx.ReadValue<Vector2>());
        _actions.Player.Interact.performed += ctx => _owner.Interact();
        _actions.Player.Crouch.started += ctx => _owner.startCrouch();
        _actions.Player.Crouch.canceled += ctx => _owner.endCrouch();
        PlayMode();
    }

    public static void PlayMode()
    {
        _actions.Player.Enable();
    }

}