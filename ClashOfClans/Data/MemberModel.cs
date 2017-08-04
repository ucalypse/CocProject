using System.Collections;
using System.Collections.Generic;

namespace ClashOfClans.Data
{
    public class MemberModel : IEnumerable<Member>
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string ClanTag { get; set; }
        public int WarStars { get; set; }
        public int TownHallLevel { get; set; }
        public IEnumerator<Member> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}