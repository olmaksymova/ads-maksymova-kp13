using static System.Console;

namespace lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            OutputEncoding = System.Text.Encoding.UTF8;

            DocHashtable doctors = new DocHashtable();
            Hashtable patients = new Hashtable();
            string sample = "";
            int id = 41800;
            while (sample != "2")
            {
                WriteLine("Бажаєте використати контрольний приклад ( 0 - ні, 1 - так, 2 - вихід)?");
                sample = ReadLine();
                while (sample == "0")
                {
                    WriteLine("Оберіть команду: \n1 - Додати пацiєнта \n2 - Видалити пацiєнта\n3 - Знайти пацiєнта\n4 - Вивести таблицю\n" +
                    "5 - Знайти пацiєнтiв доктора\n6 - Вивести докторів\n7 - Вихід з таблиці");
                    string command = ReadLine();
                    switch (command)
                    {
                        case "1":
                            WriteLine("Введiть прiзвище,iм'я,адресу проживання,бажаного доктора за заданим порядком. Приклад:\n" +
                                "Максимова\nОльга\nМеталістів 5\nРудченко");
                            string lastname = ReadLine();
                            string firstname = ReadLine();
                            string address = ReadLine();
                            string doctor = ReadLine();
                            string result = ProcessInsertion(patients, firstname, lastname, address, doctor, ref id, doctors);
                            WriteLine(result);
                            break;
                        case "2":
                            WriteLine("Введiть прiзвище,iм'я,адресу проживання,бажаного доктора за заданим порядком. Приклад:\n" +
                                "Максимова\nОльга\nМеталістів 5\nРудченко");
                            string surname = ReadLine();
                            string name = ReadLine();
                            string resultRemove = Removing(patients, CheckString(name), CheckString(surname), doctors);
                            WriteLine(resultRemove);
                            break;
                        case "3":
                            WriteLine("Введiть прiзвище,iм'я пацієнта порядково, щоб знайти даного пацієнта:");
                            string secname = ReadLine();
                            string fname = ReadLine();
                            patients.FindPatient(fname, secname);
                            break;
                        case "4":
                            patients.Print();
                            break;
                        case "5":
                            WriteLine("Введіть ім'я доктора:");
                            string doc = ReadLine();
                            string resultPatients = FindFamilyDoctorPatients(doctors, doc);
                            if (resultPatients != "")
                                WriteLine(resultPatients);
                            break;
                        case "6":
                            doctors.Print();
                            break;
                        case "7":
                            {
                                sample = "3";
                                doctors = new DocHashtable();
                                patients = new Hashtable();
                            }
                            break;
                        default:
                            WriteLine("Цієї команди нема в списку команд!");
                            break;
                    }
                }
                if (sample == "1")
                {
                    WriteLine("Створення таблиці...");
                    Control(patients, ref id, doctors);
                }
            }
        }

        static string ProcessInsertion(Hashtable table, string Name, string SurName, string Address, string Doctor, ref int id, DocHashtable docHashtable)
        {
            string name = CheckString(Name);
            string surname = CheckString(SurName);
            string doctor = CheckString(Doctor);
            string address = Address;
            if (name == "" || surname == "" || doctor == "" || address == "")
                return "Помилка введення даних! Недопустимі символи чи пуста строка!";
            Key key = new Key { firstName = name, lastName = surname };
            Value value = new Value { patientID = id, address = address, familyDoctor = doctor };
            try
            {
                table.InsertEntry(key, value, docHashtable, ref id);
                WriteLine("Пацієнта успішно додано!");
            }
            catch
            {
                WriteLine("Даний доктор зайнят. Оберіть іншого:");
                string AvailableDoc = docHashtable.FindAvailableDoctor();
                if (AvailableDoc == null)
                {
                    WriteLine("Усі доктори мають по 5 пацієнтів. ");
                    string NewDoctor = "";
                    while (NewDoctor == "")
                    {
                        WriteLine("Введіть ім'я нового доктора:");
                        NewDoctor = CheckString(ReadLine());
                        EntryDoc doc = docHashtable.FindDoctor(NewDoctor);
                        if (doc.doctor != null && doc.patients.Count == 5)
                        {
                            Entry entity = (Entry)table.findEntry(key);
                            if (entity.value.familyDoctor != NewDoctor)
                            {
                                WriteLine("Даний доктор наразi не доступен.");
                                NewDoctor = "";
                            }
                        }

                    }
                    value.familyDoctor = NewDoctor;
                }
                else
                {
                    string command = "";
                    WriteLine($"Доступний доктор: {AvailableDoc}. Хочете його обрати? (1 - так, 0 - ні)");
                    while (true)
                    {
                        command = ReadLine();
                        if (command == "1")
                        {
                            value.familyDoctor = AvailableDoc;
                            break;
                        }
                        else if (command == "0")
                        {
                            string NewDoctor = "";
                            while (NewDoctor == "")
                            {
                                WriteLine("Введіть ім'я нового доктора:");
                                NewDoctor = CheckString(ReadLine());
                            }
                            EntryDoc doc = docHashtable.FindDoctor(NewDoctor);
                            if (doc.doctor != null && doc.patients.Count == 5)
                            {
                                Entry entity = table.findEntry(key);
                                if (entity.value.familyDoctor != NewDoctor)
                                    WriteLine("Даний доктор наразi не доступен, оберiть iншого...");
                            }
                            value.familyDoctor = NewDoctor;
                        }
                        else
                            WriteLine("Некоректно введені дані. Спробуйте ще раз.");
                    }
                }
                table.InsertEntry(key, value, docHashtable, ref id);
            }
            return "";
        }
        static string Removing(Hashtable table, string name, string surname, DocHashtable addTable)
        {
            if (name == "" || surname == "")
                return "Помилка введення даних";
            Key key = new Key
            {
                firstName = name,
                lastName = surname
            };
            bool deleted = table.RemoveEntry(key, addTable);
            if (deleted)
                return "Пацієнта видалено успішно.";
            else
                return "Пацієнта не знайдено";
        }

        static string FindFamilyDoctorPatients(DocHashtable table, string doc)
        {
            string doctor = CheckString(doc);
            if (doctor == "")
                return "Неправильно введені дані.";
            EntryDoc patients = table.FindDoctor(doctor);
            if (patients.doctor == null)
                return "Доктора не знайдено";
            if (patients.patients.Count == 0)
                return $"В доктора {doctor} ще нема пацієнтів.";
            else
            {
                WriteLine($"Доктор {doctor}:");
                Entry[] array = new Entry[patients.patients.Count];
                patients.patients.CopyTo(array);
                for (int j = 0; j < array.Length; j++)
                {
                    string fname = array[j].key.firstName;
                    string lname = array[j].key.lastName;
                    string adress = array[j].value.address;
                    int id = array[j].value.patientID;
                    WriteLine($"Пацієнт №{j + 1}: {id} {fname} {lname}, адреса:{adress}");
                }
            }
            return "";
        }
        static void Control(Hashtable patientsTable, ref int id, DocHashtable doctorsTable)
        {
            string[] names = new string[]
            {
                "Ольга", "Валерій", "Марія", "Андрій", "Дмитро",
                "Максим","Ганна","Тетяна","Олег","Катерина",
                "Олександр","Тимур"
            };
            string[] surnames = new string[]
            {
               "Максимова","Гребенкін","Шрам","Таратула", "Логвинов",
                "Шкарупило","Шубіна","Радченко","Швидкий","Присяжна",
                "Воробйов","Дідух"
            };
            string[] address = new string[]
            {
                "Олекси Тихого 5","Шевченківська 12", "Героїв Дніпра 10", "Степанківська 19","Немирова 32",
                "Урбаністстька 283","Димитрова 26","Рубановського 282","Площа Свободи 21","Королюка",
                "Горіхова 123","Петровського 21"
            };
            string[] doctors = new string[]
            {
                "Степанюк","Симоненко","Рудченко"
            };

            for (int i = 0; i < names.Length; i++)
            {
                Value value = new Value { patientID = id, address = address[i] };
                Key key = new Key { firstName = names[i], lastName = surnames[i] };

                if (i < 4)
                    value.familyDoctor = doctors[0];
                else if (i < 8)
                    value.familyDoctor = doctors[1];
                else
                    value.familyDoctor = doctors[2];

                patientsTable.InsertEntry(key, value, doctorsTable, ref id);
            }
            patientsTable.Print();

            WriteLine("Вставити користувача:\nКороленко\nДмитро\nКоломойська 26\nРудченко");
            try
            {
                patientsTable.InsertEntry(new Key { firstName = "Дмитро", lastName = "Короленко" },
                new Value { patientID = id, familyDoctor = "Рудченко", address = "Коломойська 26" }, doctorsTable, ref id);
                WriteLine("Пацiєнта додано успiшно!");
            }
            catch
            {
                string availableDoc = doctorsTable.FindAvailableDoctor();
                WriteLine($"Доступний доктор: {availableDoc}. Обрати його ? (1 - так, 0 - ні)");
                WriteLine("1");
                patientsTable.InsertEntry(new Key { firstName = "Дмитро", lastName = "Короленко" },
                 new Value { patientID = id, familyDoctor = availableDoc, address = "Коломойська 26" }, doctorsTable, ref id);
                WriteLine("Пацiєнта додано успiшно!");
            }
            WriteLine("\nЗнайти пацієнта:\nШрам\nМарія");
            patientsTable.FindPatient("Марія", "Шрам");
            WriteLine("Видалити пацієнта: \nШрам\nМарія");
            WriteLine(Removing(patientsTable, "Марія", "Шрам", doctorsTable));
            WriteLine("\nЗнайти пацієнта:\nШрам\nМарія");
            patientsTable.FindPatient("Марія", "Шрам");
            patientsTable.Print();
            WriteLine("\nЗнайти доктора:\n");
            WriteLine(FindFamilyDoctorPatients(doctorsTable, "Рудченко"));
            doctorsTable.Print();

            doctorsTable = new DocHashtable();
            patientsTable = new Hashtable();
        }
        static public string CheckString(string input)
        {
            string correct = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsLetter(input[i]))
                    return "";
                correct += input[i];
            }
            return correct;
        }
    }
}