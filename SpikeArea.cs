using Godot;
using System;

public class SpikeArea : Area2D {
    public override void _Ready() {
        
    }

    public void Spike_inside() {
        EmitSignal("InMe");
    }
}
