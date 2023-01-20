using Godot;
using System;

public class PlayerBody : KinematicBody2D
{
   
    private static readonly float GRAVITY = 500;
    private Vector2 velocity = new Vector2(0, 0);
    private static readonly float WALK_FORCE = 600;
    private bool started = false;
    public override void _PhysicsProcess(float delta) {
        Vector2 force = new Vector2(0, GRAVITY);
        velocity += force * delta;
        velocity = MoveAndSlide(velocity, new Vector2(0, -1));
        if (started) Position += new Vector2(150 * delta, 0);
        // if (started && Input.IsActionPressed("space")) Position += new Vector2(Position.x,-20); // szar ahogy van
    }

    public override void _Input(InputEvent esemeny) {
        if (!started && esemeny is InputEventKey space) started = true;
    }
}
