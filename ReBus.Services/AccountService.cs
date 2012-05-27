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
        private Account AuthenticateUser(string userName, string password, bool isTicketController)
        {
            using (var repository = new ReBusContainer())
            {
                return (from currentUser in repository.Accounts
                        where currentUser.Username == userName &&
                              currentUser.PasswordHash == password &&
                              currentUser.IsTicketController == isTicketController
                        select currentUser).FirstOrDefault<Account>();   
            }
        }

        public Account Authenticate(string userName, string password)
        {
            return AuthenticateUser(userName, password, false);
        }

        public Account GetAccount(Guid guid)
        {
            using (var db = new ReBusContainer())
            {
                return db.Accounts.SingleOrDefault(a => a.GUID == guid);
            }
        }

        public Account AuthenticateTicketController(string userName, string password)
        {
            return AuthenticateUser(userName, password, true);
        }

        public Account AddFunds(Account account, decimal amount)
        {
            using (var db = new ReBusContainer())
            {
                account = db.Accounts.Single(a => a.GUID == account.GUID);
                account.Credit += amount;
                return account;
            }
        }

        private bool UsernameIsUnique(string userName)
        {
            using (var repository = new ReBusContainer())
            {
                return (from currentUser in repository.Accounts
                        where currentUser.Username == userName
                        select currentUser).FirstOrDefault<Account>() == null;
                
            }
        }

        public Account Register(string userName, string password, string firstName, string lastName)
        {
            if (String.IsNullOrEmpty(userName) ||
                String.IsNullOrEmpty(password) ||
                String.IsNullOrEmpty(firstName) ||
                String.IsNullOrEmpty(lastName))
            {
                throw new NotAllFieldsFilledException();
            }

            if (!UsernameIsUnique(userName))
            {
                throw new UserAlreadyExistsException();
            }

            using (ReBusContainer repository = new ReBusContainer())
            {
                Account userAccount = new Account();

                userAccount.Username = userName;
                userAccount.PasswordHash = password;
                userAccount.FirstName = firstName;
                userAccount.LastName = lastName;
                userAccount.Credit = 0;

                repository.Accounts.AddObject(userAccount);
                repository.SaveChanges();

                return userAccount;
            }
        }

        public IEnumerable<Transaction> GetTransactionHistory(Account userAccount)
        {
            using (ReBusContainer repository = new ReBusContainer())
            {
                repository.AttachTo("Accounts", userAccount);
                repository.Refresh(RefreshMode.StoreWins, userAccount);

                return userAccount.Transactions;                
            }
        }
    }
}
