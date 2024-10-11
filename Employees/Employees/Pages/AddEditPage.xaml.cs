using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Employees.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {

        public AddEditPage()
        {
            InitializeComponent();
            init();
        }
        public void init()
        {
            RoleComboBox.ItemsSource = Data.EmplEntities.GetContext().Role.ToList();
            GenderComboBox.ItemsSource = Data.EmplEntities.GetContext().Gender.ToList();
            IdLabel.Visibility = Visibility.Hidden;
            IdTextBox.Visibility = Visibility.Hidden;

            
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.ListViewPage());
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder errors = new StringBuilder();
                if (string.IsNullOrEmpty(LastnameTextBox.Text))
                {
                    errors.AppendLine("Заполните фамилию");
                    return;
                }
                if (string.IsNullOrEmpty(FirstnameTextBox.Text))
                {
                    errors.AppendLine("Заполните имя");
                    return;
                }
                if (string.IsNullOrEmpty(PatronymicnameTextBox.Text))
                {
                    errors.AppendLine("Заполните отчество");
                    return;
                }
                if (string.IsNullOrEmpty(RoleComboBox.Text))
                {
                    errors.AppendLine("Выберите должность");
                    return;
                }
                if (string.IsNullOrEmpty(PhoneTextBox.Text))
                {
                    errors.AppendLine("Заполните номер телефона");
                    return;
                }
                if (string.IsNullOrEmpty(GenderComboBox.Text))
                {
                    errors.AppendLine("Выберите пол");
                    return;
                }
                if (string.IsNullOrEmpty(EmailTextBox.Text))
                {
                    errors.AppendLine("Заполните email");
                    return;
                }
                if (string.IsNullOrEmpty(PasswordTextBox.Password))
                {
                    errors.AppendLine("Заполните пароль");
                    return;
                }
                if (string.IsNullOrEmpty(ConfirmPasswordTextBox.Password))
                {
                    errors.AppendLine("Потвердите пароль");
                    return;
                }
                if (PasswordTextBox.Password != ConfirmPasswordTextBox.Password)
                {
                    errors.AppendLine("Паоли не совпадают!");
                    return;
                }
                if(errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            catch (Exception errors)
            {
                MessageBox.Show(errors.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
