using System;

class Wizard
{
    // Field
    public string Name;
    public int Energy;
    public int Damage;

    // Constructor
    public Wizard(string name, int damage)
    {
        Name = name;
        Energy = 100;
        Damage = damage;
    }

    // Method Attack
    public void Attack(Wizard lawan)
    {
        lawan.Energy -= Damage;

        if (lawan.Energy < 0)
        {
            lawan.Energy = 0;
        }

        Console.WriteLine(Name + " menyerang " + lawan.Name);
        Console.WriteLine("Sisa energi " + lawan.Name + ": " + lawan.Energy);
        Console.WriteLine();
    }

    // Method Heal
    public void Heal()
    {
        Energy += 5;

        if (Energy > 100)
        {
            Energy = 100;
        }

        Console.WriteLine(Name + " melakukan Heal.");
        Console.WriteLine("Energi sekarang: " + Energy);
        Console.WriteLine();
    }

    // Method ShowStats
    public void ShowStats()
    {
        Console.WriteLine("Nama   : " + Name);
        Console.WriteLine("Energi : " + Energy);
        Console.WriteLine("Damage : " + Damage);
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Membuat 2 object Wizard
        Wizard wizard1 = new Wizard("Gandalf", 20);
        Wizard wizard2 = new Wizard("Merlin", 15);

        Console.WriteLine("=== STATUS AWAL ===");
        wizard1.ShowStats();
        wizard2.ShowStats();

        // Skenario battle
        wizard1.Attack(wizard2);
        wizard2.Attack(wizard1);
        wizard1.Attack(wizard2);

        Console.WriteLine("=== STATUS AKHIR ===");
        wizard1.ShowStats();
        wizard2.ShowStats();

        // Heal
        wizard1.Heal();
        wizard2.Heal();
    }
}