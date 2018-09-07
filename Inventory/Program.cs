using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.DAL.Model;
using Inventory.DAL;
using Inventory.Modul;
using System.Xml;

namespace Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();

        }
        public static void Menu()
        {
            bool inProgress = true;
            while (inProgress)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(new string('-', 50));
                Console.WriteLine("\t\tВыберите пункт меню:");
                Console.WriteLine(new string('-', 50));
                Console.WriteLine("1. Отобразить всех сотрудников");
                Console.WriteLine("2. Принять на работу нового сотрудника");
                Console.WriteLine("3. Уволить сотрудника");
                Console.WriteLine("4. Найти сотрудника по имени");
                Console.WriteLine("5. Отобразить статистику");
                Console.WriteLine("6. Выход");
                Console.ForegroundColor = color;

                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        {
                            Console.WriteLine(new string('-', 50));
                            Console.WriteLine("\t\t1. Отобразить всех сотрудников");
                            Console.WriteLine(new string('-', 50));
                            Console.WriteLine(new string('-', 50));
                            XmlDocument doc = new XmlDocument();
                            doc.Load("Users.xml");
                            XmlElement xmlElement = doc.DocumentElement;
                            AddToXML.PrinterItem(xmlElement);
                                                  
                        }
                        break;

                    case 2:
                        {
                            Console.WriteLine(new string('-', 50));
                            Console.WriteLine("\t\t2. Принять на работу нового сотрудника");
                            Console.WriteLine(new string('-', 50));
                            AddToXML.CreateUser();                           
                        }
                        break;

                    case 3:
                        {
                            Console.WriteLine(new string('-', 50));
                            Console.WriteLine("\t\t3. Уволить сотрудника");
                            Console.WriteLine(new string('-', 50));
                            AddToXML.FireUser();
                        }
                        break;

                    case 4:
                        {
                            Console.WriteLine(new string('-', 50));
                            Console.WriteLine("\t\t4. Найти сотрудника по имени");
                            Console.WriteLine(new string('-', 50));

                            AddToXML.SelectUser();




                        }
                        break;

                    case 5:
                        {
                            Console.WriteLine(new string('-', 50));
                            Console.WriteLine("\t\t5. Отобразить статистику");
                            Console.WriteLine(new string('-', 50));
                            AddToXML.Statistics();

                        }
                        break;

                    case 6:
                        {

                            Console.WriteLine(new string('-', 50));
                            Console.WriteLine("\t\t6. Выход");
                            Console.WriteLine(new string('-', 50));
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Спасибо!");
                            Console.ForegroundColor = color;
                            inProgress = false;
                            Console.WriteLine(new string('-', 50));
                        }
                        break;

                    default:
                        {
                            Console.WriteLine("Выберите пункт меню");
                        }
                        break;
                }
            }
        }
        public static class AddToXML
        {
            public static void PrinterItem(XmlElement item, int indent = 0)
            {
                // Выводим имя самого элемента
                // new string('\t', indent) - создает строку состоящую из indent табов
                // Это нужно для смещения вправо
                Console.Write($"{new string('\t', indent)}{item.LocalName}");

                // Если у элемента есть атрибуты, то выводим их поочередно, 
                // каждый в квадратных скобках
                foreach (XmlAttribute attr in item.Attributes)
                {
                    Console.Write($"[{attr.InnerText}]");
                }
                // Если у элемента есть зависивые элементы, то выводим
                foreach (var child in item.ChildNodes)
                {
                    if (child is XmlElement node)
                    {
                        Console.WriteLine();
                        PrinterItem(node, indent + 1);
                    }
                    if (child is XmlText text)
                    {
                        Console.Write($"-{text.InnerText}");
                    }
                }
                Console.WriteLine();
            }

            public static void PrinterNode(XmlNode item, int indent = 0)
            {
                // Выводим имя самого элемента
                // new string('\t', indent) - создает строку состоящую из indent табов
                // Это нужно для смещения вправо
                Console.Write($"{new string('\t', indent)}{item.LocalName}");

                // Если у элемента есть атрибуты, то выводим их поочередно, 
                // каждый в квадратных скобках
                foreach (XmlAttribute attr in item.Attributes)
                {
                    Console.Write($"[{attr.InnerText}]");
                }
                // Если у элемента есть зависивые элементы, то выводим
                foreach (var child in item.ChildNodes)
                {
                    if (child is XmlElement node)
                    {
                        Console.WriteLine();
                        PrinterItem(node, indent + 1);
                    }
                    if (child is XmlText text)
                    {
                        Console.Write($"-{text.InnerText}");
                    }
                }
                Console.WriteLine();
            }
            public static void CreateUser()
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("Users.xml");
                XmlElement root = doc.DocumentElement;
                XmlElement userXml = doc.CreateElement("user");

                User user = new User();
                Console.WriteLine("Введите имя: ");
                user.FName = Console.ReadLine();
                Console.WriteLine("Введите фамилию: ");
                user.LName = Console.ReadLine();
                Console.WriteLine("Введите отчество: ");
                user.MName = Console.ReadLine();
                Console.WriteLine("Введите дату рождения в формате дд.мм.гггг: ");
                user.DoB = Console.ReadLine();
                Console.WriteLine("Введите адрес: ");
                user.Address = Console.ReadLine();
                Console.WriteLine("Введите телефон: ");
                user.Phone = Console.ReadLine();

                Console.WriteLine("Введите логин: ");
                user.Login = Console.ReadLine();
                Console.WriteLine("Введите пароль: ");
                user.Password = Console.ReadLine();
                Console.WriteLine("Выберите должность: ");
                user.Position = SelectPosition();
                Console.WriteLine("Выберите филиал: ");
                user.Branch = SelectBranch();
                Console.WriteLine("Назначьте зарплату: ");
                user.Salary = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Назначьте статус: ");
                user.Status = SelectStatus();
                Console.WriteLine("Назначьте роль: ");
                user.Role = SelectRole();

                /*   <userid>1</userid>
                     <login>admin</login>
                     <password>admin</password>
                     <role>Admin</role>
                     <fname>Admini</fname>
                     <lname>Adminov</lname>
                     <mname>Adminich</mname>
                     <dob>01.01.2000</dob>
                     <position>IT специалист</position>
                     <branch>Филиал 1</branch>
                     <status>hired</status>
                     <salary>500000</salary>
                     <address>Алматы</address>
                     <phone>111</phone>*/

                XmlElement userid = doc.CreateElement("userid");
                userid.InnerText = Convert.ToString(user.UserId);
                XmlElement login = doc.CreateElement("login");
                login.InnerText = user.Login;
                XmlElement password = doc.CreateElement("password");
                password.InnerText = user.Password;
                XmlElement role = doc.CreateElement("role");
                role.InnerText = Convert.ToString(user.Role);
                XmlElement fname = doc.CreateElement("fname");
                fname.InnerText = user.FName;
                XmlElement lname = doc.CreateElement("lname");
                lname.InnerText = user.LName;
                XmlElement mname = doc.CreateElement("mname");
                mname.InnerText = user.MName;
                XmlElement dob = doc.CreateElement("dob");
                dob.InnerText = user.DoB;
                XmlElement position = doc.CreateElement("position");
                position.InnerText = user.Position.Name;
                XmlElement branch = doc.CreateElement("branch");
                branch.InnerText = user.Branch.Name;
                XmlElement status = doc.CreateElement("status");
                status.InnerText = user.Status.Name;
                XmlElement salary = doc.CreateElement("salary");
                salary.InnerText = Convert.ToString(user.Salary);
                XmlElement address = doc.CreateElement("address");
                address.InnerText = user.Address;
                XmlElement phone = doc.CreateElement("phone");
                phone.InnerText = user.Phone;

                userXml.AppendChild(userid);
                userXml.AppendChild(login);
                userXml.AppendChild(password);
                userXml.AppendChild(role);
                userXml.AppendChild(fname);
                userXml.AppendChild(lname);
                userXml.AppendChild(mname);
                userXml.AppendChild(dob);
                userXml.AppendChild(position);
                userXml.AppendChild(branch);
                userXml.AppendChild(status);
                userXml.AppendChild(salary);
                userXml.AppendChild(address);
                userXml.AppendChild(phone);

                root.AppendChild(userXml);
                doc.Save("Users.xml");
            }

            public static void CreatePosition()
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("Positions.xml");
                XmlElement root = doc.DocumentElement;
                XmlElement positionXml = doc.CreateElement("position");

                Position position = new Position();
                Console.WriteLine("Введите наименование позиции: ");
                position.Name = Console.ReadLine();

                XmlElement positionid = doc.CreateElement("positionid");
                positionid.InnerText = Convert.ToString(position.PositionId);
                XmlElement name = doc.CreateElement("name");
                name.InnerText = position.Name;

                positionXml.AppendChild(positionid);
                positionXml.AppendChild(name);

                root.AppendChild(positionXml);
                doc.Save("Positions.xml");

            }

            public static void CreateStatus()
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("Statuses.xml");
                XmlElement root = doc.DocumentElement;
                XmlElement statusXml = doc.CreateElement("status");

                Status status = new Status();
                Console.WriteLine("Введите наименование статуса: ");
                status.Name = Console.ReadLine();

                XmlElement statusid = doc.CreateElement("statusid");
                statusid.InnerText = Convert.ToString(status.StatusId);
                XmlElement name = doc.CreateElement("name");
                name.InnerText = status.Name;

                statusXml.AppendChild(statusid);
                statusXml.AppendChild(name);

                root.AppendChild(statusXml);
                doc.Save("Statuses.xml");

            }

            public static void CreateBranches()
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("Branches.xml");
                XmlElement root = doc.DocumentElement;
                XmlElement branchXml = doc.CreateElement("branch");

                Branch branch = new Branch();
                Console.WriteLine("Введите наименование филиала: ");
                branch.Name = Console.ReadLine();

                XmlElement branchid = doc.CreateElement("branchid");
                branchid.InnerText = Convert.ToString(branch.BranchId);
                XmlElement name = doc.CreateElement("name");
                name.InnerText = branch.Name;

                branchXml.AppendChild(branchid);
                branchXml.AppendChild(name);

                root.AppendChild(branchXml);
                doc.Save("Branches.xml");

            }

            public static User SelectUser()
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("Users.xml");

                XmlElement user = doc.DocumentElement;
                Console.WriteLine("Введите имф и фамилию: ");
                string fname = Console.ReadLine();
                string lname = Console.ReadLine();
                //PrinterItem(pos);
                //int number = Convert.ToInt32(Console.ReadLine());
                var posNum = doc.SelectNodes("users/user");
                User position = new User();
                foreach (XmlNode item in posNum)
                {
                    if (item.SelectSingleNode("fname").InnerText == fname && item.SelectSingleNode("lname").InnerText == lname)
                    {

                        PrinterNode(item);

                    }
                }
                return position;
            }

            public static void FireUser()
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("Users.xml");

                XmlElement user = doc.DocumentElement;
                Console.WriteLine("Введите имя и фамилию: ");
                string fname = Console.ReadLine();
                string lname = Console.ReadLine();
                //PrinterItem(pos);
                //int number = Convert.ToInt32(Console.ReadLine());
                var posNum = doc.SelectNodes("users/user");
                User position = new User();
                foreach (XmlNode item in posNum)
                {
                    if (item.SelectSingleNode("fname").InnerText == fname && item.SelectSingleNode("lname").InnerText == lname)
                    {
                        item.SelectSingleNode("status").InnerText = "fired";
                        doc.Save("Users.xml");
                        PrinterNode(item);

                    }
                   // PrinterNode(item);
                }
               // SelectUser()


            }

            public static void Statistics()
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("Users.xml");

                XmlElement user = doc.DocumentElement;
                //Console.WriteLine("Введите имя и фамилию: ");
                //string fname = Console.ReadLine();
                //string lname = Console.ReadLine();
                //PrinterItem(pos);
                //int number = Convert.ToInt32(Console.ReadLine());
                var posNum = doc.SelectNodes("users/user");
                User position = new User();
                int countEmployees = 0;
                int countSalary = 0;
                foreach (XmlNode item in posNum)
                {
                    if (item.SelectSingleNode("status").InnerText == "hired")
                    {
                        countEmployees++;
                        countSalary += Convert.ToInt32(item.SelectSingleNode("salary").InnerText);
                    }
                    // PrinterNode(item);
                }
                Console.WriteLine($"Общее количество сотрудников: {countEmployees}");
                Console.WriteLine($"Средняя зарплата сотрудников: {countSalary/ countEmployees}");

            }

            public static Position SelectPosition()
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("Positions.xml");

                XmlElement pos = doc.DocumentElement;
                Console.WriteLine("Выберите Id должности: ");
                PrinterItem(pos);
                int number = Convert.ToInt32(Console.ReadLine());
                var posNum = doc.SelectNodes("positions/position");
                Position position = new Position();
                foreach (XmlNode item in posNum)
                {
                    if (item.SelectSingleNode("positionid").InnerText == Convert.ToString(number))
                    {
                        position.PositionId = number;
                        position.Name = item.SelectSingleNode("name").InnerText;
                    }
                }
                return position;
            }
            public static Branch SelectBranch()
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("Branches.xml");

                XmlElement pos = doc.DocumentElement;
                Console.WriteLine("Выберите Id филиала: ");
                PrinterItem(pos);
                int number = Convert.ToInt32(Console.ReadLine());
                var brNum = doc.SelectNodes("branches/branch");
                Branch branch = new Branch();
                foreach (XmlNode item in brNum)
                {
                    if (item.SelectSingleNode("branchid").InnerText == Convert.ToString(number))
                    {
                        branch.BranchId = number;
                        branch.Name = item.SelectSingleNode("name").InnerText;
                    }
                }
                return branch;
            }

            public static Status SelectStatus()
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("Statuses.xml");

                XmlElement pos = doc.DocumentElement;
                Console.WriteLine("Выберите статус сотрудника: ");
                PrinterItem(pos);
                int number = Convert.ToInt32(Console.ReadLine());
                var stNm = doc.SelectNodes("statuses/status");
                Status status = new Status();
                foreach (XmlNode item in stNm)
                {
                    if (item.SelectSingleNode("statusid").InnerText == Convert.ToString(number))
                    {
                        status.StatusId = number;
                        status.Name = item.SelectSingleNode("name").InnerText;
                    }
                }
                return status;
            }
            public static Role SelectRole()
            {
                Console.Write("Выберите роль сотрудника: Admin[1], User[2]");
                int role = Convert.ToInt32(Console.ReadLine());
                if (role == 1)
                    return Role.Admin;
                else
                    return Role.User;
            }
        }
    }
}
