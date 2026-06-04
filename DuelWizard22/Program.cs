using System.Net.Http.Metrics;
using System.Runtime.InteropServices;

wizard WizardA = new wizard("Arges", 10);
wizard WizardB = new wizard("Rafa", 20);

Console.WriteLine("Permainan dimulaaiii!!\n");
Console.WriteLine("Statistik awal");
WizardA.ShowStats();
WizardB.ShowStats();

string pilihan;

while (true)
{
    Console.Clear();

    Console.WriteLine($"1. {WizardA.Name} menyerang {WizardB.Name}");
    Console.WriteLine($"2. {WizardB.Name} menyerang {WizardA.Name}");
    Console.WriteLine($"3. {WizardA.Name} melakukan heal");
    Console.WriteLine($"4. {WizardB.Name} melakukan heal");

    Console.WriteLine("\n Pilihanmu (1/2/3/4): ");
    pilihan = Console.ReadLine();

    if (pilihan == "1") WizardA.Attack(WizardB);
    else if (pilihan == "2") WizardB.Attack(WizardA);
    else if (pilihan == "3") WizardA.Heal();
    else if (pilihan == "4") WizardB.Heal();
    else Console.WriteLine("Pilihan tidak valid");

    if (WizardA.Energy <= 0 || WizardB.Energy <= 0)
    {
        Console.WriteLine("Permainan berakhir!");
        if (WizardA.Energy > WizardB.Energy)
        {
            Console.WriteLine($"{WizardB.Name} berhasil dikalahkan !");
            Console.WriteLine($"{WizardA.Name} Keluar sebagai pemenangnya !");
        }
        else
        {
            Console.WriteLine($"{WizardA} berhasil dikalahkan !");
            Console.WriteLine($"{WizardB.Name} keluar sebagai pemenangnya !");
        }

        break;
    }

    Console.ReadLine();
}

//WizardA.Attack(WizardB);
//WizardB.Attack(WizardA);
//WizardA.Attack(WizardB);
//WizardB.Attack(WizardA);
//WizardA.Heal();

Console.WriteLine("Permainan selesai.....\n");
Console.WriteLine("Statistik akhir");
WizardA.ShowStats();
WizardB.ShowStats();

public class wizard
{
    public string Name;
    public int Energy;
    public int Damage;

    public wizard(string name, int damage)
    {
        Name = name;
        Energy = 100;
        Damage = damage;
    }

    public void ShowStats()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Energy: {Energy}\n");
    }

    public void Attack(wizard enemy)
    {
        enemy.Energy -= Damage;
        Console.WriteLine($"{Name} menyerang {enemy.Energy}");
        Console.WriteLine($"Sisa eneri {enemy.Name}: {enemy.Energy}\n");
    }

    public void Heal()
    {
        if (Energy >= 100)
        {
            Console.WriteLine("Gagal melakukan heal. Energi sudah mencapai maksimal!");
        }
        else
        {
            if (Energy > 95)
            {
                Energy = 100;
            }
            else
            {
                Energy += 5;
            }
            Console.WriteLine($"{Name} berhasil melakukan heal. Energi meningkat menjadi {Energy} ");
        }

    }

}