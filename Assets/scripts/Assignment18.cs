using System;
using UnityEngine;

namespace Assignment18
{
    public struct Position
    {
        float X, Y, Z;

        public Position(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public void PrintPosition()
        {
            Debug.Log("Position: { " + "X = " + X + ", " + "Y = " + Y + ", " + "Z = " + Z + " }");
        }
    }

    public class Character
    {
        public string name;
        private int health;
        protected Position position;

        public int Health
        {
            get { return health; }
            set
            {
                if (value > 100)
                    health = 100;
                else if (value < 0)
                    health = 0;
                else
                    health = value;
            }
        }

        public Character(string name, int health, Position position)
        {
            this.name = name;
            Health = health;
            this.position = position;
        }

        public Character() : this("No Name", 100, new Position(0, 0, 0)) { }

        public virtual void DisplayInfo()
        {
            Debug.Log("Name: " + name + ", " + "Health: " + Health + ", ");
            position.PrintPosition();
        }

        public void Attack(int damage, Character target)
        {
            target.Health -= damage;
        }

        public void Attack(int damage, Character target, string attackType)
        {
            Debug.Log("Attack type: " + attackType);
            Attack(damage, target);
        }

        public class Soldier : Character
        {
            public Soldier(string name, int health, Position position) : base(name, health, position) { }
            public Soldier() : base() { }

            public override void DisplayInfo()
            {
                Debug.Log("Soldier");
                base.DisplayInfo();
            }
        }

        public class Officer : Character
        {
            public Officer(string name, int health, Position position) : base(name, health, position) { }

            public override void DisplayInfo()
            {
                Debug.Log("Officer");
                base.DisplayInfo();
            }
        }
    }

    public class CharacterTest : MonoBehaviour
    {
        void Start()
        {
            Character[] characters = new Character[2];
            characters[0] = new Character.Soldier();
            characters[1] = new Character.Officer("Yousef", 80, new Position(5, 2, 10));

            for (int i = 0; i < characters.Length; i++)
            {
                characters[i].DisplayInfo();
            }

            Debug.Log("Health before attack: " + characters[0].Health);
            characters[1].Attack(10, characters[0], "shooting");
            Debug.Log("Health after attack: " + characters[0].Health);
        }
    }
}
