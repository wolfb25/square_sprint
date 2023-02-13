using Godot;
using System;

public class Map : Node2D {
    Camera2D Cam;
    Label Ending, Ponting;
    Node2D Hatter;
    [Export] PackedScene Explo;
    KinematicBody2D Player;
	public static bool started = false;
    readonly int ENDSCORE = 260;
    int got_hit = 0;
    float score = 0;
    bool end = false;
    public static bool halott = false;
    public override void _Ready() {
        Cam = (Camera2D)GetNode("PlayerCamera");
        Player = (KinematicBody2D)GetNode("Player/PlayerBody");
        Ending = (Label)GetNode("EndLabel");
        Ponting = (Label)GetNode("PontLabel");
        Hatter = (Node2D)GetNode("BackgroundNode");
    }

    public override void _Process(float delta) {
        if (score >= ENDSCORE) {
            Cam.Position = new Vector2(Cam.Position.x, Cam.Position.y);
            Ponting.RectPosition = new Vector2(Ponting.RectPosition.x, 8);
            end = true;
            score = ENDSCORE;
            Hatter.Position = new Vector2(Hatter.Position.x, Hatter.Position.y);
        } else {
            Cam.Position = new Vector2(Player.Position.x + 512, Cam.Position.y);
            Ponting.RectPosition = new Vector2(Player.Position.x + 8, 8);
            Hatter.Position = new Vector2(Player.Position.x * 0.35f, Hatter.Position.y);
        }
        Ending.RectPosition = new Vector2(Player.Position.x - 250, Ending.RectPosition.y);
        if ((halott || end) && Input.IsActionJustPressed("respawn")) {
            halott = false; end = false;
            GetTree().ReloadCurrentScene();
            got_hit = 1;
            started = true; 
        }
        if (started && !halott) {
            Ponting.Text = Math.Round(score/ENDSCORE*100).ToString() + "%";
            score += 15 * delta;
        }
        // GD.Print(Player.GlobalPosition); 
    }
    void _Bokes(Node2D valami) { 
        if (++got_hit > 1) {
            Particles2D expeff = (Particles2D)Explo.Instance();
            expeff.Position = new Vector2(Player.GlobalPosition.x, Player.GlobalPosition.y);
            AddChild(expeff);
            GD.Print(expeff.Position, Player.Position);
            Player.Visible = false;
            halott = true;
        } 
    }
}
