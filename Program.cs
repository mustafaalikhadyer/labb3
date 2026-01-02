using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            using var context = new SkolaContext();

            while (true)
            {
                Console.WriteLine("1. Visa alla studenter");
                Console.WriteLine("2. Visa studenter i klass");
                Console.WriteLine("3. Lägg till student");
                Console.WriteLine("4. Visa personal");
                Console.WriteLine("5. Lägg till personal");
                Console.WriteLine("0. Avsluta");

                string? val = Console.ReadLine();

                switch (val)
                {
                    case "1":
                        VisaAllaStudenter(context);
                        break;
                    case "2":
                        VisaStudenterIKlass(context);
                        break;
                    case "3":
                        LaggaTillStudent(context);
                        break;
                    case "4":
                        VisaPersonal(context);
                        break;
                    case "5":
                        LaggaTillPersonal(context);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Ogiltigt val");
                        break;
                }
            }
        }

        static void VisaAllaStudenter(SkolaContext context)
        {
            var studenter = context.Studenter.Include(s => s.Klass).ToList();
            foreach (var s in studenter)
            {
                Console.WriteLine($"{s.Fornamn} {s.Efternamn} ({s.Personnummer}) - Klass: {s.Klass.KlassNamn}");
            }
        }

        static void VisaStudenterIKlass(SkolaContext context)
        {
            var klasser = context.Klasser.ToList();
            for (int i = 0; i < klasser.Count; i++)
                Console.WriteLine($"{i + 1}. {klasser[i].KlassNamn}");

            Console.Write("Välj klassnummer: ");
            if (!int.TryParse(Console.ReadLine(), out int val) || val < 1 || val > klasser.Count)
            {
                Console.WriteLine("Ogiltigt val.");
                return;
            }

            var klass = klasser[val - 1];

            var studenter = context.Studenter
                .Where(s => s.KlassID == klass.KlassID)
                .ToList();

            foreach (var s in studenter)
                Console.WriteLine($"{s.Fornamn} {s.Efternamn}");
        }

        static void LaggaTillStudent(SkolaContext context)
        {
            Console.Write("Förnamn: ");
            string fornamn = Console.ReadLine()!;
            Console.Write("Efternamn: ");
            string efternamn = Console.ReadLine()!;
            Console.Write("Personnummer: ");
            string personnummer = Console.ReadLine()!;

            // Lista alla klasser
            var klasser = context.Klasser.AsNoTracking().ToList();
            for (int i = 0; i < klasser.Count; i++)
                Console.WriteLine($"{i + 1}. {klasser[i].KlassNamn}");

            Console.Write("Välj klassnummer för studenten: ");
            if (!int.TryParse(Console.ReadLine(), out int val) || val < 1 || val > klasser.Count)
            {
                Console.WriteLine("Ogiltigt val, studenten läggs inte till.");
                return;
            }
            int klassID = klasser[val - 1].KlassID;

            var student = new Student
            {
                Fornamn = fornamn,
                Efternamn = efternamn,
                Personnummer = personnummer,
                KlassID = klassID
            };

            context.Studenter.Add(student);
            context.SaveChanges();
            Console.WriteLine("Student tillagd!");
        }

        static void VisaPersonal(SkolaContext context)
        {
            var personal = context.Personal.ToList();
            foreach (var p in personal)
                Console.WriteLine($"{p.Fornamn} {p.Efternamn} ({p.Befattning})");
        }

        static void LaggaTillPersonal(SkolaContext context)
        {
            Console.Write("Förnamn: ");
            string fornamn = Console.ReadLine()!;
            Console.Write("Efternamn: ");
            string efternamn = Console.ReadLine()!;
            Console.Write("Personnummer: ");
            string personnummer = Console.ReadLine()!;
            Console.Write("Befattning: ");
            string befattning = Console.ReadLine()!;

            var personal = new Personal
            {
                Fornamn = fornamn,
                Efternamn = efternamn,
                Personnummer = personnummer,
                Befattning = befattning
            };

            context.Personal.Add(personal);
            context.SaveChanges();
            Console.WriteLine("Personal tillagd!");
        }
    }
}
