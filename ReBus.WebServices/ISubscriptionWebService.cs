using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ReBus.WebServices.WebServiceModel;

namespace ReBus.WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISubscriptionWebService" in both code and config file together.
    [ServiceContract]
    public interface ISubscriptionWebService
    {
        /// <summary>
        /// Buy a new subscription for all the lines
        /// </summary>
        /// <param name="account">The account for which to buy the subscription</param>
        /// <returns></returns>
        SubscriptionWebServiceModel BuySubscriptionForAllLines(AccountWebServiceModel account);

        /// <summary>
        /// Buy a new subscription for all the lines
        /// </summary>
        /// <param name="account">The account for which to buy the subscription</param>
        /// <param name="startDate">The start date for the new subscription</param>
        /// <returns></returns>
        SubscriptionWebServiceModel BuySubscriptionForAllLinesWithStartDate(AccountWebServiceModel account, DateTime startDate);

        /// <summary>
        /// Buy a new subscription
        /// </summary>
        /// <param name="account">The account for which to buy the subscription</param>
        /// <param name="lines">The lines on which the subscription applies to</param>
        /// <returns></returns>
        SubscriptionWebServiceModel BuySubscription(AccountWebServiceModel account, IEnumerable<LineWebServiceModel> lines);

        /// <summary>
        /// Buy a new subscription
        /// </summary>
        /// <param name="account">The account for which to buy the subscription</param>
        /// <param name="lines">The lines on which the subscription applies to</param>
        /// <param name="startDate">The start date for the new subscription</param>
        /// <returns></returns>
        SubscriptionWebServiceModel BuySubscriptionWithStartDate(AccountWebServiceModel account, IEnumerable<LineWebServiceModel> lines, DateTime startDate);

        /// <summary>
        /// Renew an existing subscription
        /// </summary>
        /// <param name="subscription">The subscription to renew</param>
        /// <returns></returns>
        SubscriptionWebServiceModel RenewSubscription(SubscriptionWebServiceModel subscription);

        /// <summary>
        /// Renew an existing subscription
        /// </summary>
        /// <param name="subscription">The subscription to renew</param>
        /// <param name="startDate">The start date from which to renew the subscription</param>
        /// <returns></returns>
        SubscriptionWebServiceModel RenewSubscriptionWithStartDate(SubscriptionWebServiceModel subscription, DateTime startDate);

        /// <summary>
        /// Get the active subscription of a given account.
        /// </summary>
        /// <param name="account">The account for which to get the subscription</param>
        /// <returns></returns>
        IEnumerable<SubscriptionWebServiceModel> GetActiveSubscriptins(AccountWebServiceModel account);

        /// <summary>
        /// Get all the subscriptions associated to an account.
        /// </summary>
        /// <param name="account">The account for which to get the subscriptions</param>
        /// <returns></returns>
        IEnumerable<SubscriptionWebServiceModel> GetHistory(AccountWebServiceModel account);

        /// <summary>
        /// Get latest subscriptions.
        /// </summary>
        /// <param name="account">The account for which to get the subscriptions</param>
        /// <param name="limit">The max number of subscriptions to fetch</param>
        /// <returns></returns>
        IEnumerable<SubscriptionWebServiceModel> GetHistoryWithLimit(AccountWebServiceModel account, int limit);

        /// <summary>
        /// Get older subscriptions.
        /// </summary>
        /// <param name="account">The account for which to get the subscriptions</param>
        /// <param name="before">The date before which to get the subscriptions</param>
        /// <param name="limit">The max number of subscriptions to fetch</param>
        /// <returns></returns>
        IEnumerable<SubscriptionWebServiceModel> GetNextHistoryWithLimit(AccountWebServiceModel account, DateTime before, int limit);

        /// <summary>
        /// Get the subscriptions that have been added after a given date (used to refresh the list with new values).
        /// </summary>
        /// <param name="account">The account for which to get the subscriptions</param>
        /// <param name="after">The date of the last subscription the client has</param>
        /// <returns></returns>
        IEnumerable<SubscriptionWebServiceModel> GetNewSubscriptions(AccountWebServiceModel account, DateTime after);
    }
}
