
#nullable enable

namespace Gradium
{
    /// <summary>
    /// Summary of credits for current billing period.
    /// </summary>
    public sealed partial class CreditsSummary
    {
        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("remaining_credits")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required int RemainingCredits { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("allocated_credits")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required int AllocatedCredits { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("billing_period")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string BillingPeriod { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("next_rollover_date")]
        public global::System.DateTime? NextRolloverDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("plan_name")]
        public string? PlanName { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CreditsSummary" /> class.
        /// </summary>
        /// <param name="remainingCredits"></param>
        /// <param name="allocatedCredits"></param>
        /// <param name="billingPeriod"></param>
        /// <param name="nextRolloverDate"></param>
        /// <param name="planName"></param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public CreditsSummary(
            int remainingCredits,
            int allocatedCredits,
            string billingPeriod,
            global::System.DateTime? nextRolloverDate,
            string? planName)
        {
            this.RemainingCredits = remainingCredits;
            this.AllocatedCredits = allocatedCredits;
            this.BillingPeriod = billingPeriod ?? throw new global::System.ArgumentNullException(nameof(billingPeriod));
            this.NextRolloverDate = nextRolloverDate;
            this.PlanName = planName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreditsSummary" /> class.
        /// </summary>
        public CreditsSummary()
        {
        }
    }
}