using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp9АРКАНОИД_ФИНАЛ
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        /// 

        //строка подключения к БД
        public static string st_connect = @"Data Source=VIKTPOR-PK\MSSQLSERVER1;Initial Catalog=ARCANOID;Integrated Security=True";
        //переменная для хранения id авторизировшегося пользователя
        public static int id_user;
        //переменая для хранения типа пользователя, который сечас атворизован
        public static bool type_user = false;

        public static int Id;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AUTHORISATION());
        }
    }
}
