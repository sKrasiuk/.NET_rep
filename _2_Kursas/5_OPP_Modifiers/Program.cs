using _5_OPP_Modifiers.Models;

//var student = new Student("Vardas", 21, 01);
//student.GetStudentId();

//var teacher = new Teacher("Teacher", 50, "Math");
//teacher.GetSubject();


//var bankAcc = new Account();
var personalAcc = new PersonalAccount();
var savingsAcc = new SavingsAccount(0.02);

//bankAcc.SetBalance(100);
savingsAcc.SetBalance(200);
personalAcc.SetBalance(100);
personalAcc.SetOverdraftLimit(50);

Console.WriteLine($"Debit balance: {personalAcc.GetBalance()}");
Console.WriteLine($"Overdraft balance: {personalAcc.GetOverdraftLimit()}");
Console.WriteLine($"Saving interest: {savingsAcc.CalculateInterest()}");

personalAcc.PrintInfo();
Console.WriteLine($"Max withdraw amount: {personalAcc.Withdraw()}");