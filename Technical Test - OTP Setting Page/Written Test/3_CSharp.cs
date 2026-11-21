// 3.1 Simple OOP and syntax

namespace TechTest.Quiz;

public class EmployeeExplicit
{
    private string _name = string.Empty;
    private decimal _salary;

    public string GetName() => _name;
    public void SetName(string name) => _name = name;

    public decimal GetSalary() => _salary;
    public void SetSalary(decimal salary) => _salary = salary;
}


// 3.2 Pointer reference in C#
// What is the output from b.Name?
/*
Output:
Michael

Penjelasan: karna pada C#, 'class' merupakan reference type jadi ketika baris 'a = b;' dieksekusi, 
yang disalin adalah referensi (alamat memori pada managed heap), bukan membuat objek baru. Sehingga variabel 'a' dan 'b' menunjuk ke instance objek yang persis sama di heap. 
Jadi saaat 'a.Name' diubah menjadi "Michael", nilai 'b.Name' juga otomatis menjadi "Michael".
*/
