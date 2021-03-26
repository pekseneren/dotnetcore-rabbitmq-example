using System;
using System.Collections.Generic;

namespace RabbitMQDev.Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = new string[] { "Excalibur", "Elucidator", "Blue Rose Sword", "Dark Repulser", "Night Sky Sword" };
            string[] stashCodes = new string[] { "item-stash-1", "item-stash-2" };

            List<Item> items = new List<Item>();

            Random rand = new Random();

            for (int i = 0; i < rand.Next(6); i++)
            {
                items.Add(new Item { Id = i, Level = rand.Next(100), Name = names[rand.Next(names.Length)], StashCode = stashCodes[rand.Next(stashCodes.Length)] });
            }

            RabbitMQProducer.SendItems(items);
        }
    }
}
