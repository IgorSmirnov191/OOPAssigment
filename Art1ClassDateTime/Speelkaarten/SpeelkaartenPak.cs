using System.Collections.Generic;

namespace Speelkaarten
{
    internal class SpeelkaartenPak
    {
        private List<Speelkaart> pak;

        public SpeelkaartenPak()
        {
            pak = new List<Speelkaart>();
        }

        public int Count
        { get { return pak.Count; } }

        public int AddCard(Speelkaart kaart)
        {
            pak.Add(kaart);
            return Count;
        }

        public Speelkaart TakeCard(int index)
        {
            Speelkaart temp = pak[index];
            pak.Remove(temp);
            return temp;
        }
    }
}