using Godot;
using System;

public class PlayerBody : KinematicBody2D
{
   
    private static readonly float GRAVITY = 3000;
    private Vector2 velocity = new Vector2(0, 0);
    private bool started = false;
    private bool space_on = false, spacestate_prev = false, spacestate_cur = false;
    public override void _PhysicsProcess(float delta) {
        Vector2 force = new Vector2(0, GRAVITY);
        velocity += force * delta;
        velocity = MoveAndSlide(velocity, new Vector2(0, -1));
        if (started) Position += new Vector2(250 * delta, 0);
        if (started && space_on && IsOnFloor()) {
            velocity.y = -800;
            MoveAndSlide(velocity, Vector2.Up);
        }
        if (spacestate_prev != spacestate_cur) {
            if (space_on) space_on = false;
            else space_on = true;
        }
        spacestate_prev = spacestate_cur;
        GD.Print(space_on);
    }   

    public override void _Input(InputEvent esemeny) {
        if (esemeny is InputEventKey gomb) {
            if (gomb.Unicode == 64) { //ezt kell megoldani még
                if (!started) started = true;
                spacestate_cur = true;
            }
            else spacestate_cur= false;
        }

    }
}
