using ClashOfClans.Models;
using Newtonsoft.Json;

namespace ClashOfClans.ApiCalls
{
    public class Serialize
    {
        public string SerializeData(ClanListViewModel viewModel)
        {
            var members = JsonConvert.SerializeObject(viewModel);
            return members;
        }
    }
}