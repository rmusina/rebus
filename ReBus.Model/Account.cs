//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ReBus.Model
{
    public partial class Account
    {
        #region Primitive Properties
    
        public virtual System.Guid GUID
        {
            get;
            set;
        }
    
        public virtual string PasswordHash
        {
            get;
            set;
        }
    
        public virtual string FirstName
        {
            get;
            set;
        }
    
        public virtual string LastName
        {
            get;
            set;
        }
    
        public virtual decimal Credit
        {
            get;
            set;
        }
    
        public virtual string Username
        {
            get;
            set;
        }
    
        public virtual bool IsTicketController
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual ICollection<Transaction> Transactions
        {
            get
            {
                if (_transactions == null)
                {
                    var newCollection = new FixupCollection<Transaction>();
                    newCollection.CollectionChanged += FixupTransactions;
                    _transactions = newCollection;
                }
                return _transactions;
            }
            set
            {
                if (!ReferenceEquals(_transactions, value))
                {
                    var previousValue = _transactions as FixupCollection<Transaction>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupTransactions;
                    }
                    _transactions = value;
                    var newValue = value as FixupCollection<Transaction>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupTransactions;
                    }
                }
            }
        }
        private ICollection<Transaction> _transactions;
    
        public virtual ICollection<Ticket> Tickets
        {
            get
            {
                if (_tickets == null)
                {
                    var newCollection = new FixupCollection<Ticket>();
                    newCollection.CollectionChanged += FixupTickets;
                    _tickets = newCollection;
                }
                return _tickets;
            }
            set
            {
                if (!ReferenceEquals(_tickets, value))
                {
                    var previousValue = _tickets as FixupCollection<Ticket>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupTickets;
                    }
                    _tickets = value;
                    var newValue = value as FixupCollection<Ticket>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupTickets;
                    }
                }
            }
        }
        private ICollection<Ticket> _tickets;
    
        public virtual ICollection<Subscription> Subscriptions
        {
            get
            {
                if (_subscriptions == null)
                {
                    var newCollection = new FixupCollection<Subscription>();
                    newCollection.CollectionChanged += FixupSubscriptions;
                    _subscriptions = newCollection;
                }
                return _subscriptions;
            }
            set
            {
                if (!ReferenceEquals(_subscriptions, value))
                {
                    var previousValue = _subscriptions as FixupCollection<Subscription>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupSubscriptions;
                    }
                    _subscriptions = value;
                    var newValue = value as FixupCollection<Subscription>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupSubscriptions;
                    }
                }
            }
        }
        private ICollection<Subscription> _subscriptions;

        #endregion
        #region Association Fixup
    
        private void FixupTransactions(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Transaction item in e.NewItems)
                {
                    item.Account = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Transaction item in e.OldItems)
                {
                    if (ReferenceEquals(item.Account, this))
                    {
                        item.Account = null;
                    }
                }
            }
        }
    
        private void FixupTickets(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Ticket item in e.NewItems)
                {
                    item.Account = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Ticket item in e.OldItems)
                {
                    if (ReferenceEquals(item.Account, this))
                    {
                        item.Account = null;
                    }
                }
            }
        }
    
        private void FixupSubscriptions(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Subscription item in e.NewItems)
                {
                    item.Account = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Subscription item in e.OldItems)
                {
                    if (ReferenceEquals(item.Account, this))
                    {
                        item.Account = null;
                    }
                }
            }
        }

        #endregion
    }
}
