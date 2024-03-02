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
using System.Windows.Shapes;

namespace KMA.ProgrammingInCSharp24
{
    /// <summary>
    /// Логика взаимодействия для MyBirthDatePicker.xaml
    /// </summary>
    public partial class MyBirthDatePicker : Window
    {
        public MyBirthDatePicker()
        {
            InitializeComponent();
        }
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime selectedDate = BirthDatePicker.SelectedDate.GetValueOrDefault();

            int age = CalculateAge(selectedDate);
            if (age < 0 || age > 135)
            {
                MessageBox.Show("Error! Please, enter your reall birth date!");
                return;
            }

            _Age.Text = $"You are {age} years old";

            if (IsBirthDay(selectedDate))
            {
                MessageBox.Show("Happy Birthday to you!!!");
            }

            string w_Zodiac = CalculateWesternZodiac(selectedDate);
            string c_Zodiac = CalculateChinaZodiac(selectedDate);

            _Western.Text = $"Western zodiac: {w_Zodiac}";
            _China.Text = $"China zodiac: {c_Zodiac}";
        }

        public bool IsBirthDay(DateTime birthDate)
        {
            DateTime currentDate = DateTime.Now;
            if (birthDate.Month == currentDate.Month && birthDate.Day == currentDate.Day)
                return true;
            return false;
        }
        public int CalculateAge(DateTime birthDate)
        {
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - birthDate.Year;

            if (currentDate.Month < birthDate.Month || (currentDate.Month == birthDate.Month && currentDate.Day < birthDate.Day))
            {
                age--;
            }

            return age;
        }

        public static string CalculateWesternZodiac(DateTime birthDate)
        {
            int month = birthDate.Month;
            int day = birthDate.Day;
            if ((month == 1 && day >= 21) || (month == 2 && day <= 19))
                return "Водолій";
            else if ((month == 2 && day >= 20) || (month == 3 && day <= 20))
                return "Риби";
            else if ((month == 3 && day >= 21) || (month == 4 && day <= 20))
                return "Овен";
            else if ((month == 4 && day >= 21) || (month == 5 && day <= 21))
                return "Телець";
            else if ((month == 5 && day >= 22) || (month == 6 && day <= 21))
                return "Близнюки";
            else if ((month == 6 && day >= 22) || (month == 7 && day <= 22))
                return "Рак";
            else if ((month == 7 && day >= 23) || (month == 8 && day <= 21))
                return "Лев";
            else if ((month == 8 && day >= 22) || (month == 9 && day <= 23))
                return "Діва";
            else if ((month == 9 && day >= 24) || (month == 10 && day <= 23))
                return "Терези";
            else if ((month == 10 && day >= 24) || (month == 11 && day <= 22))
                return "Скорпіон";
            else if ((month == 11 && day >= 23) || (month == 12 && day <= 22))
                return "Стрілець";
            else
                return "Козоріг";
        }

        public static string CalculateChinaZodiac(DateTime birthDate)
        {
            int year = birthDate.Year;
            string[] chineseZodiacs = { "Щур", "Бик", "Тигр", "Кролик", "Дракон", "Змія", "Кінь", "Коза", "Мавпа", "Півень", "Собака", "Свиня" };
            int index = (year - 4) % 12;

            if (index < 0)
                index += 12;

            return chineseZodiacs[index];
        }

        public void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
