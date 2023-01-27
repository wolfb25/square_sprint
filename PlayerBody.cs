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
        if (started) velocity.x = 300;
        if (Input.IsActionPressed("space") && IsOnFloor()) {
            started = true;
            velocity.y = -800;
            MoveAndSlide(velocity, Vector2.Up);
        } 
        if (started && !IsOnFloor()) Rotation += 5 * delta;
        if (started && IsOnFloor()) {
            // if (Rotation >= 45) while (Rotation != 90) Rotation += 25 * delta;
            // if (Rotation < 45) while (Rotation != 0) Rotation -= 25 * delta;
            if (Rotation != 0) Rotation = 0;
        }
    }
	// void Spike_inside()
	// {
    //     GD.Print("Spike_");
	// }
}
    