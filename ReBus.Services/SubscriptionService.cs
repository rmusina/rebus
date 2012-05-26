using System;
using System.Collections.Generic;
using ReBus.Model;
using ReBus.Services.API;

namespace ReBus.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        /// <summary>
        /// Buy a new subscription for all the lines
        /// </summary>
        /// <param name="account">The account for which to buy the subscription</param>
        /// <returns></returns>
        public Subscription BuySubscription(Account account)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Buy a new subscription for all the lines
        /// </summary>
        /// <param name="account">The account for which to buy the subscription</param>
        /// <param name="startDate">The start date for the new subscription</param>
        /// <returns></returns>
        public Subscription BuySubscription(Account account, DateTime startDate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Buy a new subscription
        /// </summary>
        /// <param name="account">The account for which to buy the subscription</param>
        /// <param name="lines">The lines on which the subscription applies to</param>
        /// <returns></returns>
        public Subscription BuySubscription(Account account, IEnumerable<Line> lines)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Renew an existing subscription
        /// </summary>
        /// <param name="subscription">The subscription to renew</param>
        /// <returns></returns>
        public Subscription RenewSubscription(Subscription subscription)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Renew an existing subscription
        /// </summary>
        /// <param name="subscription">The subscription to renew</param>
        /// <param name="startDate">The start date from which to renew the subscription</param>
        /// <returns></returns>
        public Subscription RenewSubscription(Subscription subscription, DateTime startDate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the active subscription of a given account.
        /// </summary>
        /// <param name="account">The account for which to get the subscription</param>
        /// <returns></returns>
        public IEnumerable<Subscription> GetActiveSubscriptins(Account account)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all the subscriptions associated to an account.
        /// </summary>
        /// <param name="account">The account for which to get the subscriptions</param>
        /// <returns></returns>
        public IEnumerable<Subscription> GetHistory(Account account)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get latest subscriptions.
        /// </summary>
        /// <param name="account">The account for which to get the subscriptions</param>
        /// <param name="limit">The max number of subscriptions to fetch</param>
        /// <returns></returns>
        public IEnumerable<Subscription> GetHistory(Account account, int limit)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the subscriptions that have been added after a given date (used to refresh the list with new values).
        /// </summary>
        /// <param name="account">The account for which to get the subscriptions</param>
        /// <param name="after">The date of the last subscription the client has</param>
        /// <returns></returns>
        public IEnumerable<Subscription> GetHistory(Account account, DateTime after)
        {
            throw new NotImplementedException();
        }
    }
}