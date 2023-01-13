using Godot;

public class Colworld : Node2D
{
    Camera2D Kamera;
    KinematicBody2D Jatekos;

    public override void _Ready() {
        Kamera = (Camera2D)GetNode("playerkamera");
        Jatekos = (KinematicBody2D)GetNode("player");
    }
    public override void _Process(float delta) {
        Kamera.Position = new Vector2(Jatekos.Position.x, Jatekos.Position.y);
    }

    public void onPrincessBodyEntered(PhysicsBody2D body) {
        if (body.GetName().Equals("player")) {
            Label youWin = GetNode("youwin") as Label;
            youWin.Show();
        }
    }
}
