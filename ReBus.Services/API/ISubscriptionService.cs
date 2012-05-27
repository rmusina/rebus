using System;
using System.Collections.Generic;
using ReBus.Model;

namespace ReBus.Services.API
{
    public interface ISubscriptionService
    {
        /// <summary>
        /// Buy a new subscription for all the lines
        /// </summary>
        /// <param name="account">The account for which to buy the subscription</param>
        /// <returns></returns>
        Subscription BuySubscription(Account account);

        /// <summary>
        /// Buy a new subscription for all the lines
        /// </summary>
        /// <param name="account">The account for which to buy the subscription</param>
        /// <param name="startDate">The start date for the new subscription</param>
        /// <returns></returns>
        Subscription BuySubscription(Account account, DateTime startDate);

        /// <summary>
        /// Buy a new subscription
        /// </summary>
        /// <param name="account">The account for which to buy the subscription</param>
        /// <param name="lines">The lines on which the subscription applies to</param>
        /// <returns></returns>
        Subscription BuySubscription(Account account, IEnumerable<Line> lines);

        /// <summary>
        /// Buy a new subscription
        /// </summary>
        /// <param name="account">The account for which to buy the subscription</param>
        /// <param name="lines">The lines on which the subscription applies to</param>
        /// <param name="startDate">The start date for the new subscription</param>
        /// <returns></returns>
        Subscription BuySubscription(Account account, IEnumerable<Line> lines, DateTime startDate);

        /// <summary>
        /// Renew an existing subscription
        /// </summary>
        /// <param name="subscription">The subscription to renew</param>
        /// <returns></returns>
        Subscription RenewSubscription(Subscription subscription);

        /// <summary>
        /// Renew an existing subscription
        /// </summary>
        /// <param name="subscription">The subscription to renew</param>
        /// <param name="startDate">The start date from which to renew the subscription</param>
        /// <returns></returns>
        Subscription RenewSubscription( Subscription subscription, DateTime startDate);

        /// <summary>
        /// Get the active subscription of a given account.
        /// </summary>
        /// <param name="account">The account for which to get the subscription</param>
        /// <returns></returns>
        IEnumerable<Subscription> GetActiveSubscriptins(Account account);

        /// <summary>
        /// Get all the subscriptions associated to an account.
        /// </summary>
        /// <param name="account">The account for which to get the subscriptions</param>
        /// <returns></returns>
        IEnumerable<Subscription> GetHistory(Account account);

        /// <summary>
        /// Get latest subscriptions.
        /// </summary>
        /// <param name="account">The account for which to get the subscriptions</param>
        /// <param name="limit">The max number of subscriptions to fetch</param>
        /// <returns></returns>
        IEnumerable<Subscription> GetHistory(Account account, int limit);

        /// <summary>
        /// Get older subscriptions.
        /// </summary>
        /// <param name="account">The account for which to get the subscriptions</param>
        /// <param name="before">The date before which to get the subscriptions</param>
        /// <param name="limit">The max number of subscriptions to fetch</param>
        /// <returns></returns>
        IEnumerable<Subscription> GetHistory(Account account, DateTime before, int limit);

        /// <summary>
        /// Get the subscriptions that have been added after a given date (used to refresh the list with new values).
        /// </summary>
        /// <param name="account">The account for which to get the subscriptions</param>
        /// <param name="after">The date of the last subscription the client has</param>
        /// <returns></returns>
        IEnumerable<Subscription> GetNewSubscriptions(Account account, DateTime after);

        /// <summary>
        /// Returns a validation code saying if the ticket 
        /// </summary>
        /// <param name="account">The subscription you want to validate</param>
        /// <param name="after">The current logged in bus</param>
        /// <returns>0 - subscription expired, 1 - valid subscription, 2 - lines do not match warning, 3 - invalid</returns>
        int ValidateSubscription(Subscription subscription, Bus bus);
    }
}