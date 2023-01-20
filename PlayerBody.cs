using Godot;
using System;

public class PlayerBody : KinematicBody2D
{
   
    private static readonly float GRAVITY = 3000;
    private Vector2 velocity = new Vector2(0, 0);
    private bool started = false;
    public override void _PhysicsProcess(float delta) {
        Vector2 force = new Vector2(0, GRAVITY);
        velocity += force * delta;
        velocity = MoveAndSlide(velocity, new Vector2(0, -1));
        if (started) Position += new Vector2(250 * delta, 0);
        if (started && Input.IsActionPressed("space") && IsOnFloor()) {
            velocity.y = -800;
            MoveAndSlide(velocity, Vector2.Up);
        }
    }   

    public override void _Input(InputEvent esemeny) {
        if (!started && esemeny is InputEventKey space) started = true;
    }
}
