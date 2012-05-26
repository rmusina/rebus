using System;
using System.Collections.Generic;
using System.Linq;
using ReBus.Model;
using ReBus.Services;
using ReBus.Services.API;
using ReBus.WebServices.WebServiceModel;

namespace ReBus.WebServices
{
    public class SubscriptionWebService : ISubscriptionWebService
    {
        readonly ISubscriptionService subscriptionService = new SubscriptionService();

        /// <summary>
        /// Buy a new subscription for all the lines
        /// </summary>
        /// <param name="account">The account for which to buy the subscription</param>
        /// <returns></returns>
        public SubscriptionWebServiceModel BuySubscriptionForAllLines(AccountWebServiceModel account)
        {
            var dmAccount = new Account {GUID = account.GUID};
            return SubscriptionWebServiceModel.FromDataModel(subscriptionService.BuySubscription(dmAccount));
        }

        /// <summary>
        /// Buy a new subscription for all the lines
        /// </summary>
        /// <param name="account">The account for which to buy the subscription</param>
        /// <param name="startDate">The start date for the new subscription</param>
        /// <returns></returns>
        public SubscriptionWebServiceModel BuySubscriptionForAllLinesWithStartDate(AccountWebServiceModel account, DateTime startDate)
        {
            var dmAccount = new Account { GUID = account.GUID };
            return SubscriptionWebServiceModel.FromDataModel(subscriptionService.BuySubscription(dmAccount, startDate));
        }

        /// <summary>
        /// Buy a new subscription
        /// </summary>
        /// <param name="account">The account for which to buy the subscription</param>
        /// <param name="lines">The lines on which the subscription applies to</param>
        /// <returns></returns>
        public SubscriptionWebServiceModel BuySubscription(AccountWebServiceModel account, IEnumerable<LineWebServiceModel> lines)
        {
            var dmAccount = new Account { GUID = account.GUID };
            var dmLines = lines.Select(l => new Line { GUID = l.GUID });
            return SubscriptionWebServiceModel.FromDataModel(subscriptionService.BuySubscription(dmAccount, dmLines));
        }

        /// <summary>
        /// Buy a new subscription
        /// </summary>
        /// <param name="account">The account for which to buy the subscription</param>
        /// <param name="lines">The lines on which the subscription applies to</param>
        /// <param name="startDate">The start date for the new subscription</param>
        /// <returns></returns>
        public SubscriptionWebServiceModel BuySubscriptionWithStartDate(AccountWebServiceModel account, IEnumerable<LineWebServiceModel> lines, DateTime startDate)
        {
            var dmAccount = new Account { GUID = account.GUID };
            var dmLines = lines.Select(l => new Line { GUID = l.GUID });
            return SubscriptionWebServiceModel.FromDataModel(subscriptionService.BuySubscription(dmAccount, dmLines, startDate));
        }

        /// <summary>
        /// Renew an existing subscription
        /// </summary>
        /// <param name="subscription">The subscription to renew</param>
        /// <returns></returns>
        public SubscriptionWebServiceModel RenewSubscription(SubscriptionWebServiceModel subscription)
        {
            var dmSubscription = new Subscription {GUID = subscription.GUID};
            return SubscriptionWebServiceModel.FromDataModel(subscriptionService.RenewSubscription(dmSubscription));
        }

        /// <summary>
        /// Renew an existing subscription
        /// </summary>
        /// <param name="subscription">The subscription to renew</param>
        /// <param name="startDate">The start date from which to renew the subscription</param>
        /// <returns></returns>
        public SubscriptionWebServiceModel RenewSubscriptionWithStartDate(SubscriptionWebServiceModel subscription, DateTime startDate)
        {
            var dmSubscription = new Subscription { GUID = subscription.GUID };
            return SubscriptionWebServiceModel.FromDataModel(subscriptionService.RenewSubscription(dmSubscription, startDate));
        }

        /// <summary>
        /// Get the active subscription of a given account.
        /// </summary>
        /// <param name="account">The account for which to get the subscription</param>
        /// <returns></returns>
        public IEnumerable<SubscriptionWebServiceModel> GetActiveSubscriptins(AccountWebServiceModel account)
        {
            var dmAccount = new Account { GUID = account.GUID };
            return subscriptionService.GetActiveSubscriptins(dmAccount)
                .Select(s => SubscriptionWebServiceModel.FromDataModel(s, account))
                .ToList();
        }

        /// <summary>
        /// Get all the subscriptions associated to an account.
        /// </summary>
        /// <param name="account">The account for which to get the subscriptions</param>
        /// <returns></returns>
        public IEnumerable<SubscriptionWebServiceModel> GetHistory(AccountWebServiceModel account)
        {
            var dmAccount = new Account { GUID = account.GUID };
            return subscriptionService.GetHistory(dmAccount)
                .Select(s => SubscriptionWebServiceModel.FromDataModel(s, account))
                .ToList();
        }

        /// <summary>
        /// Get latest subscriptions.
        /// </summary>
        /// <param name="account">The account for which to get the subscriptions</param>
        /// <param name="limit">The max number of subscriptions to fetch</param>
        /// <returns></returns>
        public IEnumerable<SubscriptionWebServiceModel> GetHistoryWithLimit(AccountWebServiceModel account, int limit)
        {
            var dmAccount = new Account { GUID = account.GUID };
            return subscriptionService.GetHistory(dmAccount, limit)
                .Select(s => SubscriptionWebServiceModel.FromDataModel(s, account))
                .ToList();
        }

        /// <summary>
        /// Get older subscriptions.
        /// </summary>
        /// <param name="account">The account for which to get the subscriptions</param>
        /// <param name="before">The date before which to get the subscriptions</param>
        /// <param name="limit">The max number of subscriptions to fetch</param>
        /// <returns></returns>
        public IEnumerable<SubscriptionWebServiceModel> GetNextHistoryWithLimit(AccountWebServiceModel account, DateTime before, int limit)
        {
            var dmAccount = new Account { GUID = account.GUID };
            return subscriptionService.GetHistory(dmAccount, before, limit)
                .Select(s => SubscriptionWebServiceModel.FromDataModel(s, account))
                .ToList();
        }

        /// <summary>
        /// Get the subscriptions that have been added after a given date (used to refresh the list with new values).
        /// </summary>
        /// <param name="account">The account for which to get the subscriptions</param>
        /// <param name="after">The date of the last subscription the client has</param>
        /// <returns></returns>
        public IEnumerable<SubscriptionWebServiceModel> GetNewSubscriptions(AccountWebServiceModel account, DateTime after)
        {
            var dmAccount = new Account { GUID = account.GUID };
            return subscriptionService.GetNewSubscriptions(dmAccount, after)
                .Select(s => SubscriptionWebServiceModel.FromDataModel(s, account))
                .ToList();
        }
    }
}
