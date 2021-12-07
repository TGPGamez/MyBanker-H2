using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker_H2.OldLib
{
    public class Person
    {
        public string Name { get; private set; }
        public int Age { get; private set; }

        public Card Card { get; private set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void SetCard(Card card)
        {
            Card = card;
        }
    }
}
