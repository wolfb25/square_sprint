using Godot;
using System;

public class PlayerBody : KinematicBody2D {
   
    private static readonly float GRAVITY = 3000;
    public Vector2 velocity = new Vector2(0, 0);
    public static bool started = false;
    public override void _PhysicsProcess(float delta) {
        if (!Map.halott) {
            Vector2 force = new Vector2(0, GRAVITY);
            velocity += force * delta;
            velocity = MoveAndSlide(velocity, new Vector2(0, -1));
        }
        else velocity = Vector2.Zero;
        if (started) velocity.x = 300;
        if (!Map.halott && Input.IsActionPressed("space") && IsOnFloor()) {
            started = true;
            velocity.y = -800;
            MoveAndSlide(velocity, Vector2.Up);
        } 
        if (!Map.halott && started && !IsOnFloor() && !IsOnWall()) Rotation += 5 * delta;
        if (started && IsOnFloor()) if (Rotation != 0) Rotation = 0;
    }
	// void Spike_inside()
	// {
    //     GD.Print("Spike_");
	// }
}
    