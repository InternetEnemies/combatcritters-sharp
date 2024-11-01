using CombatCrittersSharp.objects.card.Interfaces;
using CombatCrittersSharp.rest;
using CombatCrittersSharp.rest.payloads;
using CombatCrittersSharp.rest.routes;

namespace CombatCrittersSharp.objects.pack
{
    public class Pack : IPack
    {
        public string Image { get; private set; }
        public string Name { get; private set; }
        public int PackId { get; private set; }

        public List<ICard>? Contents { get; private set; } // Content is only set through SetContents
        private readonly IRest _rest;



        public Pack(string image, string name, int packId, IRest rest)
        {
            Image = image;
            Name = name;
            PackId = packId;
            _rest = rest;
            Contents = null;
        }

        //Static methos for instantiation from payloads
        public static Pack FromPackDetailsPayload(PackDetailsPayload payload, IRest rest)
        {
            return new Pack(payload.Image, payload.Name, payload.Packid, rest);
        }

        /// <summary>
        /// Sets the contents of this pack.
        /// </summary>
        /// <param name="contents"> The list of cards to set as content</param>
        public void SetContents(List<ICard> contents)
        {
            Contents = contents;
        }
    }
}