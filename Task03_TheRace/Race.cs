using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TheRace
{
    public class Race
    {

        private List<Racer> data;

        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;

            data = new List<Racer>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count { get { return data.Count; } }


       
        public void Add(Racer racer)
        {
            if(data.Count < Capacity)
            {
                data.Add(racer);
            }
        }

        

        public bool Remove(string name)
        {
            Racer racerToRemove = data.FirstOrDefault(n => n.Name == name);
            if(racerToRemove == null)
            {
                return false;
            }

            data.Remove(racerToRemove);
            return true;
        }

       
        public Racer GetOldestRacer()
        {
            return data.OrderByDescending(n => n.Age).FirstOrDefault();
        }

        
        public Racer GetRacer(string name)
        {
            return data.FirstOrDefault(n => n.Name == name);
        }

       
        public Racer GetFastestRacer()
        {
            return data.OrderByDescending(n => n.Car.Speed).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder reportResult = new StringBuilder();

            reportResult.AppendLine($"Racers participating at {Name}:");

            foreach (Racer nextRacer in data)
            {
                reportResult.AppendLine($"Racer: {nextRacer.Name}, {nextRacer.Age} ({nextRacer.Country})");
            }

            return reportResult.ToString();

        }

    }
}
