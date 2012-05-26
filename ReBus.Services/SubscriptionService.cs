using System;
using System.Collections.Generic;
using ReBus.Model;
using ReBus.Repository;
using ReBus.Services.API;
using System.Linq;

namespace ReBus.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        ReBusContainer db = new ReBusContainer();
        private static readonly List<Line> AllLines = new List<Line>();

        /// <summary>
        /// Buy a new subscription for all the lines
        /// </summary>
        /// <param name="account">The account for which to buy the subscription</param>
        /// <returns></returns>
        public Subscription BuySubscription(Account account)
        {
            return BuySubscription(account, AllLines);
        }

        /// <summary>
        /// Buy a new subscription for all the lines
        /// </summary>
        /// <param name="account">The account for which to buy the subscription</param>
        /// <param name="startDate">The start date for the new subscription</param>
        /// <returns></returns>
        public Subscription BuySubscription(Account account, DateTime startDate)
        {
            return BuySubscription(account, AllLines, startDate);
        }

        /// <summary>
        /// Buy a new subscription
        /// </summary>
        /// <param name="account">The account for which to buy the subscription</param>
        /// <param name="lines">The lines on which the subscription applies to</param>
        /// <returns></returns>
        public Subscription BuySubscription(Account account, IEnumerable<Line> lines)
        {
            return BuySubscription(account, lines, DateTime.Today);
        }

        /// <summary>
        /// Buy a new subscription
        /// </summary>
        /// <param name="account">The account for which to buy the subscription</param>
        /// <param name="lines">The lines on which the subscription applies to</param>
        /// <param name="startDate">The start date for the new subscription</param>
        /// <returns></returns>
        public Subscription BuySubscription(Account account, IEnumerable<Line> lines, DateTime startDate)
        {
            var subscription = new Subscription {
                Account =  account,
                Start = startDate.Date,
                End = startDate.Date + TimeSpan.FromDays(30),
                Lines = lines.ToList(),
                Created = DateTime.Today
            };

            using (var insertDb = new ReBusContainer())
            {
                insertDb.Subscriptions.AddObject(subscription);
                insertDb.SaveChanges();
            }

            return subscription;
        }

        /// <summary>
        /// Renew an existing subscription
        /// </summary>
        /// <param name="subscription">The subscription to renew</param>
        /// <returns></returns>
        public Subscription RenewSubscription(Subscription subscription)
        {
            var date = subscription.End;
            if (date.Date < DateTime.Today)
            {
                date = DateTime.Today;
            }
            return RenewSubscription(subscription, date);
        }

        /// <summary>
        /// Renew an existing subscription
        /// </summary>
        /// <param name="subscription">The subscription to renew</param>
        /// <param name="startDate">The start date from which to renew the subscription</param>
        /// <returns></returns>
        public Subscription RenewSubscription(Subscription subscription, DateTime startDate)
        {
            return BuySubscription(subscription.Account, subscription.Lines, startDate);
        }

        /// <summary>
        /// Get the active subscription of a given account.
        /// </summary>
        /// <param name="account">The account for which to get the subscription</param>
        /// <returns></returns>
        public IEnumerable<Subscription> GetActiveSubscriptins(Account account)
        {
            return db.Subscriptions
                .Where(s => s.Account == account)
                .Where(s => s.End >= DateTime.Today)
                .OrderBy(s => s.End).ToList();
        }

        /// <summary>
        /// Get all the subscriptions associated to an account.
        /// </summary>
        /// <param name="account">The account for which to get the subscriptions</param>
        /// <returns></returns>
        public IEnumerable<Subscription> GetHistory(Account account)
        {
            return GetHistory(account, Int32.MaxValue);
        }

        /// <summary>
        /// Get latest subscriptions.
        /// </summary>
        /// <param name="account">The account for which to get the subscriptions</param>
        /// <param name="limit">The max number of subscriptions to fetch</param>
        /// <returns></returns>
        public IEnumerable<Subscription> GetHistory(Account account, int limit)
        {
            return GetHistory(account, DateTime.MaxValue, limit);
        }

        /// <summary>
        /// Get older subscriptions.
        /// </summary>
        /// <param name="account">The account for which to get the subscriptions</param>
        /// <param name="before">The date before which to get the subscriptions</param>
        /// <param name="limit">The max number of subscriptions to fetch</param>
        /// <returns></returns>
        public IEnumerable<Subscription> GetHistory(Account account, DateTime before, int limit)
        {
            return db.Subscriptions
                .Where(s => s.Account == account)
                .Where(s => s.Created < before)
                .OrderByDescending(s => s.Created)
                .Take(limit).ToList();
        }

        /// <summary>
        /// Get the subscriptions that have been added after a given date (used to refresh the list with new values).
        /// </summary>
        /// <param name="account">The account for which to get the subscriptions</param>
        /// <param name="after">The date of the last subscription the client has</param>
        /// <returns></returns>
        public IEnumerable<Subscription> GetNewSubscriptions(Account account, DateTime after)
        {
            return db.Subscriptions
                .Where(s => s.Account == account)
                .Where(s => s.Created > after)
                .OrderByDescending(s => s.Created).ToList();
        }
    }
}