using System.Collections.Generic;

namespace Store.Contractors
{
    public abstract class Field
    {
        public string Label { get; }  // Метка поля

        public string Name { get; }  // Название поля

        public string Value { get; }  // Значение поля

        protected Field(string label, string name, string value)
        {
            Label = label;
            Name = name;
            Value = value;
        }
    }

    public class SelectionField : Field
    {
        public IReadOnlyDictionary<string, string> Items { get; }  // Словарь с элементами выбора

        public SelectionField(string label, string name, string value, IReadOnlyDictionary<string, string> items)
            : base(label, name, value)
        {
            Items = items;
        }
    }
}
