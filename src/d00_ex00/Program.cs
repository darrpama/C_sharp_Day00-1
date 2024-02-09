using System.Reflection.Metadata;

if (args.Length != 3) {
    throw new ArgumentException("Something went wrong. Check your input and retry.");
}

// for (int i = 0; i < args.Length; i++) {
//     Console.Write("{0} ", args[i]);
// }

double GetTotalMonthlyPayment(double loanAmmount, double interestRateOnLoanPerMounth, int mounths) {
    if (mounths < 0) {
        throw new ArgumentException("Number of mounths should be > 0");
    }
    double montlyPayment = 0;
    montlyPayment = (loanAmmount*interestRateOnLoanPerMounth*Math.Pow((1+interestRateOnLoanPerMounth), mounths))/(Math.Pow((1+interestRateOnLoanPerMounth), mounths) - 1);
    return montlyPayment;
}

double GetInterestRateOnLoanPerMounth(double annualPercentageRate) {
    double interestRateOnLoanPerMounth = 0;
    interestRateOnLoanPerMounth = annualPercentageRate/12/100;
    return interestRateOnLoanPerMounth;
}

double GetMonthlyPaymentInterest(double totalDebtBalance, double annualPercentageRate, int daysOfPeriod, int daysPerYear) {
    double monthlyPaymentInterest = 0;
    monthlyPaymentInterest = (totalDebtBalance*annualPercentageRate*daysOfPeriod)/(100*daysOfPeriod);
    return monthlyPaymentInterest;
}

double LoanAmount = Convert.ToDouble(args[0]);
double AnnualPercentageRate = Convert.ToDouble(args[1]);
int NumberOfMonths = Convert.ToInt32(args[2]);

// Console.WriteLine("{0} ", LoanAmount);
// Console.WriteLine("{0} ", AnnualPercentageRate);
// Console.WriteLine("{0} ", NumberOfMonths);

void PrintOutput(int mounths) {
    DateTime currentDate = DateTime.Now;
    // var date = DateTime.ParseExact(dateStr, "MM-dd-yyyy", System.Globalization.CultureInfo.InvariantCulture);
    for (int i = 1; i <= mounths; i++) {
        // Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", i, date.ToString("MM/dd/yyyy"));
        currentDate = currentDate.AddMonths(1);
        Console.WriteLine("{0}\t{1}", i, currentDate.ToString("MM/dd/yyyy"));
    }
}

PrintOutput(10);