using System;

namespace Psychometrics.Domain.Entities
{
    public class QAIndex
    {
        public Guid ItemID { get; set; }
        public string ItemCode { get; set; }
        public int NumberOfMarks { get; set; } = 1;
        public decimal AMSItemAngoffStandard { get; set; } = 0;
        public decimal FacilityIndex { get; set; } = 0;
        public decimal FacilityAndAngoffDifference { get; set; } = 0;
        public decimal DiscriminationIndex { get; set; } = 0;
        public decimal CorrectedItemTotalCorrelation { get; set; } = 0;
        public decimal CronbachAlphaIfItemDeleted { get; set; } = 0;
    }
} 