using Godot;
using System;

public class PlayerBody : KinematicBody2D {
    Vector2 velocity = new Vector2();
	readonly Vector2 FORCE = new Vector2(0, 3000);
    public override void _PhysicsProcess(float delta) {
        if (!Map.halott) velocity = MoveAndSlide(velocity += FORCE * delta, new Vector2(0, -1));
        else velocity = Vector2.Zero;
        if (Map.started && !Map.halott && !IsOnFloor() && !IsOnWall()) Rotation += 5 * delta;
        if (Map.started && IsOnFloor() && Rotation != 0) Rotation = 0;
        if (Map.started) velocity.x = 300;
        if (!Map.halott && Input.IsActionPressed("space") && IsOnFloor()) {
            Map.started = true;
            velocity.y = -800;
            MoveAndSlide(velocity, Vector2.Up);
        } 
    }
}