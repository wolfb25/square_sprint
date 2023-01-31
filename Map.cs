using Godot;
using System;

public class Map : Node2D {
    Camera2D Cam;
    Node2D Player;
    int anyadcounter = 0;
    public override void _Ready() {
        Cam = (Camera2D)GetNode("PlayerCamera");
        Player = (Node2D)GetNode("Player/PlayerBody");
    }

    public override void _Process(float delta) {
        Cam.Position = new Vector2(Player.Position.x + 512, Cam.Position.y);
    }
    void _Bokes(Node valami) {
        GD.Print("anyád");
        if (++anyadcounter > 1) GetTree().Paused = true;
    }
}
