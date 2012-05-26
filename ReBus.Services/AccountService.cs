using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReBus.Model;
using ReBus.Services.API;
using ReBus.Repository;
using System.Data.Objects;

namespace ReBus.Services
{
    public class AccountService : IAccountService
    {
        public Account Authenticate(string username, string password)
        {
            ReBusContainer repository = new ReBusContainer();

            return (from currentUser in repository.Accounts
                    where currentUser.Username == username &&
                          currentUser.PasswordHash == password
                    select currentUser).FirstOrDefault<Account>();
        }

        public string Register(string userName, string password, string firstName, string lastName)
        {
            if (String.IsNullOrEmpty(userName) ||
                String.IsNullOrEmpty(password) ||
                String.IsNullOrEmpty(firstName) ||
                String.IsNullOrEmpty(lastName))
            {
                return "Completati toate campurile";
            }

            using (ReBusContainer repository = new ReBusContainer())
            {
                Account userAccount = new Account();
                userAccount.GUID = new Guid();
                userAccount.Username = userName;
                userAccount.PasswordHash = password;
                userAccount.FirstName = firstName;
                userAccount.LastName = lastName;
                userAccount.Credit = 0;

                try
                {
                    repository.Accounts.AddObject(userAccount);
                    repository.SaveChanges();
                } 
                catch (Exception exc)
                {
                    return exc.Message;
                }
            }
                        
            return null;
        }

        public IEnumerable<Transaction> GetTransactionHistory(Account userAccount)
        {
            ReBusContainer repository = new ReBusContainer();            
            repository.Refresh(RefreshMode.StoreWins, userAccount);

            return userAccount.Transactions;
        }
    }
}
