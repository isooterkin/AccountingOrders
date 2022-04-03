﻿using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AccountingOrders.EntityFramework.Converters
{
    public class DateOnlyConverter: ValueConverter<DateOnly, DateTime>
    {
        public DateOnlyConverter() : base(d => d.ToDateTime(TimeOnly.MinValue), d => DateOnly.FromDateTime(d)) { }
    }
}