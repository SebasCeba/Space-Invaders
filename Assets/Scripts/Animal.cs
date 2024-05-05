using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal 
{

    protected string name;
    protected int health; 

    public virtual void Sleep()
    {

    }

    public virtual void Move()
    {

    }

    public virtual void Eat()
    {

    }

    public Animal(string animalName)
    {
        name = animalName;
    }
}
