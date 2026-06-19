using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main()
    {
        Console.WriteLine("===========================================");
        Console.WriteLine("   РАБОТА С ПАМЯТЬЮ И МАССИВАМИ");
        Console.WriteLine("===========================================\n");

        // ===========================================
        // 1. МАССИВ ЦЕЛЫХ ЧИСЕЛ (int) - 4 байта каждый
        // ===========================================
        Console.WriteLine("1️⃣ МАССИВ INT (4 байта на элемент)");
        Console.WriteLine("------------------------------------");
        
        int[] intArray = { 10, 20, 30, 40, 50 };
        
        Console.WriteLine($"Размер массива: {intArray.Length} элементов");
        Console.WriteLine($"Общий размер: {intArray.Length * sizeof(int)} байт");
        Console.WriteLine($"Адрес в памяти (GCHandle): {GetMemoryAddress(intArray)}");
        
        Console.Write("Элементы: ");
        foreach (int item in intArray)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine("\n");

        // ===========================================
        // 2. МАССИВ ДРОБНЫХ ЧИСЕЛ (double) - 8 байт каждый
        // ===========================================
        Console.WriteLine("2️⃣ МАССИВ DOUBLE (8 байт на элемент)");
        Console.WriteLine("--------------------------------------");
        
        double[] doubleArray = { 1.1, 2.2, 3.3, 4.4 };
        
        Console.WriteLine($"Размер массива: {doubleArray.Length} элементов");
        Console.WriteLine($"Общий размер: {doubleArray.Length * sizeof(double)} байт");
        Console.WriteLine($"Адрес в памяти (GCHandle): {GetMemoryAddress(doubleArray)}");
        
        Console.Write("Элементы: ");
        foreach (double item in doubleArray)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine("\n");

        // ===========================================
        // 3. МАССИВ СТРОК (string) - ссылки на heap
        // ===========================================
        Console.WriteLine("3️⃣ МАССИВ STRING (ссылки на heap)");
        Console.WriteLine("-----------------------------------");
        
        string[] stringArray = { "Привет", "Мир", "C#", "Память" };
        
        Console.WriteLine($"Размер массива: {stringArray.Length} элементов");
        Console.WriteLine($"Размер ссылки: {IntPtr.Size} байт");
        Console.WriteLine($"Общий размер ссылок: {stringArray.Length * IntPtr.Size} байт");
        Console.WriteLine($"Адрес в памяти (GCHandle): {GetMemoryAddress(stringArray)}");
        
        Console.Write("Элементы: ");
        foreach (string item in stringArray)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine("\n");

        // ===========================================
        // 4. ДВУМЕРНЫЙ МАССИВ (матрица)
        // ===========================================
        Console.WriteLine("4️⃣ ДВУМЕРНЫЙ МАССИВ (матрица 3x3)");
        Console.WriteLine("------------------------------------");
        
        int[,] matrix = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };
        
        Console.WriteLine($"Размер матрицы: {matrix.GetLength(0)}x{matrix.GetLength(1)}");
        Console.WriteLine($"Всего элементов: {matrix.Length}");
        Console.WriteLine($"Общий размер: {matrix.Length * sizeof(int)} байт");
        Console.WriteLine($"Адрес в памяти (GCHandle): {GetMemoryAddress(matrix)}");
        
        Console.WriteLine("Матрица:");
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        // ===========================================
        // 5. ОПЕРАЦИИ С МАССИВАМИ (копирование, изменение)
        // ===========================================
        Console.WriteLine("5️⃣ ОПЕРАЦИИ С МАССИВАМИ");
        Console.WriteLine("------------------------");
        
        // Копирование массива
        int[] originalArray = { 1, 2, 3, 4, 5 };
        int[] copiedArray = new int[originalArray.Length];
        Array.Copy(originalArray, copiedArray, originalArray.Length);
        
        Console.WriteLine("Оригинальный массив: " + string.Join(", ", originalArray));
        Console.WriteLine("Скопированный массив: " + string.Join(", ", copiedArray));
        
        // Изменение скопированного массива
        copiedArray[0] = 999;
        Console.WriteLine("После изменения copiedArray[0] = 999");
        Console.WriteLine("Оригинальный массив: " + string.Join(", ", originalArray));
        Console.WriteLine("Скопированный массив: " + string.Join(", ", copiedArray));
        Console.WriteLine("✅ Оригинальный массив НЕ изменился (глубокая копия)");
        Console.WriteLine();

        // ===========================================
        // 6. ИЗМЕНЕНИЕ РАЗМЕРА МАССИВА (Array.Resize)
        // ===========================================
        Console.WriteLine("6️⃣ ИЗМЕНЕНИЕ РАЗМЕРА МАССИВА");
        Console.WriteLine("-----------------------------");
        
        int[] resizeArray = { 1, 2, 3 };
        Console.WriteLine($"Исходный массив: {string.Join(", ", resizeArray)} (размер: {resizeArray.Length})");
        
        Array.Resize(ref resizeArray, 5);
        Console.WriteLine($"После Array.Resize(ref resizeArray, 5)");
        Console.WriteLine($"Новый массив: {string.Join(", ", resizeArray)} (размер: {resizeArray.Length})");
        Console.WriteLine("⚠️ Новые элементы заполнены значениями по умолчанию (0)");
        Console.WriteLine();

        // ===========================================
        // 7. ИНФОРМАЦИЯ О ПАМЯТИ (GC)
        // ===========================================
        Console.WriteLine("7️⃣ ИНФОРМАЦИЯ О ПАМЯТИ (Garbage Collector)");
        Console.WriteLine("------------------------------------------");
        
        Console.WriteLine($"Всего памяти в управляемой куче: {GC.GetTotalMemory(false)} байт");
        Console.WriteLine($"Максимальное поколение GC: {GC.MaxGeneration}");
        Console.WriteLine($"Поколение intArray: {GC.GetGeneration(intArray)}");
        Console.WriteLine($"Поколение doubleArray: {GC.GetGeneration(doubleArray)}");
        Console.WriteLine($"Поколение stringArray: {GC.GetGeneration(stringArray)}");
        Console.WriteLine();

        // ===========================================
        // 8. РАЗНИЦА МЕЖДУ STACK И HEAP
        // ===========================================
        Console.WriteLine("8️⃣ STACK vs HEAP (теория)");
        Console.WriteLine("--------------------------");
        Console.WriteLine("📌 STACK (стек):");
        Console.WriteLine("   - Хранит: локальные переменные (int, double, bool)");
        Console.WriteLine("   - Размер: ~1 МБ");
        Console.WriteLine("   - Скорость: очень быстрый");
        Console.WriteLine("   - Живёт: пока выполняется метод");
        Console.WriteLine();
        Console.WriteLine("📌 HEAP (куча):");
        Console.WriteLine("   - Хранит: объекты, массивы, строки");
        Console.WriteLine("   - Размер: ограничен только RAM");
        Console.WriteLine("   - Скорость: медленнее стека");
        Console.WriteLine("   - Живёт: пока не удалит GC");
        Console.WriteLine();

        Console.WriteLine("===========================================");
        Console.WriteLine("   ПРОГРАММА ЗАВЕРШЕНА");
        Console.WriteLine("===========================================");
        Console.WriteLine("\nНажми любую клавишу для выхода...");
        Console.ReadKey();
    }

    // Функция для получения "адреса" объекта в памяти
    static string GetMemoryAddress(object obj)
    {
        GCHandle handle = GCHandle.Alloc(obj, GCHandleType.WeakTrackResurrection);
        IntPtr address = GCHandle.ToIntPtr(handle);
        handle.Free();
        return $"0x{address.ToString("X")}";
    }
}
