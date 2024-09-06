using api_ska.models;

namespace api_ska.services;

public class StaticStorageService
{
    public List<Account> accounts { get; set; }
    public int nextId { get; set; }

    public StaticStorageService()
    {
        accounts = new List<Account>
        {
            new Account { id = 1, amount = 1000, remark = "Initial balance", date = DateTime.Now },
            new Account { id = 2, amount = 2000, remark = "Initial balance", date = DateTime.Now },
            new Account { id = 3, amount = 3000, remark = "Initial balance", date = DateTime.Now },
            new Account { id = 4, amount = 4000, remark = "Initial balance", date = DateTime.Now },
            new Account { id = 5, amount = 5000, remark = "Initial balance", date = DateTime.Now }
        };
        nextId = 6;
    }
}