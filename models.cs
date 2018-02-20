using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace models
{
    public class EventArgs
    {

        public EventArgs()
        {

        }

        public EventArgs(float damage, int id, int pointValue)
        {
            Damage = damage;
            Id = id;
            PointValue = PointValue;
        }

        public float Damage { get; set; }
        public int Id { get; set; }
        public int PointValue { get; set; }
    }


    public class Mana
    {

        public Mana()
        {
            RegenRate = defaultRegenRate;
            RegenAmount = defaultRegenAmount;
            Max = defaultMax;
        }

        public Mana(float max, float regenAmount, float regenRate)
        {
            Max = max;
            RegenAmount = regenAmount;
            RegenRate = regenRate;
        }

        float defaultMax = 20;

        //regen rate - lower value for more frequent regeneration
        float defaultRegenRate = 90;
        float defaultRegenAmount = 1.5F;





        public float Count;
        public float Max;

        //regen rate - lower value for more frequent regeneration
        float RegenRate;
        float RegenAmount;

        public bool spend(float amount)
        {
            if (Count >= amount)
            {
                Count -= amount;
                return true;
            }

            return false;
        }

        public void regen()
        {
            if (Time.frameCount % RegenRate == 0 && Count != Max)
            {
                Count += RegenAmount;
                if (Count > Max) Count = Max;

            }
        }
    }

    public class Health
    {
        public Health()
        {
            Count = defaultMax;
            RegenRate = defaultRegenRate;
            RegenAmount = defaultRegenAmount;
            Max = defaultMax;
        }

        public Health(float max, float resistance, float regenAmount, float regenRate)
        {
            Count = max;
            Max = max;
            Resistance = resistance;
            RegenAmount = regenAmount;
            RegenRate = regenRate;
        }

        float defaultMax = 20;
        float defaultRegenRate = 90;
        float defaultRegenAmount = 2F;
        float defaultResistance = 0;

        public bool Dead = false;



        public float Resistance { get; set; }
        public float Count { get; set; }
        public float Max { get; set; }

        //regen rate - lower value for more frequent regeneration
        float RegenRate;
        float RegenAmount;

        public bool spend(float amount)
        {
            amount = amount - Resistance;
            if (Count > amount)
            {
                Count -= amount;
                return true;
            }
            Dead = true;
            return false;
        }

        public void regen()
        {
            if (Time.frameCount % RegenRate == 0 && Count != Max)
            {
                Count += RegenAmount;
                if (Count > Max) Count = Max;
            }
        }

        public void respawn()
        {
            Count = Max;
            Dead = false;
        }

    }


}
