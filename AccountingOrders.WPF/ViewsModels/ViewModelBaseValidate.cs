using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

// Класс не дописан!!!
// Нужно реализовать проверку модели!!!

#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.

namespace AccountingOrders.WPF.ViewsModels
{
    public class ViewModelBaseValidate: ViewModelBase, INotifyDataErrorInfo
    {
        private readonly Dictionary<string, ICollection<string>> _validationErrors = new();

        protected void ValidateModel<T>(T model) where T : class
        {
            _validationErrors.Clear();
            ICollection<ValidationResult> validationResults = new List<ValidationResult>();
            if (!Validator.TryValidateObject(model, new ValidationContext(model, null, null), validationResults, true))
                foreach (ValidationResult validationResult in validationResults)
                {
                    string property = validationResult.MemberNames.ElementAt(0);
                    if (_validationErrors.ContainsKey(property)) _validationErrors[property].Add(validationResult.ErrorMessage);
                    else _validationErrors.Add(property, new List<string> { validationResult.ErrorMessage });
                }

            /* Вызывать для всех! (Реализовать!) */
            RaiseErrorsChanged("Username");
            RaiseErrorsChanged("Name");
        }

        protected void ValidateModelProperty<T>(object? value, string propertyName, T model) where T : class
        {
            if (_validationErrors.ContainsKey(propertyName)) _validationErrors.Remove(propertyName);

            ICollection<ValidationResult> validationResults = new List<ValidationResult>();

            ValidationContext validationContext = new(model, null, null) { MemberName = propertyName };

            if (!Validator.TryValidateProperty(value, validationContext, validationResults))
            {
                _validationErrors.Add(propertyName, new List<string>());
                foreach (ValidationResult validationResult in validationResults)
                    _validationErrors[propertyName].Add(validationResult.ErrorMessage);
            }

            RaiseErrorsChanged(propertyName);
        }

        #region INotifyDataErrorInfo
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        private void RaiseErrorsChanged(string propertyName) => ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));

        public IEnumerable GetErrors(string? propertyName) => string.IsNullOrEmpty(propertyName) == true || !_validationErrors.ContainsKey(propertyName) == true ? Enumerable.Empty<string>() : _validationErrors[propertyName];

        public bool HasErrors => _validationErrors.Count > 0;
        #endregion
    }
}