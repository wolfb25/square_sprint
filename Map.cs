using Godot;
using System;

public class Map : Node2D {
    Camera2D Cam;
    Label Starting;
    KinematicBody2D Player;
    int anyadcounter = 0;
    public static bool halott = false;
    public override void _Ready() {
        Cam = (Camera2D)GetNode("PlayerCamera");
        Player = (KinematicBody2D)GetNode("Player/PlayerBody");
        Starting = (Label)GetNode("StartLabel");
    }

    public override void _Process(float delta) {
        Cam.Position = new Vector2(Player.Position.x + 512, Cam.Position.y);
        if (halott && Input.IsActionJustPressed("respawn")) {
            // GD.Print("apád");
            halott = false;
            GetTree().ReloadCurrentScene();
            //Player.Position= new Vector2(168, 440);
            anyadcounter = 1;
            PlayerBody.started = true; 
        }
        // if (PlayerBody.started) Starting.Visible = false; 
    }
    void _Bokes(Node2D valami) {
           // GD.Print("anyá(i)d");
        if (++anyadcounter > 1) { 
            halott = true;
        }
    }
}
