using Godot;
using System;

public class Map : Node2D {
    Camera2D Cam;
    Label Starting;
    Label Ponting;
    Label PBing;
    KinematicBody2D Player;
    int anyadcounter = 0;
    float score = 0;
    // float pb = 0;
    // string pbstring;
    public static bool halott = false;
    public override void _Ready() {
        Cam = (Camera2D)GetNode("PlayerCamera");
        Player = (KinematicBody2D)GetNode("Player/PlayerBody");
        Starting = (Label)GetNode("StartLabel");
        Ponting = (Label)GetNode("PontLabel");
        // PBing = (Label)GetNode("PBLabel");
    }

    public override void _Process(float delta) {
        if (score > 250) Cam.Position = new Vector2(helyix, helyiy); 
        Cam.Position = new Vector2(Player.Position.x + 512, Cam.Position.y);
        if (halott && Input.IsActionJustPressed("respawn")) {
            // GD.Print("apád");
            halott = false;
            GetTree().ReloadCurrentScene();
            //Player.Position= new Vector2(168, 440);
            anyadcounter = 1;
            PlayerBody.started = true; 
        }
        if (PlayerBody.started && !halott) {
            Ponting.Text = Math.Round(score).ToString();
            score += 15 * delta;
        }
        Ponting.RectPosition = new Vector2(Player.Position.x + 8, 8);
        // GD.Print(Player.Position.x);
       
        // if (score > pb) {
        //     pb = score;
        //     pbstring = Math.Round(pb).ToString();
        //     PBing.Text = "PB: " + pbstring;
        // }
        // PBing.RectPosition = new Vector2(Player.Position.x + 8, 59);
        // if (PlayerBody.started) Starting.Visible = false; 
    }
    void _Bokes(Node2D valami) {
           // GD.Print("anyá(i)d");
        if (++anyadcounter > 1) { 
            halott = true;
        }
    }
}
