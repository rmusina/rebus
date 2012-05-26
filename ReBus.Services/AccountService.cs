﻿using System;
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
        public Account Authenticate(string userName, string password)
        {
            ReBusContainer repository = new ReBusContainer();

            return (from currentUser in repository.Accounts
                    where currentUser.Username == userName &&
                          currentUser.PasswordHash == password
                    select currentUser).FirstOrDefault<Account>();
        }

        private bool UsernameIsUnique(string userName)
        {
            ReBusContainer repository = new ReBusContainer();

            return (from currentUser in repository.Accounts
                    where currentUser.Username == userName
                    select currentUser).FirstOrDefault<Account>() == null;
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
            ReBusContainer repository = new ReBusContainer();

            repository.AttachTo("Accounts", userAccount);
            repository.Refresh(RefreshMode.StoreWins, userAccount);

            return userAccount.Transactions;
        }
    }
}
