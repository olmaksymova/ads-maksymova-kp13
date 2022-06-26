using System;
using System.Collections.Generic;
using static System.Console;

namespace lab7
{
    //В додатковій геш-таблиці DocHashtable використовується лінійне зондування
    struct EntryDoc
    {
        public string doctor;
        public List<Entry> patients;
    }
    class DocHashtable
    {
        private int size;
        private double loadness;
        private int capacity;

        private EntryDoc[] table;
        public DocHashtable()
        {
            capacity = 11;
            loadness = 0;
            size = 0;
            table = new EntryDoc[this.capacity];
        }
        public void addPatient(Key key, Value value)
        {
            if (loadness > 0.5)
                Rehashing();

            int hashIndex = getHash(value.familyDoctor);

            EntryDoc doctor = FindDoctor(value.familyDoctor);
            bool DoctorExist = doctor.doctor != null;

            Entry patient = new Entry
            {
                key = new Key() {firstName = key.firstName, lastName = key.lastName},
                value = new Value() {patientID = value.patientID, address = value.address}
            };

            for (int i = hashIndex; i <= this.capacity; i++)
            {
                if (i == this.capacity) i = 0;
                if (DoctorExist)
                {
                    if (table[i].doctor == value.familyDoctor)
                    {
                        table[i].patients.Add(patient);
                        break;
                    }
                }
                else
                {
                    if (table[i].doctor == null)
                    {
                        table[i].doctor = value.familyDoctor;
                        table[i].patients = new List<Entry>();
                        table[i].patients.Add(patient);
                        this.size++;
                        this.loadness = (double)this.size / this.capacity;
                        break;
                    }
                }
            }
        }
        public void RemovePatient(Key key, Value value)
        {
            int hashIndex = getHash(value.familyDoctor);

            Entry patient = new Entry()
            {
                key = new Key() { firstName = key.firstName, lastName = key.lastName },
                value = new Value() { patientID = value.patientID, address = value.address }
            };

            for (int i = hashIndex; i <= this.capacity; i++)
            {
                if (i == this.capacity) 
                    i = 0;
                if (table[i].doctor == value.familyDoctor)
                {
                    table[i].patients.Remove(patient);
                    break;
                }
            }
        }
        private long HashCode(string key)
        {
            long hash = 0;
            for (int i = 0; i < key.Length; i++)
                hash += (int)key[i]*(i+1);

            return hash;
        }

        private int getHash(string key)
        {
            return (int)(HashCode(key) % this.capacity);
        }
        public EntryDoc FindDoctor(string doctor)
        {
            EntryDoc nullEntry = new EntryDoc();
            int hashIndex = getHash(doctor);
            for (int i = hashIndex; i <= this.capacity; i++)
            {
                if (i == this.capacity) i = 0;
                if (table[i].doctor == doctor)
                    return table[i];
                if (table[i].doctor == null)
                    break;
            }
            return nullEntry;
        }
        public string FindAvailableDoctor()
        {
            for (int i = 0; i < this.capacity; i++)
            {
                if (table[i].doctor != null && table[i].patients.Count < 5)
                    return table[i].doctor;
            }
            return null;
        }
        private void Rehashing()
        {
            int oldCapacity = this.capacity;
            this.capacity *= 2;
            EntryDoc[] newTable = new EntryDoc[this.capacity];
            for (int i = 0; i < oldCapacity; i++)
            {
                if (table[i].doctor == null)
                    continue;

                int hashIndex = getHash(table[i].doctor);

                for (int j = hashIndex; j <= this.capacity; j++)
                {
                    if (j == this.capacity) 
                        j = 0;
                    if (newTable[j].doctor == null)
                    {
                        newTable[j] = table[i];
                        break;
                    }
                }
            }
            WriteLine("Таблиця була оновлена успішно");
            this.loadness = (double)this.size / this.capacity;
            table = newTable;
        }
        public void Print()
        {
            WriteLine("\n\t\t\tДоктори та їх пацієнти");

            for (int i = 0; i < this.capacity; i++)
            {
                if (table[i].doctor != null && table[i].patients.Count != 0)
                {
                    WriteLine($"Доктор {table[i].doctor}");
                    Entry[] array = new Entry[table[i].patients.Count];
                    table[i].patients.CopyTo(array);
                    for (int j = 0; j < array.Length; j++)
                    {
                        WriteLine($"Пацієнт {j + 1}: {array[j].value.patientID} {array[j].key.lastName} " +
                            $" {array[j].key.firstName} {array[j].value.address}");
                    }
                }
                else if (table[i].doctor != null && table[i].patients.Count == 0)
                {
                    WriteLine($"Доктор {table[i].doctor} не має пацієнтів.");
                }
            }
            WriteLine();
        }
    }
}