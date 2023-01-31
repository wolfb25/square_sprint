using Godot;
using System;

public class Map : Node2D {
    Camera2D Cam;
    KinematicBody2D Player;
    int anyadcounter = 0;
    bool halott = false;
    public override void _Ready() {
        Cam = (Camera2D)GetNode("PlayerCamera");
        Player = (KinematicBody2D)GetNode("Player/PlayerBody");
    }

    public override void _Process(float delta) {
        Cam.Position = new Vector2(Player.Position.x + 512, Cam.Position.y);
        if (halott && Input.IsActionPressed("respawn")) {
            anyadcounter = 0;
            halott = false;
            GetTree().Paused = false;
            GetTree().ReloadCurrentScene();
        }
    }
    void _Bokes(Node2D valami) {
            GD.Print("anyá(i)d");
        if (++anyadcounter > 1) { 
            GetTree().Paused = true;
            halott = true;
        }
    }
}
