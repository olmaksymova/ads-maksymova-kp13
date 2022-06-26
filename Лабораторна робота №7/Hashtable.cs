using System;
using static System.Console;
namespace lab7
{
struct Key
{
    public string firstName;
    public string lastName;
}
struct Value
{
    public int patientID;
    public string familyDoctor;
    public string address;
}
struct Entry
{
    public Key key;
    public Value value;
}

    class Hashtable
    {
        private int size;
        private double loadness;
        private int capacity;
        private Entry[] table;


        public Hashtable()
        {
            this.capacity = 11;
            this.loadness = 0;
            this.size = 0;
            this.table = new Entry[this.capacity];
        }
        public void InsertEntry(Key key, Value value, DocHashtable addTable, ref int index)
        {
            if (this.loadness > 0.5)
                Rehashing();

            int hashIndex = getHash(key);

            for (int i = hashIndex; i <= this.capacity; i++)
            {
                if (i == this.capacity)
                    i = 0;
                //оновлення даних
                if (table[i].key.firstName == key.firstName && table[i].key.lastName == key.lastName)
                {
                    IsDoctorFree(addTable, key, value, i);
                    addTable.RemovePatient(table[i].key, table[i].value);

                    table[i].value.familyDoctor = value.familyDoctor;
                    table[i].value.address = value.address;

                    addTable.addPatient(key, table[i].value);
                    break;
                }
                //додавання даних в геш-таблицю
                if (table[i].key.firstName == "DELETED" || table[i].key.firstName == null)
                {
                    Entry toCheck = findEntry(key);
                    if (toCheck.key.firstName != null)
                        continue;
                    IsDoctorFree(addTable, key, value, i);
                    table[i].key = key;
                    table[i].value = value;
                    index++;
                    this.size++;
                    this.loadness = (double)this.size / this.capacity;
                    addTable.addPatient(key, value);
                    break;
                }
            }
        }
        public bool RemoveEntry(Key key, DocHashtable addTab)
        {
            int hash_index = getHash(key);
            for (int i = hash_index; i <= this.capacity; i++)
            {
                if (i == this.capacity) i = 0;
                if (table[i].key.firstName == null)
                    return false;
                if (table[i].key.firstName == key.firstName && table[i].key.lastName == key.lastName)
                {
                    addTab.RemovePatient(table[i].key, table[i].value);

                    table[i].key.firstName = "DELETED";
                    table[i].key.lastName = null;
                    table[i].value.patientID = 0;
                    table[i].value.address = null;
                    table[i].value.familyDoctor = null;

                    this.size--;
                    this.loadness = (double)this.size / this.capacity;
                    break;
                }
            }
            return true;
        }
        private long HashCode(Key key)
        {
            long hash = 0;
            string hashtable = key.firstName + key.lastName;

            for (int i = 0; i < hashtable.Length; i++)
                hash += (int)hashtable[i] * (i + 1);
            return hash;
        }
        private int getHash(Key key)
        {
            return (int)(HashCode(key) % capacity);
        }
        private void Rehashing()
        {
            WriteLine("Таблиця завантажена бiльш нiж на 50%. Виконується перегешування.");
            int oldCap = this.capacity;
            this.capacity *= 2;
            Entry[] newTable = new Entry[this.capacity];

            for (int i = 0; i < oldCap; i++)
            {
                if (table[i].key.firstName == null || table[i].key.firstName == "DELETED")
                    continue;
                int hash_index = getHash(table[i].key);

                for (int j = hash_index; j <= this.capacity; j++)
                {
                    if (j == this.capacity) 
                        j = 0;
                    if (newTable[j].key.firstName == null)
                    {
                        newTable[j] = table[i];
                        break;
                    }
                }
            }
            this.loadness = (double)this.size / this.capacity;
            table = newTable;
            WriteLine("Дані успішно оновлено.");
        }
        public void Print()
        {
            if (this.size == 0)
            {
                WriteLine("В таблиці нема жодного пацієнта!");
                return;
            }
            WriteLine("\t\t\tДані пацієнтів");
            for (int i = 0; i < this.capacity; i++)
            {
                if (table[i].key.firstName != null && table[i].key.firstName != "DELETED")
                {
                    int id = this.table[i].value.patientID;
                    string firstname = this.table[i].key.firstName;
                    string lastname = this.table[i].key.lastName;
                    string doctor = this.table[i].value.familyDoctor;
                    string address = this.table[i].value.address;
                    WriteLine($"{id} {lastname} {firstname}, адреса: {address}, доктор: {doctor} ");
                }
            }
            WriteLine();
        }
        public Entry findEntry(Key key)
        {
            Entry nullEntry = new Entry();
            int hashIndex = getHash(key);

            for (int i = hashIndex; i <= this.capacity; i++)
            {
                if (i == this.capacity)
                    i = 0;
                if (table[i].key.firstName == key.firstName && table[i].key.lastName == key.lastName)
                    return table[i];
                if (table[i].key.firstName == null)
                    break;
            }
            return nullEntry;
        }
        private void IsDoctorFree(DocHashtable docTable, Key key, Value value, int i)
        {
            EntryDoc doc = docTable.FindDoctor(value.familyDoctor);
            if (doc.doctor != null && doc.patients.Count == 5)
            {
                if (table[i].value.familyDoctor != doc.doctor)
                    throw new Exception("Доктор недоступен, так як вже має 5 пацiєнтів.");
            }
        }
        public void FindPatient(string firstname, string lastname)
        {
            string name = Program.CheckString(firstname);
            string surname = Program.CheckString(lastname);
            if (name == "ERROR" || surname == "ERROR")
            {
                WriteLine("Помилка введення даних!");
                return;
            }
            Key key = new Key
            {
                firstName = name,
                lastName = surname
            };
            Entry found = findEntry(key);
            if (found.key.firstName == null)
            {
                WriteLine("Пацієнта не знайдено.");
            }
            else
            {
                WriteLine("Пацієнт:");
                WriteLine($"{found.value.patientID} { found.key.lastName} {found.key.firstName} адреса: { found.value.address} , доктор {found.value.familyDoctor}");
            }
        }
    }
}