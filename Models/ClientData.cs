namespace ClientApi.Models;

public class FloorSheet
{
    public Guid Id { get; set; }
    public long Contract_No { get; set; }
    
    public string? Symbol { get; set; }
    public int Buyer {get; set;}
    public int Seller {get; set;}
    public string? Client_Name { get; set; }
    public long Client_Code { get; set; }
    public int Quantity {get; set;}
    public decimal Rate {get; set;}
    public decimal Amount {get; set;}
    public decimal Stock_Commission {get; set;}
    public decimal Bank_Deposit {get; set;}

   
}
