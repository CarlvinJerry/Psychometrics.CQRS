using System;
using System.Collections.Generic;

namespace Psychometrics.Domain.Entities
{
    public class PivotTableClass
    {
        public int StudentId { get; set; }

        public List<ItemGroupCode> itemGroupCodes { get; set; } = new List<ItemGroupCode>();
        public List<ItemGroupCodeAggregate> itemGroupCodesAggregate { get; set; } = new List<ItemGroupCodeAggregate>();

        public List<ItemSubGroupCodeAggregate> itemSubGroupCodesAggregate { get; set; } = new List<ItemSubGroupCodeAggregate>();
        public decimal RAW { get; set; }
        public decimal Score { get; set; }
        public int Decile { get; set; }
        public string? DecileRank { get; set; }
        public string? Outcome { get; set; }

        public decimal MARK { get; set; }
    }

    public class ItemGroupCode
    {
        public string ItemGroupCodeName { get; set; }
        public List<ItemSubGroupCode> itemSubGroupCodes { get; set; } = new List<ItemSubGroupCode>();
    }

    public class ItemSubGroupCode
    {
        public string ItemSubGroupCodeName { get; set; }
        public decimal ResponseValue { get; set; }
    }

    public class ItemGroupCodeAggregate
    {
        public string ItemSubGroupCodeAggregateName { get; set; }
        public decimal ResponseValue { get; set; }
    }

    public class ItemSubGroupCodeAggregate
    {
        public string ItemGroupCodeAggregateName { get; set; }
        public decimal ResponseValue { get; set; }
    }
} 