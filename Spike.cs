using Godot;
using System;

public class Spike : Node2D
{
	[Signal]
	delegate void Bokes();
	public override void _Ready()
	{
	}
    void _on_SpikeArea_body_entered(Node test){
        EmitSignal("Bokes");
        GD.Print("Bökés!");
    }
}