using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClashOfClans.Data;

namespace ClashOfClans
{
    public class MemberMapper
    {
        public List<MemberModel> MapToMemberModel(List<Member> members)
        {
            var memberModelList = new List<MemberModel>();

            foreach (var member in members)
            {
                memberModelList.Add(new MemberModel
                {
                    PlayerTag = member.PlayerTag,
                    Name = member.Name,
                    TownHallLevel = member.TownHallLevel,
                    WarStars = member.WarStars
                });
            }
            return memberModelList;
        }
        public List<Member> MapToMember(List<MemberModel> members)
        {
            var memberModelList = new List<Member>();

            foreach (var member in members)
            {
                memberModelList.Add(new Member
                {
                    PlayerTag = member.PlayerTag,
                    Name = member.Name,
                    TownHallLevel = member.TownHallLevel,
                    WarStars = member.WarStars
                });
            }
            return memberModelList;
        }
    }
}