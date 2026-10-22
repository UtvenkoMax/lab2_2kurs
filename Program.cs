using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("=== Лабораторна 3.2, варіант 6 — Трапеція ===\n");

        Task2_Collections();
        Task3and4_BinaryTree();

        Console.WriteLine("\nНатисніть Enter для виходу...");
        Console.ReadLine();
    }

    // Завдання 2: Generic, non-generic колекції та масив
    static void Task2_Collections()
    {
        Console.WriteLine("--- Завдання 2: колекції та масив ---\n");

        Trapezoid t1 = new Trapezoid("червоний", "чорний", 10, 6, 4);
        Trapezoid t2 = new Trapezoid("синій", "білий", 8, 5, 3);
        Trapezoid t3 = new Trapezoid("зелений", "жовтий", 12, 8, 5);
        Trapezoid t4 = new Trapezoid("жовтий", "синій", 7, 4, 2);

        // 1) Узагальнена колекція List<T>
        Console.WriteLine("1) List<Trapezoid> (Generic):");
        List<Trapezoid> list = new List<Trapezoid>();
        list.Add(t1);
        list.Add(t2);
        list.Add(t3);
        list.Add(t4);

        Console.WriteLine("Додавання — усі елементи:");
        foreach (Trapezoid t in list)
            t.PrintInfo();

        // Пошук
        Trapezoid found = list.Find(x => x.FillColor == "синій");
        Console.WriteLine("\nПошук (заливка=синій): " + found);

        // Оновлення
        list[0].FillColor = "помаранчевий";
        Console.WriteLine("Оновлення list[0]: " + list[0]);

        // Видалення
        list.Remove(t2);
        Console.WriteLine("Після видалення t2, кількість = " + list.Count);

        // 2) Звичайна (non-generic) колекція ArrayList
        Console.WriteLine("\n2) ArrayList (non-generic):");
        ArrayList arrayList = new ArrayList();
        arrayList.Add(t1);
        arrayList.Add(t3);
        arrayList.Add(t4);

        Console.WriteLine("Прохід по ArrayList:");
        foreach (object obj in arrayList)
        {
            Trapezoid t = (Trapezoid)obj; // потрібне приведення типу
            t.PrintInfo();
        }

        arrayList.RemoveAt(0);
        Console.WriteLine("Після RemoveAt(0), кількість = " + arrayList.Count);

        // 3) Масив
        Console.WriteLine("\n3) Масив Trapezoid[]:");
        Trapezoid[] arr = new Trapezoid[4];
        arr[0] = t1;
        arr[1] = t2;
        arr[2] = t3;
        arr[3] = t4;

        Console.WriteLine("Прохід по масиву:");
        for (int i = 0; i < arr.Length; i++)
            Console.WriteLine($"  [{i}] {arr[i]}");

        // Оновлення в масиві
        arr[1] = new Trapezoid("фіолетовий", "сірий", 9, 6, 3);
        Console.WriteLine("Оновлений arr[1]: " + arr[1]);

        // Пошук в масиві
        int index = Array.FindIndex(arr, x => x != null && x.Height == 5);
        Console.WriteLine("Індекс з висотою 5: " + index);

        Console.WriteLine("\nВідмінності:");
        Console.WriteLine("- List<T>: типобезпечний, зручний Add/Remove/Find, динамічний розмір.");
        Console.WriteLine("- ArrayList: зберігає object, потрібне приведення, можливі помилки типів.");
        Console.WriteLine("- Масив: фіксований розмір, швидкий доступ за індексом, без зручного Remove.");
    }

    // Завдання 3–4: бінарне дерево, порівняння, ітератор (inorder)
    static void Task3and4_BinaryTree()
    {
        Console.WriteLine("\n--- Завдання 3–4: бінарне дерево (inorder) ---\n");

        Trapezoid t1 = new Trapezoid("червоний", "чорний", 10, 6, 4);
        Trapezoid t2 = new Trapezoid("синій", "білий", 8, 5, 3);
        Trapezoid t3 = new Trapezoid("зелений", "жовтий", 12, 8, 5);
        Trapezoid t4 = new Trapezoid("жовтий", "синій", 7, 4, 2);

        BinaryTree<Trapezoid> tree = new BinaryTree<Trapezoid>();
        tree.Insert(t1);
        tree.Insert(t2);
        tree.Insert(t3);
        tree.Insert(t4);

        Console.WriteLine("Обхід дерева (центрований / inorder) через foreach:");
        foreach (Trapezoid t in tree)
            t.PrintInfo();

        // Сортування через IComparable (за площею)
        Console.WriteLine("\nСортування List за площею (IComparable):");
        List<Trapezoid> sortedByArea = new List<Trapezoid> { t1, t2, t3, t4 };
        sortedByArea.Sort(); // використовує CompareTo
        foreach (Trapezoid t in sortedByArea)
            Console.WriteLine("  " + t);

        // Сортування через IComparer (за периметром)
        Console.WriteLine("\nСортування List за периметром (IComparer):");
        List<Trapezoid> sortedByPerim = new List<Trapezoid> { t1, t2, t3, t4 };
        sortedByPerim.Sort(new TrapezoidPerimeterComparer());
        foreach (Trapezoid t in sortedByPerim)
            Console.WriteLine("  " + t + $", P={t.GetPerimeter():F2}");
    }
}
