using Godot;
using System;

public partial class TileDamage : Node { 

    public float damage;

    public void setDamage(float damage) {
        this.damage = damage;
    }
    

    public void printTest(){
        GD.Print("Instanciou");
    }


    public void DamageCharacter(CharacterPhysics character){
        character.healthBar.takeDamage(damage);
    }

}