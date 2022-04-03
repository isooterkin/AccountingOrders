using AccountingOrders.ViewsModels;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace AccountingOrders.Views
{
    public partial class AddNewOrderWindow : Window
    {
        public AddNewOrderWindow()
        {
            InitializeComponent();

            DataContext = new DataManageVM();

            DataObject.AddPastingHandler(NumberTextBox, OnPaste);
        }

        #region Проверка ввода цифр
        private readonly Regex Regex = new ("[^0-9]+");
        private void NumberValidationTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text);
        }
        private void NumberValidationKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = (e.Key == Key.Space);
        }
        private void OnPaste(object sender, DataObjectPastingEventArgs e)
        {
            if (e.SourceDataObject.GetData(DataFormats.UnicodeText) is string text)
                if (Regex.IsMatch(text))
                {
                    DataObject NewData = new();
                    NewData.SetData(DataFormats.Text, "");
                    e.DataObject = NewData;
                }
        }
        #endregion
    }
}