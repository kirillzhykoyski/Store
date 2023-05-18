using System;
using System.Collections.Generic;

namespace Store
{
    public class OrderDelivery
    {
        /// Уникальный код доставки.
        public string UniqueCode { get; }

        /// Описание доставки.
        public string Description { get; }

        /// Стоимость доставки.
        public decimal Price { get; }

        
        /// Параметры доставки.
        public IReadOnlyDictionary<string, string> Parameters { get; }

        public OrderDelivery(string uniqueCode,
                             string description,
                             decimal amount,
                             IReadOnlyDictionary<string, string> parameters)
        {
            if (string.IsNullOrWhiteSpace(uniqueCode))
                throw new ArgumentException(nameof(uniqueCode));

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException(nameof(description));

            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters));

            UniqueCode = uniqueCode;
            Description = description;
            Price = amount;
            Parameters = parameters;
        }
    }
}
